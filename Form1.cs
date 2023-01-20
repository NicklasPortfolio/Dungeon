using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon
{
    public partial class Form1 : Form
    {

        Form f2 = new Form2();

        Random rand = new Random();

        public static class Globals
        {
            public static string doorCode;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.doorCode = rand.Next(1000, 10000).ToString();
            Cursor.Position = new Point(button1.Location.X+Left+button1.Width/2+5, button1.Location.Y+Top+button1.Height/2+30);
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("You fell down into the abyss! You lose!");
            //this.Close();
        }

        private void staticScroll_MouseEnter(object sender, EventArgs e)
        {
            staticScroll.Visible = false;
            lblNoteCode.Text = $"The note contained a code! \n \n {Globals.doorCode}";
        }

        private void timerMover_Tick(object sender, EventArgs e)
        {
            skalle1Mover();
        }


        private int counter = 0;
        private int staticLocationX = 296;
        private bool _firstRun = true;
        private bool _movingDown = false;
        private bool _movingUp = false; // Variables for skalle1Mover

        private void skalle1Mover()
        {
            if (_firstRun)
            {
                counter++;
                _firstRun = false;
                _movingDown = true;
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y + 1);   
            }

            if (_movingDown)
            {
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y + 1);
                counter++;
                if (counter == 69) { _movingUp = true; _movingDown = false; }
            }

            if (_movingUp)
            {
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y - 1);
                counter--;
                if (counter == -69) { _movingDown = true; _movingUp = false; }
            }
            return;
        }
    }
}
