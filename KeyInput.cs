using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueDrafter
{
    public partial class KeyInput : Form
    {
        public Main main;
        public KeyInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.SubmitKey(textBox1.Text);
        }

        private void KeyInput_Load(object sender, EventArgs e)
        {

        }
    }
}
