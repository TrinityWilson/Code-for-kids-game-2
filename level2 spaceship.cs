using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2016_Level2_Dodge
{
    class Spaceship
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image spaceship;//variable for the planet's image

        public Rectangle spaceRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Spaceship()
        {
            x = 250;
            y = 390;
            width = 50;
            height = 65;
            spaceship = Image.FromFile("spaceship-tansparent-2.png");
            spaceRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void DrawSpaceship(Graphics g)
        {
            spaceRec = new Rectangle(x, y, width, height);
            g.DrawImage(spaceship, spaceRec);
        }
        public void MoveSpaceship(string move)
        {
            spaceRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (spaceRec.Location.X > 450) // is spaceship within 50 of right side
                {

                    x = 50;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 15;
                    spaceRec.Location = new Point(x, y);
                }

            }
            //
            if (move == "left")
            {
                if (spaceRec.Location.X < 10) // is spaceship within 10 of left side
                {

                    x = 20;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 15;
                    spaceRec.Location = new Point(x, y);
                }



            }


        }


    }
}