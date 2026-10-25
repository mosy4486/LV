namespace LVController
{
    partial class Form1
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
            MainPanel = new Panel();
            ScreenBox = new PictureBox();
            AgentButtonPanel = new FlowLayoutPanel();
            ControlButton = new Button();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScreenBox).BeginInit();
            AgentButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(ScreenBox);
            MainPanel.Controls.Add(AgentButtonPanel);
            MainPanel.Location = new Point(12, 12);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(860, 537);
            MainPanel.TabIndex = 0;
            MainPanel.Paint += panel1_Paint;
            // 
            // ScreenBox
            // 
            ScreenBox.Location = new Point(3, 84);
            ScreenBox.Name = "ScreenBox";
            ScreenBox.Size = new Size(854, 450);
            ScreenBox.SizeMode = PictureBoxSizeMode.Zoom;
            ScreenBox.TabIndex = 1;
            ScreenBox.TabStop = false;
            // 
            // AgentButtonPanel
            // 
            AgentButtonPanel.Controls.Add(ControlButton);
            AgentButtonPanel.Location = new Point(3, 40);
            AgentButtonPanel.Name = "AgentButtonPanel";
            AgentButtonPanel.Size = new Size(854, 38);
            AgentButtonPanel.TabIndex = 0;
            // 
            // ControlButton
            // 
            ControlButton.BackColor = Color.Crimson;
            ControlButton.Location = new Point(3, 3);
            ControlButton.Name = "ControlButton";
            ControlButton.Size = new Size(851, 35);
            ControlButton.TabIndex = 0;
            ControlButton.Text = "Start";
            ControlButton.UseVisualStyleBackColor = false;
            ControlButton.Click += ControlButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(MainPanel);
            Name = "Form1";
            Text = "Form1";
            Activated += Form1_Activated;
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ScreenBox).EndInit();
            AgentButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private FlowLayoutPanel AgentButtonPanel;
        private PictureBox ScreenBox;
        private Button ControlButton;
    }
}
