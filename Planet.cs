using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2016_Level2_Dodge
{
    class Planet
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
       public Image planetImage;//variable for the planet's image
        
        public Rectangle planetRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Planet(int spacing)
        {
            x = spacing;
            y = 20;
            width = 50;
            height = 50;

            planetImage = Image.FromFile("alien-ufo.png");
            planetRec = new Rectangle(x, y, width, height);
        }
        // Methods for the Planet class
        public void DrawPlanet(Graphics g)
        {
            planetRec = new Rectangle(x, y, width, height);
            g.DrawImage(planetImage, planetRec);
        }
        public void MovePlanet()
        {
           // y += 7;

            planetRec.Location = new Point(x, y);
            if (planetRec.Location.Y > 400)
            {
                score += 1;// add 2 to score when planet reaches bottom of panel
                y = 40;
                planetRec.Location = new Point(x, y);
            }

        }

      
    }
}
