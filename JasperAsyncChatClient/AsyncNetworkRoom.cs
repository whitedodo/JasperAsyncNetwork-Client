/*
 *  Subject: JasperAsyncChatClient
    Author: Dodo / rabbit.white@daum.net
    Created Date: 2019-10-19
    FileName: AsyncNetworkRoom.cs
    Description:

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JasperAsyncChatClient
{
    public partial class AsyncNetworkRoom : Form
    {
        private static string ipAddress;
        private static int port;
        private static string nickname;

        // ManualResetEvent 인스턴스 신호 완료.(ManualResetEvent instances signal completion.)
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // 원격 장치의 응답입니다.(The response from the remote device.)
        private static String response = String.Empty;

        public AsyncNetworkRoom()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        private void AsyncNetworkRoom_Load(object sender, EventArgs e)
        {
            getServerInfo();
        }

        private void getServerInfo()
        {
            string fileName = "serverInfo.txt";
            string savePath = Application.StartupPath + @"\\" + fileName;

            string[] textValue = System.IO.File.ReadAllLines(savePath);

            if ( textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {
                    switch (i)
                    {
                        // 아이피주소
                        case 0:
                            ipAddress = textValue[i];
                            break;

                        // 포트
                        case 1:
                            port = Convert.ToInt32(textValue[i]);
                            break;

                        // 닉네임
                        case 2:
                            nickname = textValue[i];
                            break;

                        default:
                            break;

                    } // end of switch

                } // end of for

            } // end of if


        }

        private void StartClient()
        {
            string txtMemo = txtSend.Text;
            string txtResponse = "";

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the   
                // remote device is "host.contoso.com".  
                //IPHostEntry ipHostInfo = Dns.GetHostEntry("host.contoso.com");
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                //IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                // Create a TCP/IP socket.  
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // 테스트 데이터를 원격 장치로 보냅니다.(Send test data to the remote device.)

                //Send(client, "This is a test<EOF>");
                Send(client, txtMemo + "<EOF>");
                sendDone.WaitOne();

                // 원격 장치로부터 응답을 받습니다.(Receive the response from the remote device.)
                Receive(client);
                receiveDone.WaitOne();

                // 콘솔에 응답을 작성하십시오.(Write the response to the console.)
                //Console.WriteLine("Response received : {0}", response);

                /*
                txtMessages.Text = "응답 받았음(Response received) : " + response +
                                    Environment.NewLine + txtMessages.Text;
                */

                txtResponse = response;

                txtMessages.Text = txtResponse + Environment.NewLine + txtResponse;

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "메시지(Messages)");
                MessageBox.Show("오류 발생으로 인하여 클라이언트를 강제종료합니다.\n" +
                                "(Aborting the client due to an error.)", "메시지(Messages)");
                //Console.WriteLine(e.ToString());
                Application.ExitThread();
                Environment.Exit(0);

            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // 상태 객체에서 소켓을 가져옵니다.(Retrieve the socket from the state object.)
                Socket client = (Socket)ar.AsyncState;

                // 연결을 완료하십시오.(Complete the connection.)  
                client.EndConnect(ar);

                /*
                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());
                */

                txtMessages.Text = "소켓 연결(Socket connected to) " + client.RemoteEndPoint.ToString() +
                    Environment.NewLine + txtMessages.Text;

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "메시지(Messages)");
                MessageBox.Show("오류 발생으로 인하여 클라이언트를 강제종료합니다.\n" +
                                "(Aborting the client due to an error.)", "메시지(Messages)");
                //Console.WriteLine(e.ToString());
                Application.ExitThread();
                Environment.Exit(0);

            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject
                {
                    workSocket = client
                };

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "메시지(Messages)");
                MessageBox.Show("오류 발생으로 인하여 클라이언트를 강제종료합니다.\n" +
                                "(Aborting the client due to an error.)", "메시지(Messages)");
                //Console.WriteLine(e.ToString());
                Application.ExitThread();
                Environment.Exit(0);

            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "메시지(Messages)");
                MessageBox.Show("오류 발생으로 인하여 클라이언트를 강제종료합니다.\n" +
                                "(Aborting the client due to an error.)", "메시지(Messages)");
                //Console.WriteLine(e.ToString());
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

        private void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                /* txtMessages.Text = "Sent " + bytesSent + "bytes to server." +
                                    Environment.NewLine + txtMessages.Text;
                */

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "메시지(Messages)");
                MessageBox.Show("오류 발생으로 인하여 클라이언트를 강제종료합니다.\n" +
                                "(Aborting the client due to an error.)", "메시지(Messages)");
                //Console.WriteLine(e.ToString());
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

}
