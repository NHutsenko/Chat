using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.IO;

namespace Chat {
    public partial class ChatClient : Form {
        /*!
         * \private using for sending message by UDP protocol
         */
        private UdpClient udpClient;
        /*!
         * \private using for recieving message by UDP protocol
         */
        private UdpClient client;
        /*!
         * \private using for create a sender IP adress for chat client
         */
        private IPAddress multiCastAddress;
        /*!
         * \private using for create endpoint by IP adress and port
         */
        private IPEndPoint remoteEp;
        /*!
         * \private num of port for sending messages
         */
        private const int HOST = 2222;
        /*!
         * \private using for check user online or not
         */
        private bool alive;
        /*!
         * \private using for save usename
         */
        private string userName;
        public ChatClient() {
            InitializeComponent();
            buttDisconnect.Enabled = false;
            buttSend.Enabled = false;
            messBox.ReadOnly = true;
            alive = false;
        }

        /*!
         * \private EventHandler for form closing.
         * Does user closed the window?, if it's true, automatticaly disconnect from chat
         */
        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e) {
            DisconnectFromChat();
        }
        /*!
         * \private EventHandler for connect to chat.
         * Does user clicked to connect button? If it's true, save username and use Connect method
         */
        private void buttConnect_Click(object sender, EventArgs e) {
            try {
                if (nickName.Text == "" || nickName.Text == null) {
                    throw new Exception("You didn't write a nickname");
                } else if (nickName.Text.Length < 4) {
                    throw new Exception("Your nickname less than 4 symbols");
                }
                userName = nickName.Text;
                ConnectToChat();
                alive = true;
                Thread ListenStart = new Thread(new ThreadStart(Listen));
                ListenStart.Start();
                buttDisconnect.Enabled = true;
                buttConnect.Enabled = false;
                messBox.ReadOnly = false;
                nickName.ReadOnly = true;
                buttSend.Enabled = true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }
        /*!
         * \private EventHandler for disconnect from chat.
         * Does user clicked to disconnect button? If it's true, use Disconnect method
         */
        private void buttDisconnect_Click(object sender, EventArgs e) {
            DisconnectFromChat();
            nickName.ReadOnly = false;
            buttDisconnect.Enabled = false;
            buttSend.Enabled = false;
            messBox.ReadOnly = true;
            buttConnect.Enabled = true;
        }
        /*!
         * \private EventHandler for send messages button.
         * Does user clicked to send button? If it's true, use Send Message method
         */
        private void buttSend_Click(object sender, EventArgs e) {
            try {
                if (messBox.Text == "" || messBox.Text == null) {
                    throw new Exception("You didn't write ane message");
                }
                SendMessage(messBox.Text);
                messBox.Clear();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        /*!
         * \private Listen method.
         * Using for create a new UdpClient on free IP adress, and add him to listen group.
         * After that start recieve messages.
         */
        private void Listen() {
            try {
                client = new UdpClient { ExclusiveAddressUse = false };
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);

                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.ExclusiveAddressUse = false;

                client.Client.Bind(localEp);

                client.JoinMulticastGroup(multiCastAddress);
                while (alive) {
                    Byte[] data = client.Receive(ref localEp);
                    string message = Decrypt(data);
                    this.Invoke(new MethodInvoker(() => {
                        string time = DateTime.Now.ToShortTimeString();
                        chatMessages.AppendText(time + " " + message + Environment.NewLine);
                    }));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*!
         * \private Send method.
         * Using for create a message and send to other users in multicast group.
         */
        private void SendMessage(string message) {
            try {
                string formattedMesage = String.Format("{0} : {1}", userName, message);
                byte[] buffer = Encrypt(formattedMesage);
                udpClient.Send(buffer, buffer.Length, remoteEp);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*!
         * \private Disconnect method.
         * Using for stop listen method and drop user from multicast group.
         */
        private void DisconnectFromChat() {
            alive = false;
            SendMessage("disconnected from this chanel");
            client.DropMulticastGroup(multiCastAddress);
            client.Close();
        }
        /*!
         * \private Conenct method.
         * Using for add user to multicast group.
         */
        private void ConnectToChat() {
            multiCastAddress = IPAddress.Parse("239.0.0.222"); // one of reserved for local using UDP adress
            udpClient = new UdpClient();
            udpClient.JoinMulticastGroup(multiCastAddress);
            remoteEp = new IPEndPoint(multiCastAddress, HOST);
            SendMessage("connected to this chanel");
        }
        /*!
         * \private Encrypt method.
         * Using for create encrypted message by AES crypt manager.
         */
        private byte[] Encrypt(string clearText, string EncryptionKey = "123") {

            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            byte[] encrypted;
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }); // еще один плюс шарпа в наличие таких вот костылей.
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encrypted = ms.ToArray();
                }
            }
            return encrypted;
        }
        /*!
        * \private Decrypt method.
        * Using for create encrypted message by AES crypt manager.
        */
        private string Decrypt(byte[] cipherBytes, string EncryptionKey = "123") {
            string cipherText = "";
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)) {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
