namespace ControlLibrary
{
    partial class FormGameOver
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
            this.buttonStartNew = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartNew
            // 
            this.buttonStartNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonStartNew.Location = new System.Drawing.Point(12, 62);
            this.buttonStartNew.Name = "buttonStartNew";
            this.buttonStartNew.Size = new System.Drawing.Size(97, 23);
            this.buttonStartNew.TabIndex = 0;
            this.buttonStartNew.Text = "Start new game";
            this.buttonStartNew.UseVisualStyleBackColor = true;
            this.buttonStartNew.Click += new System.EventHandler(this.buttonStartNew_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonEnd.Location = new System.Drawing.Point(123, 62);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(94, 23);
            this.buttonEnd.TabIndex = 1;
            this.buttonEnd.Text = "Close tetris";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGameOver.Location = new System.Drawing.Point(59, 18);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(90, 20);
            this.labelGameOver.TabIndex = 2;
            this.labelGameOver.Text = "Game Over";
            // 
            // FormGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonEnd;
            this.ClientSize = new System.Drawing.Size(229, 107);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonStartNew);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartNew;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Label labelGameOver;
    }
}