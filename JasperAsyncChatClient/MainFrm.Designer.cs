namespace JasperAsyncChatClient
{
    partial class MainFrm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버설정SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.채팅CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대화방RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.채팅CToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버설정SToolStripMenuItem,
            this.종료QToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일ToolStripMenuItem.Text = "파일(&F)";
            // 
            // 서버설정SToolStripMenuItem
            // 
            this.서버설정SToolStripMenuItem.Name = "서버설정SToolStripMenuItem";
            this.서버설정SToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.서버설정SToolStripMenuItem.Text = "서버 설정(&S)...";
            this.서버설정SToolStripMenuItem.Click += new System.EventHandler(this.서버설정SToolStripMenuItem_Click);
            // 
            // 종료QToolStripMenuItem
            // 
            this.종료QToolStripMenuItem.Name = "종료QToolStripMenuItem";
            this.종료QToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료QToolStripMenuItem.Text = "종료(&Q)...";
            // 
            // 채팅CToolStripMenuItem
            // 
            this.채팅CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.대화방RToolStripMenuItem});
            this.채팅CToolStripMenuItem.Name = "채팅CToolStripMenuItem";
            this.채팅CToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.채팅CToolStripMenuItem.Text = "채팅(&C)";
            // 
            // 대화방RToolStripMenuItem
            // 
            this.대화방RToolStripMenuItem.Name = "대화방RToolStripMenuItem";
            this.대화방RToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.대화방RToolStripMenuItem.Text = "대화방(&R)...";
            this.대화방RToolStripMenuItem.Click += new System.EventHandler(this.대화방RToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 377);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.Text = "네트워크 채팅";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서버설정SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 채팅CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대화방RToolStripMenuItem;
    }
}

