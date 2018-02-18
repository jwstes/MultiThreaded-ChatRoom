using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Socket;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        SocketManager Socket = new SocketManager(2048, 000);

        public Form1()
        {
            InitializeComponent();

            Socket.ClientConnected += Socket_ClientConnected;
            Socket.ClientDissconnected += Socket_ClientDissconnected;
            Socket.ConnectedServer += Socket_ConnectedServer;
            Socket.HostLost += Socket_HostLost;
            Socket.HostRefused += Socket_HostRefused;
            Socket.ReceivedMessage += Socket_ReceivedMessage;
        }

        void EnterLog(string ms)
        {
            richTextBox1.Text += ms + "\n";
        }

        private void Socket_ReceivedMessage(string Message, System.Net.Sockets.TcpClient FromClient)
        {
            EnterLog(Message);
        }

        private void Socket_HostRefused()
        {
            EnterLog("Server has refused you");
        }

        private void Socket_HostLost()
        {
            EnterLog("Host lost");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Socket_ConnectedServer()
        {
            EnterLog("Connected to server");
        }

        void Socket_ClientDissconnected(System.Net.Sockets.TcpClient Client)
        {
            EnterLog("A client isconnected from server");
        }

        void Socket_ClientConnected(System.Net.Sockets.TcpClient Client)
        {
            EnterLog("A client has connected");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Socket.Stop();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Socket.Dissconnect();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (Socket._isHost)
            {
                Socket.SendMessageToAllClients(txt_name.Text + " : " + txt_msg.Text);
            }
            else
            {
                if (cb_onlyhost.Checked)
                {
                    Socket.SendMessageToHost(txt_name.Text + " : " + txt_msg.Text);
                }
                else
                {
                    Socket.SendMessageToHostAndAllClients(txt_name.Text + " : " + txt_msg.Text);
                }
            }

            EnterLog("You : " + txt_msg.Text);
            txt_msg.Text = "";
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Socket.Port = Convert.ToInt32(txt_port.Text);
            Socket.Connect(txt_ip.Text);
        }

        private void btn_host_Click(object sender, EventArgs e)
        {
            Socket.Port = Convert.ToInt32(txt_port.Text);
            Socket.Host();
            Socket.StartLisenClients();
        }

        private void btn_StartAccept_Click(object sender, EventArgs e)
        {
            Socket.StartLisenClients();
        }

        private void btn_StopAccept_Click(object sender, EventArgs e)
        {
            Socket.StopLisenClients();
        }
    }
}
