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
            this.SuspendLayout();
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(108, 112);
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
            this.CurrentStateIdLabel.Location = new System.Drawing.Point(124, 175);
            this.CurrentStateIdLabel.Name = "CurrentStateIdLabel";
            this.CurrentStateIdLabel.Size = new System.Drawing.Size(31, 12);
            this.CurrentStateIdLabel.TabIndex = 1;
            this.CurrentStateIdLabel.Text = "None";
            // 
            // GeroMachineSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}

