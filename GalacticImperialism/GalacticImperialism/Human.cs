﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalacticImperialism
{
    class Human : Player
    {
        MouseState oldmb = Mouse.GetState();

        Planet selectedPlanet; //Used For Clicking On Planets

        public Human(int startingGold) : base(startingGold)
        {
         
        }

        public void Update(GameTime gt)
        {
            base.Update(gt);
            MouseState mb = Mouse.GetState();

            if (mb.LeftButton == ButtonState.Pressed && oldmb.LeftButton == ButtonState.Released)
                MouseClick(new Vector2(mb.X, mb.Y));

            oldmb = mb;
        }

        public void MouseClick(Vector2 position)
        {
            for (int i = 0; i < ownedPlanets.Count; i++)
            {
                Planet temp = ownedPlanets[i];
                Rectangle planetRect = new Rectangle((int)temp.position.X, (int)temp.position.Y, temp.size * 25, temp.size * 25);
                Rectangle mouse = new Rectangle((int)position.X, (int)position.Y, 1, 1);
                if (mouse.Intersects(planetRect))
                    selectedPlanet = ownedPlanets[i];
            }
        }
    }
}
