namespace GeroMachineSample
{
    partial class GeroMachineSampleForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.RunButton = new System.Windows.Forms.Button();
			this.CurrentStateIdLabel = new System.Windows.Forms.Label();
			this.Trigger1Button = new System.Windows.Forms.Button();
			this.Trigger2Button = new System.Windows.Forms.Button();
			this.Trigger3Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RunButton
			// 
			this.RunButton.Location = new System.Drawing.Point(93, 137);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(75, 23);
			this.RunButton.TabIndex = 0;
			this.RunButton.Text = "Run";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
			// 
			// CurrentStateIdLabel
			// 
			this.CurrentStateIdLabel.AutoSize = true;
			this.CurrentStateIdLabel.Location = new System.Drawing.Point(116, 179);
			this.CurrentStateIdLabel.Name = "CurrentStateIdLabel";
			this.CurrentStateIdLabel.Size = new System.Drawing.Size(31, 12);
			this.CurrentStateIdLabel.TabIndex = 1;
			this.CurrentStateIdLabel.Text = "None";
			// 
			// Trigger1Button
			// 
			this.Trigger1Button.Location = new System.Drawing.Point(12, 69);
			this.Trigger1Button.Name = "Trigger1Button";
			this.Trigger1Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger1Button.TabIndex = 2;
			this.Trigger1Button.Text = "Trigger1";
			this.Trigger1Button.UseVisualStyleBackColor = true;
			// 
			// Trigger2Button
			// 
			this.Trigger2Button.Location = new System.Drawing.Point(93, 69);
			this.Trigger2Button.Name = "Trigger2Button";
			this.Trigger2Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger2Button.TabIndex = 3;
			this.Trigger2Button.Text = "Trigger2";
			this.Trigger2Button.UseVisualStyleBackColor = true;
			// 
			// Trigger3Button
			// 
			this.Trigger3Button.Location = new System.Drawing.Point(174, 69);
			this.Trigger3Button.Name = "Trigger3Button";
			this.Trigger3Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger3Button.TabIndex = 4;
			this.Trigger3Button.Text = "Trigger3";
			this.Trigger3Button.UseVisualStyleBackColor = true;
			// 
			// GeroMachineSampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 218);
			this.Controls.Add(this.Trigger3Button);
			this.Controls.Add(this.Trigger2Button);
			this.Controls.Add(this.Trigger1Button);
			this.Controls.Add(this.CurrentStateIdLabel);
			this.Controls.Add(this.RunButton);
			this.Name = "GeroMachineSampleForm";
			this.Text = "GeroMachineSampleForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label CurrentStateIdLabel;
		private System.Windows.Forms.Button Trigger1Button;
		private System.Windows.Forms.Button Trigger2Button;
		private System.Windows.Forms.Button Trigger3Button;
	}
}

