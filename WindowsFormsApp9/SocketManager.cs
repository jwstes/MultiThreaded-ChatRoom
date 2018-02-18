using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Socket
{
    delegate void ReceivedM(string Message, TcpClient FromClient);
    delegate void ClientC(TcpClient Client);
    delegate void ClientD(TcpClient Client);
    delegate void HostR();
    delegate void ConnectedS();
    delegate void HostL();
    class SocketManager
    {
        public event ReceivedM ReceivedMessage;
        public event ClientC ClientConnected;
        public event ClientD ClientDissconnected;
        public event HostR HostRefused;
        public event ConnectedS ConnectedServer;
        public event HostL HostLost;

        public int Port;
        public string Ip;

        //Client
        private TcpClient HostClient = new TcpClient();
        private Thread ListenHost;

        //Host
        private Thread[] _clientThreads = new Thread[0];
        private TcpClient[] _clients = new TcpClient[0];
        private TcpListener _TcpListener;
        private Thread Listener;

        private bool CreatedServer = false;
        private int MessageMaxLength;
        private int ID = 0;
        public bool Connected = false;
        public bool _isHost = false;
        public bool ListeningClients = false;

        public SocketManager(int MaxLengthOfMessages, int Port)
        {
            MessageMaxLength = MaxLengthOfMessages;
            this.Port = Port;
        }

        public void Host()
        {
            if (Connected)
                return;
            if (CreatedServer)
                throw new System.ArgumentException("You are already hosted, you have to restart to host again", "original");
            try
            {
                _TcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, Port));
                Listener = new Thread(new ThreadStart(StartListenClients));
                Listener.Start();
                _isHost = true;
                Connected = true;
                CreatedServer = true;
            }
            catch
            {
                Listener.Abort();
                _isHost = false;
                Connected = false;
            }
        }
        public void StartLisenClients()
        {
            if (_isHost)
            {
                if (ListeningClients)
                    return;
                _TcpListener.Start();
                ListeningClients = true;
            }
        }
        public void StopLisenClients()
        {
            if (_isHost)
            {
                if (!ListeningClients)
                    return;
                _TcpListener.Stop();
                ListeningClients = false;
            }
        }

        public void Connect(String Ip)
        {
            if (Connected)
                return;
            this.Ip = Ip;
            try
            {
                _isHost = false;
                HostClient.Connect(Ip, this.Port);
                ListenHost = new Thread(new ThreadStart(StartListenHost));
                ListenHost.Start();
                Connected = true;
                if (ConnectedServer != null)
                {
                    ConnectedServer();
                }
                
            }
            catch(Exception e)
            {
                string m = e.Message;
                if (m.Contains("target machine actively refused"))
                {
                    if (HostRefused != null)
                    {
                        HostRefused();
                    }
                    
                }
                _isHost = false;
                Connected = false;
            }

        }
        private void ReceivedMessagex(string m,TcpClient c)
        {
            if (ReceivedMessage != null)
            {
                ReceivedMessage(m, c);
            }
        }

        public void SendMessageToHost(string m)
        {
            if (!Connected)
                return;
            if (_isHost)
                return;
            SendData(HostClient, m,0);
        }
        public void SendMessageToHostAndAllClients(string m)
        {
            if (!Connected)
                return;
            if (_isHost)
                return;
            SendData(HostClient, m, 1);
        }
        public void SendMessageToAllClients(string message)
        {
            if (!Connected)
                return;
            if (!_isHost)
                return;

            for (int i = 0; i < _clients.Length; i++)
            {
                if (_clients[i].Connected)
                {
                    try
                    {
                        SendData(_clients[i], message,0);
                    }
                    catch
                    {

                    }
                }
            }
        }
        private void SendMessageToAllClientsExpectClient(string message,TcpClient cl)
        {
            if (!Connected)
                return;
            if (!_isHost)
                return;

            for (int i = 0; i < _clients.Length; i++)
            {
                if (_clients[i]!=cl)
                {
                    if (_clients[i].Connected)
                    {
                        try
                        {
                            SendData(_clients[i], message,0);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
        public void SendMessageToAClient(string message, TcpClient c)
        {
            SendData(c, message, 0);
        }
        

        private void StartListenClients()
        {
            while (true)
            {
                try
                {
                    TcpClient c = _TcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ThreadStart(() => HandleClient(ID, c)));
                    if (ClientConnected != null)
                    {
                        ClientConnected(c);
                    }
                    
                    _clientThreads=AddnewThreadToArray(clientThread, _clientThreads);
                    _clients=AddnewTcpClientToArray(c, _clients);
                    clientThread.Start();
                    ID++;
                }
                catch { }
            }

        }
        private void StartListenHost()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[MessageMaxLength];
                    HostClient.GetStream().Read(data, 0, data.Length);
                    data = ClearByteNulls(data);
                    if (data.Length == 0)
                    {
                        if (HostLost != null)
                        {
                            HostLost();
                        }
                        HostClient.Client.Disconnect(false);
                        Connected = false;
                        HostClient = new TcpClient();
                        break;
                    }
                    GettedMessageFromHost(Encoding.ASCII.GetString(data), HostClient);
                    
                }
                catch(Exception e) {
                    if (e.Message == "Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host.")
                    {
                        if (HostLost != null)
                        {
                            HostLost();
                        }
                        HostClient.Client.Disconnect(false);
                        Connected = false;
                        HostClient = new TcpClient();
                        break;
                    }
                }
            }
            return;
        }

        public void Stop()
        {
            if (!_isHost)
                return;

            for (int i = 0; i < _clientThreads.Length; i++)
            {
                try
                {
                    _clientThreads[i].Abort();
                }
                catch
                {

                }
            }
            _clientThreads = new Thread[0];
            for (int i = 0; i < _clients.Length; i++)
            {
                try
                {
                    _clients[i].GetStream().Close();
                    _clients[i].Close();
                }
                catch
                {

                }
            }
            _clients = new TcpClient[0];
            //_TcpListener.Server.Shutdown(SocketShutdown.Receive);
            _TcpListener.Stop();
            
            //_TcpListener.Server.Close();
            Listener.Abort();
            Listener = null;
            Connected = false;
        }
        public void Dissconnect()
        {
            if (!Connected)
                return;
            try
            {

                if (_isHost)
                    return;
                try
                {
                    ListenHost.Abort();
                }
                catch
                {

                }
                HostClient.GetStream().Close();
                try
                {
                    HostClient.Client.Disconnect(false);
                }
                catch
                {

                }
                HostClient.Close();
                Connected = false;
                HostClient = new TcpClient();
            }
            catch
            {

            }
        }

        private void HandleClient(int id, TcpClient c)
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[MessageMaxLength];
                    c.GetStream().Read(data, 0, data.Length);
                    data = ClearByteNulls(data);
                    if (data.Length == 0)
                    {
                        _clientThreads[id].Abort();
                        break;
                    }
                    GettedMessageFromClient(Encoding.ASCII.GetString(data), id, c);
                }
                catch
                {
                    if (ClientDissconnected != null)
                    {
                        ClientDissconnected(c);
                    }
                    
                    return;
                }
            }
            return;
        }


        #region Functions
        private Thread[] AddnewThreadToArray(Thread add, Thread[] _Array)
        {
            Thread[] c = new Thread[_Array.Length + 1];
            Array.Copy(_Array, c, _Array.Length);
            c[c.Length - 1] = add;
            return c;
        }
        private TcpClient[] AddnewTcpClientToArray(TcpClient add, TcpClient[] _Array)
        {
            TcpClient[] c = new TcpClient[_Array.Length + 1];
            Array.Copy(_Array, c, _Array.Length);
            c[c.Length - 1] = add;
            return c;
        }
        private byte[] ClearByteNulls(byte[] data)
        {
            List<byte> sh = new List<byte>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0)
                {
                    sh.Add(data[i]);
                }
            }
            return sh.ToArray();

        }


        private void GettedMessageFromClient(string p, int FromID,TcpClient c)
        {
            string cc = p.Substring(0, 1);
            string re = p.Substring(1, p.Length - 1);
            ReceivedMessagex(re, c);
            if (cc == "1")
            {
                SendMessageToAllClientsExpectClient(re, c);
            }
        }
        private void GettedMessageFromHost(string p,TcpClient c)
        {
            string cc = p.Substring(0, 1);
            string re = p.Substring(1, p.Length - 1);
            ReceivedMessagex(re,c);
        }


        private void DeleteClient(int id)
        {
            /*
            _clientThreads[id].Abort();
            try
            {
                _clients[id].Close();
            }
            catch { }
            _clients[id] = null;
            _clientThreads[id] = null;
             * */
        }
        private byte[] GetBytes(string str)
        {
            byte[] toBytes = Encoding.ASCII.GetBytes(str);
            return toBytes;
        }
        private string GetString(byte[] bytes)
        {
            string something = Encoding.ASCII.GetString(bytes);
            return something;
        }
        private void SendData(TcpClient c, string m,int statu)
        {
            byte[] datas = GetBytes(statu+m);
            c.GetStream().Write(datas, 0, datas.Length);
        }
        #endregion




    }
}
