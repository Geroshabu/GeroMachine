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
			this.Trigger1Button = new System.Windows.Forms.Button();
			this.Trigger2Button = new System.Windows.Forms.Button();
			this.Trigger3Button = new System.Windows.Forms.Button();
			this.CurrentStateNameTitleLabel = new System.Windows.Forms.Label();
			this.CurrentStateNameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Trigger1Button
			// 
			this.Trigger1Button.Location = new System.Drawing.Point(12, 69);
			this.Trigger1Button.Name = "Trigger1Button";
			this.Trigger1Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger1Button.TabIndex = 2;
			this.Trigger1Button.Text = "Trigger1";
			this.Trigger1Button.UseVisualStyleBackColor = true;
			this.Trigger1Button.Click += new System.EventHandler(this.Trigger1Button_Click);
			// 
			// Trigger2Button
			// 
			this.Trigger2Button.Location = new System.Drawing.Point(93, 69);
			this.Trigger2Button.Name = "Trigger2Button";
			this.Trigger2Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger2Button.TabIndex = 3;
			this.Trigger2Button.Text = "Trigger2";
			this.Trigger2Button.UseVisualStyleBackColor = true;
			this.Trigger2Button.Click += new System.EventHandler(this.Trigger2Button_Click);
			// 
			// Trigger3Button
			// 
			this.Trigger3Button.Location = new System.Drawing.Point(174, 69);
			this.Trigger3Button.Name = "Trigger3Button";
			this.Trigger3Button.Size = new System.Drawing.Size(75, 23);
			this.Trigger3Button.TabIndex = 4;
			this.Trigger3Button.Text = "Trigger3";
			this.Trigger3Button.UseVisualStyleBackColor = true;
			this.Trigger3Button.Click += new System.EventHandler(this.Trigger3Button_Click);
			// 
			// CurrentStateNameTitleLabel
			// 
			this.CurrentStateNameTitleLabel.AutoSize = true;
			this.CurrentStateNameTitleLabel.Location = new System.Drawing.Point(34, 109);
			this.CurrentStateNameTitleLabel.Name = "CurrentStateNameTitleLabel";
			this.CurrentStateNameTitleLabel.Size = new System.Drawing.Size(113, 12);
			this.CurrentStateNameTitleLabel.TabIndex = 5;
			this.CurrentStateNameTitleLabel.Text = "Current State Name :";
			// 
			// CurrentStateNameLabel
			// 
			this.CurrentStateNameLabel.AutoSize = true;
			this.CurrentStateNameLabel.Location = new System.Drawing.Point(154, 109);
			this.CurrentStateNameLabel.Name = "CurrentStateNameLabel";
			this.CurrentStateNameLabel.Size = new System.Drawing.Size(0, 12);
			this.CurrentStateNameLabel.TabIndex = 6;
			// 
			// GeroMachineSampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 218);
			this.Controls.Add(this.CurrentStateNameLabel);
			this.Controls.Add(this.CurrentStateNameTitleLabel);
			this.Controls.Add(this.Trigger3Button);
			this.Controls.Add(this.Trigger2Button);
			this.Controls.Add(this.Trigger1Button);
			this.Name = "GeroMachineSampleForm";
			this.Text = "GeroMachineSampleForm";
			this.Load += new System.EventHandler(this.GeroMachineSampleForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.Button Trigger1Button;
		private System.Windows.Forms.Button Trigger2Button;
		private System.Windows.Forms.Button Trigger3Button;
		private System.Windows.Forms.Label CurrentStateNameTitleLabel;
		private System.Windows.Forms.Label CurrentStateNameLabel;
	}
}

