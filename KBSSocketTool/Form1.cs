using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KBSSocketTool
{
    public partial class Form1 : Form
    {
        private static IPAddress winKommIp = IPAddress.Parse("10.149.11.250");

        private static int rxdPort = 4099;
        private static int txdPort = 4100;

        private static IPEndPoint rxdEndpoint;
        private static IPEndPoint txdEndpoint;

        private static Socket rxdSocket;
        private static Socket txdSocket;

        public Form1()
        {
            InitializeComponent();

            rxdEndpoint = new IPEndPoint(winKommIp, rxdPort);
            txdEndpoint = new IPEndPoint(winKommIp, txdPort);

            rxdSocket = new Socket(winKommIp.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            txdSocket = new Socket(winKommIp.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

            rxdSocket.Connect(rxdEndpoint);
            txdSocket.Connect(txdEndpoint);

            new Thread(StartRxd).Start();
            new Thread(StartTxd).Start();
        }

        public void StartRxd()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];
            while(true)
            {
                try
                {
                    int bytesRec = rxdSocket.Receive(bytes);

                    TbRxd.Text += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
        }

        public void StartTxd()
        {
            byte[] bytes = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRec = rxdSocket.Receive(bytes);

                    TbTxd.Text += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    String qTelegram = QuittiereTelegram(Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    byte[] msg = Encoding.ASCII.GetBytes(qTelegram);

                    int bytesSent = rxdSocket.Send(msg);
                    TbTxd.Text += Environment.NewLine + qTelegram;

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
        }

        private String QuittiereTelegram(String Telegram)
        {
            String qTelegram;

            qTelegram = (char)0x02 + Telegram.Substring(1, 8) + "QU" + (char)0x03;

            return qTelegram;
        }

        private void CmdSende_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] msg = Encoding.ASCII.GetBytes((char)0x02 + TbTelegram.Text + (char)0x03);

                int bytesSent = rxdSocket.Send(msg);
                TbRxd.Text += Environment.NewLine + TbTelegram.Text;
            }
            catch(Exception ex)
            {
                TbRxd.Text += Environment.NewLine + ex.Message;
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Release the socket.  
            rxdSocket.Shutdown(SocketShutdown.Both);
            rxdSocket.Close();
        }
    }
}
