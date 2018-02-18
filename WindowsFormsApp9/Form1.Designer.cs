namespace WindowsFormsApp9
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_host = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.cb_onlyhost = new System.Windows.Forms.CheckBox();
            this.btn_StartAccept = new System.Windows.Forms.Button();
            this.btn_StopAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(202, 340);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(223, 112);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(261, 24);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 3;
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(261, 50);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 20);
            this.txt_ip.TabIndex = 5;
            this.txt_ip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(261, 76);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 20);
            this.txt_port.TabIndex = 7;
            this.txt_port.Text = "1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // btn_host
            // 
            this.btn_host.Location = new System.Drawing.Point(304, 112);
            this.btn_host.Name = "btn_host";
            this.btn_host.Size = new System.Drawing.Size(58, 23);
            this.btn_host.TabIndex = 8;
            this.btn_host.Text = "Host";
            this.btn_host.UseVisualStyleBackColor = true;
            this.btn_host.Click += new System.EventHandler(this.btn_host_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(223, 364);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 9;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(12, 366);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(202, 20);
            this.txt_msg.TabIndex = 10;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(223, 141);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 11;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // cb_onlyhost
            // 
            this.cb_onlyhost.AutoSize = true;
            this.cb_onlyhost.Location = new System.Drawing.Point(223, 335);
            this.cb_onlyhost.Name = "cb_onlyhost";
            this.cb_onlyhost.Size = new System.Drawing.Size(72, 17);
            this.cb_onlyhost.TabIndex = 12;
            this.cb_onlyhost.Text = "Only Host";
            this.cb_onlyhost.UseVisualStyleBackColor = true;
            // 
            // btn_StartAccept
            // 
            this.btn_StartAccept.Location = new System.Drawing.Point(223, 170);
            this.btn_StartAccept.Name = "btn_StartAccept";
            this.btn_StartAccept.Size = new System.Drawing.Size(138, 23);
            this.btn_StartAccept.TabIndex = 13;
            this.btn_StartAccept.Text = "Start Accepting";
            this.btn_StartAccept.UseVisualStyleBackColor = true;
            this.btn_StartAccept.Click += new System.EventHandler(this.btn_StartAccept_Click);
            // 
            // btn_StopAccept
            // 
            this.btn_StopAccept.Location = new System.Drawing.Point(223, 199);
            this.btn_StopAccept.Name = "btn_StopAccept";
            this.btn_StopAccept.Size = new System.Drawing.Size(138, 23);
            this.btn_StopAccept.TabIndex = 14;
            this.btn_StopAccept.Text = "Stop Accepting";
            this.btn_StopAccept.UseVisualStyleBackColor = true;
            this.btn_StopAccept.Click += new System.EventHandler(this.btn_StopAccept_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 398);
            this.Controls.Add(this.btn_StopAccept);
            this.Controls.Add(this.btn_StartAccept);
            this.Controls.Add(this.cb_onlyhost);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_host);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "MultiThreaded ChatRoom - Jwstes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_host;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.CheckBox cb_onlyhost;
        private System.Windows.Forms.Button btn_StartAccept;
        private System.Windows.Forms.Button btn_StopAccept;
    }
}

