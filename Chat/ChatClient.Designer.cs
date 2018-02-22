namespace Chat {
    partial class ChatClient {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.buttSend = new System.Windows.Forms.Button();
            this.messBox = new System.Windows.Forms.TextBox();
            this.nickName = new System.Windows.Forms.TextBox();
            this.buttConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chatMessages = new System.Windows.Forms.TextBox();
            this.buttDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttSend
            // 
            this.buttSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttSend.Location = new System.Drawing.Point(304, 335);
            this.buttSend.Name = "buttSend";
            this.buttSend.Size = new System.Drawing.Size(101, 82);
            this.buttSend.TabIndex = 0;
            this.buttSend.Text = "Send";
            this.buttSend.UseVisualStyleBackColor = true;
            this.buttSend.Click += new System.EventHandler(this.buttSend_Click);
            // 
            // messBox
            // 
            this.messBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messBox.Location = new System.Drawing.Point(13, 335);
            this.messBox.Multiline = true;
            this.messBox.Name = "messBox";
            this.messBox.Size = new System.Drawing.Size(282, 82);
            this.messBox.TabIndex = 1;
            // 
            // nickName
            // 
            this.nickName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nickName.Location = new System.Drawing.Point(73, 306);
            this.nickName.Name = "nickName";
            this.nickName.Size = new System.Drawing.Size(120, 20);
            this.nickName.TabIndex = 2;
            // 
            // buttConnect
            // 
            this.buttConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttConnect.Location = new System.Drawing.Point(199, 304);
            this.buttConnect.Name = "buttConnect";
            this.buttConnect.Size = new System.Drawing.Size(99, 23);
            this.buttConnect.TabIndex = 3;
            this.buttConnect.Text = "Connect";
            this.buttConnect.UseVisualStyleBackColor = true;
            this.buttConnect.Click += new System.EventHandler(this.buttConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nickname";
            // 
            // chatMessages
            // 
            this.chatMessages.AcceptsReturn = true;
            this.chatMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatMessages.Location = new System.Drawing.Point(13, 13);
            this.chatMessages.Multiline = true;
            this.chatMessages.Name = "chatMessages";
            this.chatMessages.ReadOnly = true;
            this.chatMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatMessages.Size = new System.Drawing.Size(390, 285);
            this.chatMessages.TabIndex = 5;
            // 
            // buttDisconnect
            // 
            this.buttDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttDisconnect.Location = new System.Drawing.Point(304, 304);
            this.buttDisconnect.Name = "buttDisconnect";
            this.buttDisconnect.Size = new System.Drawing.Size(99, 23);
            this.buttDisconnect.TabIndex = 6;
            this.buttDisconnect.Text = "Disconnect";
            this.buttDisconnect.UseVisualStyleBackColor = true;
            this.buttDisconnect.Click += new System.EventHandler(this.buttDisconnect_Click);
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 429);
            this.Controls.Add(this.buttDisconnect);
            this.Controls.Add(this.chatMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttConnect);
            this.Controls.Add(this.nickName);
            this.Controls.Add(this.messBox);
            this.Controls.Add(this.buttSend);
            this.Name = "ChatClient";
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttSend;
        private System.Windows.Forms.TextBox messBox;
        private System.Windows.Forms.TextBox nickName;
        private System.Windows.Forms.Button buttConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chatMessages;
        private System.Windows.Forms.Button buttDisconnect;
    }
}

