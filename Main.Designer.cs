namespace LeagueDrafter
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Input_Name = new System.Windows.Forms.TextBox();
            this.Query_Button = new System.Windows.Forms.Button();
            this.Query_Output = new System.Windows.Forms.RichTextBox();
            this.Query_Bar = new System.Windows.Forms.ProgressBar();
            this.DebugInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Input_Name
            // 
            this.Input_Name.Location = new System.Drawing.Point(12, 12);
            this.Input_Name.Name = "Input_Name";
            this.Input_Name.PlaceholderText = "Input";
            this.Input_Name.Size = new System.Drawing.Size(317, 23);
            this.Input_Name.TabIndex = 0;
            this.Input_Name.Text = "XnipS";
            // 
            // Query_Button
            // 
            this.Query_Button.Location = new System.Drawing.Point(12, 41);
            this.Query_Button.Name = "Query_Button";
            this.Query_Button.Size = new System.Drawing.Size(75, 23);
            this.Query_Button.TabIndex = 2;
            this.Query_Button.Text = "Query";
            this.Query_Button.UseVisualStyleBackColor = true;
            this.Query_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Query_Output
            // 
            this.Query_Output.Location = new System.Drawing.Point(335, 12);
            this.Query_Output.Name = "Query_Output";
            this.Query_Output.Size = new System.Drawing.Size(237, 237);
            this.Query_Output.TabIndex = 3;
            this.Query_Output.Text = "";
            // 
            // Query_Bar
            // 
            this.Query_Bar.Location = new System.Drawing.Point(93, 41);
            this.Query_Bar.Name = "Query_Bar";
            this.Query_Bar.Size = new System.Drawing.Size(236, 23);
            this.Query_Bar.TabIndex = 4;
            this.Query_Bar.Value = 100;
            this.Query_Bar.Visible = false;
            // 
            // DebugInfo
            // 
            this.DebugInfo.Location = new System.Drawing.Point(12, 70);
            this.DebugInfo.Name = "DebugInfo";
            this.DebugInfo.Size = new System.Drawing.Size(317, 179);
            this.DebugInfo.TabIndex = 5;
            this.DebugInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.DebugInfo);
            this.Controls.Add(this.Query_Bar);
            this.Controls.Add(this.Query_Output);
            this.Controls.Add(this.Query_Button);
            this.Controls.Add(this.Input_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "League Drafter";
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Input_Name;
        private Button Query_Button;
        private RichTextBox Query_Output;
        private ProgressBar Query_Bar;
        private RichTextBox DebugInfo;
    }
}