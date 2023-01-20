using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static class Globals
        {
            public static bool _correctCode;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        string keyNums;
        bool _isFour;
        private void NumericalKeyPressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!_isFour) { keyNums += button.Text; }

            if (keyNums.Length == 4)
            {
                if (_isFour) { MessageBox.Show("No more than 4 digits, please."); }
                _isFour = true;
            }
            else
            {
                _isFour = false;
            }

            lblCode.Text = keyNums.ToString();
        }

        private void AccClrClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "✗") 
            {
                lblCode.Text = "";
                keyNums = ""; 
                _isFour = false;
                MessageBox.Show("Input cleared");
            }

            if (!_isFour && button.Text == "✓") { MessageBox.Show("4 digits are required."); }

            if (_isFour && button.Text == "✓" && keyNums == (Form1.Globals.doorCode)) 
            { 
                Globals._correctCode = true;
                MessageBox.Show("Correct code"); 
                this.Close();
            }
        }
    }
}
