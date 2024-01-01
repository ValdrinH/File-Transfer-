using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileTransferApplication
{
    public partial class Form1 : Form
    {
        private string IP = "127.0.0.1";
        TcpListener listener;
        TcpClient client;
        Socket socketForClient;
        private Thread serverThread;
        private Thread findPC;

        int flag = 0;
        string fileName = "";
        private bool serverRunning = false;
        private bool isConnected = false;
        int x = 9;
        int y = 308;
        int fileReceived = 0;
        string savePath;
        string senderIP;
        string senderMachineName;
        string targetIP;
        string targetName;

        public Form1()
        {
            InitializeComponent();
        }
        //for starting this program as a server
        void startServer()
        {
            try
            {
                serverRunning = true;
                listener = new TcpListener(IPAddress.Parse(IP), 11000);
                listener.Start();
                serverThread = new Thread(new ThreadStart(serverTasks));
                serverThread.Start();
                while (!serverThread.IsAlive) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void serverTasks()
        {
            try
            {
                while (true)
                {
                    if (fileReceived == 1)
                    {
                        if (MessageBox.Show("Save File?", "File received", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            File.Delete(savePath);
                            fileReceived = 0;
                        }
                        else
                        {
                            fileReceived = 0;
                        }
                    }

                    client = listener.AcceptTcpClient();
                    Invoke((MethodInvoker)delegate
                    {
                        MessagesFromHost.Text += "File coming..." + "\n" + fileName + "\n" + "From: " + senderIP + " " + senderMachineName + "\n";
                        MessagesFromHost.Text += "File Coming from " + senderIP + " " + senderMachineName + "\n\n";
                    });
                    isConnected = true;
                    NetworkStream stream = client.GetStream();
                    textProgressBar.Visible = true;
                    if (flag == 1 && isConnected)
                    {
                        savePath = savePathLabel.Text + "\\" + fileName;
                        long fileSize = stream.Length;  // Madhësia e file-it që po pranohet
                        long totalBytesReceived = 0;

                        using (var output = File.Create(savePath))
                        {
                            // read the file divided by 1KB
                            var buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                output.Write(buffer, 0, bytesRead);
                                totalBytesReceived += bytesRead;
                                // Llogarit përqindjen e përparimit
                                int progressPercentage = (int)((totalBytesReceived * 100) / fileSize);

                                // Azhurno progress bar-in me përqindjen e re të përparimit
                                Invoke((MethodInvoker)delegate
                                {
                                    SetValuePorgress(progressPercentage, false);
                                });
                            }
                            //MessageBox.Show("ok");
                            flag = 0;
                            client.Close();
                            isConnected = false;
                            fileName = "";
                            Invoke((MethodInvoker)delegate
                            {
                                MessagesFromHost.Text += "\n ...";
                            });
                            fileReceived = 1;
                        }
                    }
                    else if (flag == 0 && isConnected)
                    {
                        Byte[] bytes = new Byte[256];
                        String data = null;
                        int i;
                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        }
                        string[] msg = data.Split('@');
                        fileName = msg[0];
                        senderIP = msg[1];
                        senderMachineName = msg[2];
                        client.Close();
                        isConnected = false;
                        flag = 1;
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                flag = 0;
                isConnected = false;
                if (client != null)
                    client.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //searchPC();
            try
            {
                findPC = new Thread(new ThreadStart(searchPC));
                findPC.Start();
                while (!findPC.IsAlive) ;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        void searchPC()
        {
            bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkUp)
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        this.IP = ip.ToString();
                    }
                }
                Invoke((MethodInvoker)delegate
                {
                    MessagesFromHost.Text += "--------This Computer: " + this.IP + "--------\n";
                });
                string[] ipRange = IP.Split('.');
                for (int i = 100; i < 255; i++)
                {
                    Ping ping = new Ping();
                    //string testIP = "192.168.1.67";
                    string testIP = ipRange[0] + '.' + ipRange[1] + '.' + ipRange[2] + '.' + i.ToString();
                    if (testIP != this.IP)
                    {
                        ping.PingCompleted += new PingCompletedEventHandler(pingCompletedEvent);
                        ping.SendAsync(testIP, 100, testIP);
                    }
                }

                Invoke((MethodInvoker)delegate
                {
                    notificationLabel.ForeColor = Color.Green;
                    notificationLabel.Text = "Application is Online";
                });
                //Starting this program as a server.
                if (!serverRunning)
                    startServer();
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    notificationLabel.ForeColor = Color.Red;
                    notificationLabel.Text = "Application is Offline";
                });
                MessageBox.Show("Not connected to LAN");
            }
        }
        //for searching online computers
        void pingCompletedEvent(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply.Status == IPStatus.Success)
            {
                string name;
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                    name = hostEntry.HostName;
                }
                catch (SocketException ex)
                {
                    name = ex.Message;
                }
                Invoke((MethodInvoker)delegate
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ip;
                    item.SubItems.Add(name);
                    onlinePCList.Items.Add(item);
                });
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNameLabel.Text = openFileDialog1.FileName;  //file path
                fileNameLabel.Tag = openFileDialog1.SafeFileName; //file name only.
                MessagesFromHost.Text += "File :" + openFileDialog1.SafeFileName + "\n";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (serverRunning)
            {
                serverRunning = false;
                onlinePCList.Items.Clear();
                if (listener != null)
                    listener.Stop();
                if (serverThread != null)
                {
                    serverThread.Join();
                }

                MessagesFromHost.Text = "";
                notificationLabel.ForeColor = Color.Red;
                notificationLabel.Text = "Application is Offline";
                infoLabel.Text = "";
                fileNameLabel.Text = ".";
            }
        }

        private void SendFiles(object sender, EventArgs e)
        {
            if (onlinePCList.SelectedIndices.Count > 0 && serverRunning && fileNameLabel.Text != ".")
            {
                targetIP = onlinePCList.SelectedItems[0].Text;
                targetName = onlinePCList.SelectedItems[0].SubItems[1].Text;
                try
                {
                    Ping p = new Ping();
                    PingReply r;
                    r = p.Send(targetIP);
                    if (!(r.Status == IPStatus.Success))
                    {
                        MessageBox.Show("Target computer is not available.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        MessagesFromHost.Text += "\nWarning\nPlease don't do other tasks. File sending to " + targetIP + " " + targetName + "...";
                        //closing the server
                        listener.Stop();
                        serverThread.Join();
                        serverRunning = false;
                        //now making this program a client
                        socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));
                        string fileName = fileNameLabel.Tag.ToString();
                        //long fileSize = new FileInfo(fileNameLabel.Text).Length;
                        byte[] fileNameData = Encoding.Default.GetBytes(fileName + "@" + this.IP + "@" + Environment.MachineName);
                        socketForClient.Send(fileNameData);
                        socketForClient.Shutdown(SocketShutdown.Both);
                        socketForClient.Close();


                        socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));
                        socketForClient.SendFile(fileNameLabel.Text);

                        textProgressBar.Visible = true;

                        long fileSize = new FileInfo(fileNameLabel.Text).Length;
                        long totalBytesSent = 0;
                        using (FileStream fileStream = new FileStream(fileNameLabel.Text, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;

                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                socketForClient.Send(buffer, 0, bytesRead, SocketFlags.None);
                                totalBytesSent += bytesRead;

                                // Calculate and display progress as a percentage
                                int progressPercentage = (int)((totalBytesSent * 100) / fileSize);
                                SetValuePorgress(progressPercentage,true);
                            }
                        }

                        socketForClient.Shutdown(SocketShutdown.Both);
                        socketForClient.Close();

                        MessageBox.Show("File sent to " + targetIP + " " + targetName, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (socketForClient != null)
                    {
                        socketForClient.Close();
                        socketForClient.Shutdown(SocketShutdown.Both);
                    }
                }
                finally
                {
                    for (int i = 0; i < onlinePCList.SelectedIndices.Count; i++)
                    {
                        onlinePCList.Items[this.onlinePCList.SelectedIndices[i]].Selected = false;
                    }
                    //again making this program a server
                    startServer();
                }
            }
        }
        void SetValuePorgress(int progressPercentage,bool isDeliver)
        {
            if (textProgressBar.Value == 100)
            {
                textProgressBar.Value = 100;
                return;
            }

            textProgressBar.Value = progressPercentage;
            if (textProgressBar.Value > 0 && textProgressBar.Value < 50)
            {
                textProgressBar.CustomText = (isDeliver)?"Files are being sent...":"Files are being accepted...";
            }
            else if (textProgressBar.Value >= 80 && textProgressBar.Value <= 90)
            {
                textProgressBar.CustomText = "Processing almost complete!";
            }
            else if (textProgressBar.Value >= 100)
            {
                textProgressBar.CustomText = (isDeliver)?"Files sent successfully!": "Files Accepted successfully!";
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 5)
                    {
                        textProgressBar.Visible = false;
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            if (browse.ShowDialog() == DialogResult.OK)
            {
                string savePath = browse.SelectedPath;
                savePathLabel.Text = savePath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serverRunning)
            {
                if (listener != null)
                    listener.Stop();
                if (serverThread != null)
                {
                    serverThread.Join();
                }

            }
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fileNameLabel.Text = ".";
            timer1.Stop();
        }

        private void Form1_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //before existing everything is closed.
            if (serverRunning)
            {
                listener.Stop();
                if (serverThread != null)
                {
                    serverThread.Join();
                }

            }
        }

        private void ClearMessages(object sender, EventArgs e)
        {
            MessagesFromHost.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}