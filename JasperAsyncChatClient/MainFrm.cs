/*
 *  Subject: JasperAsyncChatClient
    Author: Dodo / rabbit.white@daum.net
    Created Date: 2019-10-19
    FileName: MainFrm.cs
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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void 서버설정SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkSetting networkSettingFrm = new NetworkSetting();
            networkSettingFrm.Show();
        }

        private void 대화방RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsyncNetworkRoom asyncNetworkRoomFrm = new AsyncNetworkRoom();
            asyncNetworkRoomFrm.Show();
        }
    }
}
