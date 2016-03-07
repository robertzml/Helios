namespace Helios.Test.ClientForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonParse = new System.Windows.Forms.Button();
            this.textBoxMessageOutput = new System.Windows.Forms.TextBox();
            this.buttonHeartBeat = new System.Windows.Forms.Button();
            this.buttonReport2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(56, 93);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(328, 121);
            this.textBoxMessage.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(56, 35);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(119, 33);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(56, 261);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(87, 31);
            this.buttonParse.TabIndex = 4;
            this.buttonParse.Text = "报文解析";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // textBoxMessageOutput
            // 
            this.textBoxMessageOutput.Location = new System.Drawing.Point(56, 308);
            this.textBoxMessageOutput.Multiline = true;
            this.textBoxMessageOutput.Name = "textBoxMessageOutput";
            this.textBoxMessageOutput.Size = new System.Drawing.Size(328, 131);
            this.textBoxMessageOutput.TabIndex = 5;
            // 
            // buttonHeartBeat
            // 
            this.buttonHeartBeat.Location = new System.Drawing.Point(201, 261);
            this.buttonHeartBeat.Name = "buttonHeartBeat";
            this.buttonHeartBeat.Size = new System.Drawing.Size(87, 31);
            this.buttonHeartBeat.TabIndex = 6;
            this.buttonHeartBeat.Text = "心跳解析";
            this.buttonHeartBeat.UseVisualStyleBackColor = true;
            this.buttonHeartBeat.Click += new System.EventHandler(this.buttonHeartBeat_Click);
            // 
            // buttonReport2
            // 
            this.buttonReport2.Location = new System.Drawing.Point(349, 261);
            this.buttonReport2.Name = "buttonReport2";
            this.buttonReport2.Size = new System.Drawing.Size(84, 31);
            this.buttonReport2.TabIndex = 7;
            this.buttonReport2.Text = "上报解析2";
            this.buttonReport2.UseVisualStyleBackColor = true;
            this.buttonReport2.Click += new System.EventHandler(this.buttonReport2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 476);
            this.Controls.Add(this.buttonReport2);
            this.Controls.Add(this.buttonHeartBeat);
            this.Controls.Add(this.textBoxMessageOutput);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonSend);
            this.Name = "MainForm";
            this.Text = "客户端测试";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.TextBox textBoxMessageOutput;
        private System.Windows.Forms.Button buttonHeartBeat;
        private System.Windows.Forms.Button buttonReport2;
    }
}

