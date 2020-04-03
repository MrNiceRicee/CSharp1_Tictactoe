namespace OutOfClassAssignment4
{
    partial class Form1
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
            this.PlayerCounter = new System.Windows.Forms.Label();
            this.ComputerCounter = new System.Windows.Forms.Label();
            this.TieCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerCounter
            // 
            this.PlayerCounter.AutoSize = true;
            this.PlayerCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCounter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlayerCounter.Location = new System.Drawing.Point(554, 103);
            this.PlayerCounter.Name = "PlayerCounter";
            this.PlayerCounter.Size = new System.Drawing.Size(108, 20);
            this.PlayerCounter.TabIndex = 0;
            this.PlayerCounter.Text = "Player Wins: 0";
            // 
            // ComputerCounter
            // 
            this.ComputerCounter.AutoSize = true;
            this.ComputerCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputerCounter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ComputerCounter.Location = new System.Drawing.Point(554, 123);
            this.ComputerCounter.Name = "ComputerCounter";
            this.ComputerCounter.Size = new System.Drawing.Size(135, 20);
            this.ComputerCounter.TabIndex = 1;
            this.ComputerCounter.Text = "Computer Wins: 0";
            // 
            // TieCounter
            // 
            this.TieCounter.AutoSize = true;
            this.TieCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TieCounter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TieCounter.Location = new System.Drawing.Point(554, 143);
            this.TieCounter.Name = "TieCounter";
            this.TieCounter.Size = new System.Drawing.Size(55, 20);
            this.TieCounter.TabIndex = 2;
            this.TieCounter.Text = "Ties: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TieCounter);
            this.Controls.Add(this.ComputerCounter);
            this.Controls.Add(this.PlayerCounter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerCounter;
        private System.Windows.Forms.Label ComputerCounter;
        private System.Windows.Forms.Label TieCounter;
    }
}

