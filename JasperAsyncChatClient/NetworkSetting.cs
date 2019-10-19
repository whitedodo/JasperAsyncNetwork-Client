/*
 *  Subject: JasperAsyncChatClient
    Author: Dodo / rabbit.white@daum.net
    Created Date: 2019-10-19
    FileName: NetworkSetting.cs
    Description:

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JasperAsyncChatClient
{
    public partial class NetworkSetting : Form
    {
        public NetworkSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = "serverInfo.txt";
            string savePath = Application.StartupPath + @"\\" + fileName;
            string ipaddress = txtIPAddress.Text;
            string port = txtPort.Text;
            string nickname = txtNickname.Text;

            string memo = ipaddress + Environment.NewLine +
                          port + Environment.NewLine +
                          nickname + Environment.NewLine;

            System.IO.File.WriteAllText(savePath, memo, Encoding.UTF8);
        }

        private void NetworkSetting_Load(object sender, EventArgs e)
        {
            getServerInfo();
        }

        private void getServerInfo()
        {
            string fileName = "serverInfo.txt";
            string savePath = Application.StartupPath + @"\\" + fileName;

            string[] textValue = System.IO.File.ReadAllLines(savePath);

            if (textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {
                    switch (i)
                    {
                        // 아이피주소
                        case 0:
                            txtIPAddress.Text = textValue[i];
                            break;

                        // 포트
                        case 1:
                            txtPort.Text = textValue[i];
                            break;

                        // 닉네임
                        case 2:
                            txtNickname.Text = textValue[i];
                            break;

                        default:
                            break;

                    } // end of switch

                } // end of for

            } // end of if

        }
        
    }
    
}
