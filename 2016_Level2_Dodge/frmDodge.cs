﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016_Level2_Dodge
{
    public partial class frmDodge : Form
    {
        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called planet[0] to planet[6] 
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();
        Spaceship spaceship = new Spaceship();
        bool left, right;
        string move;
        int score, lives;
        public frmDodge()
        {
            InitializeComponent();
            //
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                planet[i] = new Planet(x);
            }


        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;


            for (int i = 0; i < 7; i++)
            { // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                planet[i].y += rndmspeed;
                //call the Planet class's drawPlanet method to draw the images
                planet[i].drawPlanet(g);
            }

            spaceship.drawSpaceship(g);
        }





        private void tmrShip_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                spaceship.moveSpaceship(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                spaceship.moveSpaceship(move);
            }

        }

        private void frmDodge_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name press tab and enter the number of lives \n Click Start to begin", "Game Instructions");
            txtName.Focus();

        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            tmrPlanet.Enabled = true;
            tmrShip.Enabled = true;

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrShip.Enabled = false;
            tmrPlanet.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmDodge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
        }

        private void frmDodge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
        }

        private void tmrPlanet_Tick(object sender, EventArgs e)
        {
            score = 0;
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
                if (spaceship.spaceRec.IntersectsWith(planet[i].planetRec))
                {
                    //reset planet[i] back to top of panel
                    planet[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    CheckLives();
                }

                score += planet[i].score;
                lblScore.Text = score.ToString();
                pnlGame.Invalidate();
                // if(planet[i].planetRec.Y > pnlGame.ClientSize.Height)
                // {

                //  }
            }
        }
        private void CheckLives()
        {
            if (lives == 0)
            {
                tmrPlanet.Enabled = false;
                tmrShip.Enabled = false;
                MessageBox.Show("Gameover");
                                
               txtName.Focus();
            }
        }
    


    }
}
