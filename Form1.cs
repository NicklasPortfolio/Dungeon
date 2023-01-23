using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon
{
    public partial class Form1 : Form
    {

        // Deklaration för variabler
        Form f2 = new Form2();
        Random rand = new Random();
        bool gotScroll_ = false;
        bool gotSword_ = false;
        bool gotKey_ = false;
        int points = 0;
        int time = 0;

        public static class Globals
        {
            public static string doorCode; // Basically någonting som inte fungerar
        }

        // DoubleBuffered gör så att formuläret inte är så långsamt.
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.doorCode = rand.Next(1000, 10000).ToString(); // Jag försökte göra någonting coolt men det fungerade inte.

            // Flyttar muspekaren till start positionen när Form1 laddas in.
            Cursor.Position = new Point(button1.Location.X+Left+button1.Width/2+5, button1.Location.Y+Top+button1.Height/2+30);
        }

        // Denna funktionen gör så att om spelaren rör sig utanför de vita linjerna så dör de
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("You fell down into the abyss! You lose!");
            //this.Close();
        }

        // Gör så att alla skallar som flyttar på sig dödar spelaren om den
        private void enemySkull(object sender, EventArgs e)
        {
            // MessageBox.Show("Oh no! The skull got you! Game over.");
            // this.Close();
        }

        // Gör så att alla skallar flyttar på sig varje frame
        private void timerMover_Tick(object sender, EventArgs e)
        {
            skullMover(enemySkull1);
            skullMover(enemySkull3);
            skull2Mover();
        }

        // Timer för att ta tiden på spelaren.
        private void timerTime_Tick(object sender, EventArgs e)
        {
            time++;
            lblTime.Text = $"TID: {time}";
        }

        // Variabler för skull1Mover
        private int counter = 0;
        private int moveCoefficient = 2;  
        // skull1Mover använder ett counter system för att flytta på de skallar som rör sig upp och ner
        private void skullMover(PictureBox skalle)
        {
            skalle.Top += moveCoefficient;
            counter++;
            if (counter == 138) { moveCoefficient *= -1; counter = 0; }
        }

        // Variabler för skull2Mover
        int counterX = 0;
        int counterY = 0;
        int counterXY = 0;

        int moveCoefficientX = 1;
        int moveCoefficientY = 1;
        // skull2Mover använder också ett counter system, dock lite mer optimiserat än skull1Mover
        private void skull2Mover()
        {
            if (counterXY == 0)
            {
                enemySkull2.Left += moveCoefficientX;
                counterX++;
                if (counterX == 225) { moveCoefficientX *= -1; counterX = 0; counterXY++; }
            }
            if (counterXY == 1)
            {
                enemySkull2.Top += moveCoefficientY;
                counterY++;
                if (counterY == 200) { moveCoefficientY *= -1; counterY = 0; counterXY--; }
            }
        }

        // Hanterar alla objekt som kan interageras med
        private void staticObject(object sender, EventArgs e)
        {
            PictureBox obj = (PictureBox)sender;

            if (obj.Name == "staticKey")
            {
                staticKey.Visible = false;
                gotKey_ = true;
                lblKeyGot.Text = "You got a key!";
            }

            if (obj.Name == "staticSword")
            {
                staticSword.Visible = false;
                gotSword_ = true;
            }

            if (obj.Name == "staticScroll")
            {
                staticScroll.Visible = false;
                gotScroll_ = true;
                lblNoteCode.Text = $"The note contained a password! \n Maybe you could use it on the door?";
            }

            if (obj.Name == "staticLock")
            {
                if (gotKey_) { staticLock.Visible = false; }
                else { MessageBox.Show("You don't have a key! A boobytrap kills you! Game over!"); this.Close(); }
            }

            if (obj.Name == "staticEnemySkull")
            {
                if (gotSword_) { staticEnemySkull.Visible = false; }
                else { MessageBox.Show("You don't have a weapon! The skull enemy kills you! Game over!"); this.Close(); }
            }

            if (obj.Name == "staticDoor")
            {
                if (gotScroll_) { staticDoor.Visible = false; }
                else { MessageBox.Show("You don't have a password! A boobytrap kills you! Game over!"); this.Close(); }
            }
        }

        // Hantererare för när spelaren plockar upp en peng, lägger till en poäng
        private void coinPickedUp(object sender, EventArgs e)
        {
            PictureBox coin = (PictureBox)sender;
            coin.Visible = false;
            coin.Enabled = false;
            points++;
            lblPoints.Text = $"POÄNG: {points}";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            StreamWriter file = File.AppendText("Highscore.txt");

            Console.WriteLine(File.ReadAllLines("Highscore.txt"));
            


        }
    }
}
