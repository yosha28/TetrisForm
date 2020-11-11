namespace TetrisForm1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl1 = new ControlLibrary.UserControl1();
            this.SuspendLayout();
            // 
            // userControl1
            // 
            this.userControl1.AutoSize = true;
            this.userControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.55254F);
            this.userControl1.Location = new System.Drawing.Point(0, 0);
            this.userControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(284, 295);
            this.userControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 295);
            this.Controls.Add(this.userControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLibrary.UserControl1 userControl1;
    }
}

