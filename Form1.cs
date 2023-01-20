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

        private void timerMover_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Du förlorade skallespelet!");
            this.Close();
        }

        int counter = 0;
        int top = 122;
        int bottom = 260;
        bool _firstRun = true;
        int staticLocationX = 444;

        private void skalle1Mover(object sender, EventArgs e)
        {
            if (_firstRun && counter == 0)
            {
                counter++;
                _firstRun = false;
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y+1);   
            }

            if (counter > 0)
            {
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y + 1);
                counter++;
                if (counter == 69) { counter = -1; }
            }

            if (counter < 0)
            {
                enemySkull1.Location = new Point(staticLocationX, enemySkull1.Location.Y - 1);
                counter--;
                if (counter == -69) { counter = 1; }
            }
        }
    }
}
