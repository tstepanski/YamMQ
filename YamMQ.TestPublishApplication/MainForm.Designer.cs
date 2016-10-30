namespace YamMQ.TestPublishApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.PublishUrlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageTypeDefinitionTextBox = new System.Windows.Forms.TextBox();
            this.PublishButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GetTemplateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publish Message Url";
            // 
            // PublishUrlTextBox
            // 
            this.PublishUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PublishUrlTextBox.Location = new System.Drawing.Point(12, 25);
            this.PublishUrlTextBox.Name = "PublishUrlTextBox";
            this.PublishUrlTextBox.Size = new System.Drawing.Size(265, 20);
            this.PublishUrlTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message Type Definition";
            // 
            // MessageTypeDefinitionTextBox
            // 
            this.MessageTypeDefinitionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTypeDefinitionTextBox.Location = new System.Drawing.Point(12, 64);
            this.MessageTypeDefinitionTextBox.Multiline = true;
            this.MessageTypeDefinitionTextBox.Name = "MessageTypeDefinitionTextBox";
            this.MessageTypeDefinitionTextBox.Size = new System.Drawing.Size(265, 145);
            this.MessageTypeDefinitionTextBox.TabIndex = 3;
            // 
            // PublishButton
            // 
            this.PublishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PublishButton.Location = new System.Drawing.Point(202, 215);
            this.PublishButton.Name = "PublishButton";
            this.PublishButton.Size = new System.Drawing.Size(75, 23);
            this.PublishButton.TabIndex = 4;
            this.PublishButton.Text = "Publish";
            this.PublishButton.UseVisualStyleBackColor = true;
            this.PublishButton.Click += new System.EventHandler(this.PublishButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(121, 215);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GetTemplateButton
            // 
            this.GetTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GetTemplateButton.Location = new System.Drawing.Point(12, 215);
            this.GetTemplateButton.Name = "GetTemplateButton";
            this.GetTemplateButton.Size = new System.Drawing.Size(103, 23);
            this.GetTemplateButton.TabIndex = 6;
            this.GetTemplateButton.Text = "Get Template";
            this.GetTemplateButton.UseVisualStyleBackColor = true;
            this.GetTemplateButton.Click += new System.EventHandler(this.GetTemplateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 250);
            this.Controls.Add(this.GetTemplateButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PublishButton);
            this.Controls.Add(this.MessageTypeDefinitionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PublishUrlTextBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(305, 288);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "YamMQ Publish Message Test Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PublishUrlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MessageTypeDefinitionTextBox;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button GetTemplateButton;
    }
}

