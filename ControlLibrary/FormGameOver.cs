using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisGame;

namespace ControlLibrary
{
    public partial class FormGameOver : Form
    {
        public FormGameOver()
        {
            InitializeComponent();
        }

        private void buttonStartNew_Click(object sender, EventArgs e)
        {
            Close();
          
            UserControl1 userControl1 = new UserControl1();
            userControl1.Show();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
          
        }
    }
}
