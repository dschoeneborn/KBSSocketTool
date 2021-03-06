﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KBSSocketTool
{
    public partial class Form1 : Form
    {
        private static IPAddress winKommIp = IPAddress.Parse("10.149.1.25");

        private static int rxdPort = 4099;
        private static int txdPort = 4100;

        private static IPEndPoint rxdEndpoint;
        private static IPEndPoint txdEndpoint;

        private static Socket rxdSocket;
        private static Socket txdSocket;

        private Thread rxdThread;
        private Thread txdThread;

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

            rxdThread = new Thread(StartRxd);
            txdThread = new Thread(StartTxd);

            rxdThread.Start();
            txdThread.Start();

            TbTelegram.Text = "00050001";
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

                    if(bytesRec > 0)
                    {
                        TbRxd.Invoke(new Action(() =>
                        {
                            String qTelegram = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                            TbRxd.AppendText(ReplaceSonder( qTelegram + Environment.NewLine + Environment.NewLine));

                            TbTelegram.Text = (Convert.ToInt16(qTelegram.Substring(1, 2)) + 1).ToString("00") + qTelegram.Substring(3, 6);

                            TbRxd.ScrollToCaret();
                        }));
                    }
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
                    int bytesRec = txdSocket.Receive(bytes);

                    String telegram = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if(bytesRec > 0)
                    {
                        TbTxd.Invoke(new Action(() =>
                        {
                            TbTxd.AppendText(ReplaceSonder(telegram) + Environment.NewLine);
                            TbTxd.ScrollToCaret();
                        }));

                        String qTelegram = QuittiereTelegram(telegram);

                        byte[] msg = Encoding.ASCII.GetBytes(qTelegram);

                        int bytesSent = txdSocket.Send(msg);

                        TbTxd.Invoke(new Action(() =>
                        {
                            TbTxd.AppendText(ReplaceSonder(qTelegram) + Environment.NewLine + Environment.NewLine);
                            TbTxd.ScrollToCaret();
                        }));
                    }
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
                String telegram = (char)0x02 + TbTelegram.Text + (char)0x03;
                byte[] msg = Encoding.ASCII.GetBytes(telegram);

                int bytesSent = rxdSocket.Send(msg);
                TbRxd.AppendText(ReplaceSonder(telegram) + Environment.NewLine);
                TbRxd.ScrollToCaret();

                TbTelegram.Text = "";
            }
            catch(Exception ex)
            {
                TbRxd.AppendText(Environment.NewLine + ex.Message);
                TbRxd.ScrollToCaret();
            }
            
        }

        private String ReplaceSonder(String a)
        {
            return a.Replace((char)0x02 + "", "<STX>").Replace((char)0x03 + "", "<ETX>").Replace((char)0x1B + "", "<ESC>");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            rxdThread.Abort();
            txdThread.Abort();
            // Release the socket.  
            rxdSocket.Shutdown(SocketShutdown.Both);
            rxdSocket.Close();

            txdSocket.Shutdown(SocketShutdown.Both);
            txdSocket.Close();
        }

        private void CmdInsertEsc_Click(object sender, EventArgs e)
        {
            TbTelegram.AppendText((char)0x1B + "");
        }
    }
}
