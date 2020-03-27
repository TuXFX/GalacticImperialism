﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalacticImperialism
{
    class Planet
    {
        //Planet Attributes
        public int size;
        public Color planetColor;
        public Vector2 position;
        public int owner; // 0 = no-one, 1-4 = Players 1-4
        public List<string> resources = new List<string>(); //Holds Resources
        
        //Create Base Planets
        public Planet(int s, Color c, Vector2 p, List<string> r)
        {
            size = s;
            planetColor = c;
            position = p;
            resources = r;
        }

        //Create Starting Planet
        public Planet(Color c, Vector2 p, int playerIndex)
        {
            size = 2;
            planetColor = c;
            position = p;
            owner = playerIndex;
            resources.Add("iron"); resources.Add("hydrogen");
        }
    }
}
