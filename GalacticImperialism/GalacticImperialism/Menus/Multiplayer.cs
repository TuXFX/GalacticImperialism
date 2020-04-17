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
using GalacticImperialism.Networking;

namespace GalacticImperialism
{
    class Multiplayer
    {
        SpriteFont fontOfTitle;
        SpriteFont fontOfText;

        Texture2D selected;
        Texture2D unselected;

        Vector2 statusVector;

        TextBox port;
        Button join;

        GraphicsDevice GraphicsDevice;
        Game game;

        public Multiplayer(Game1 game)
        {
            this.game = game;
            fontOfTitle = game.Content.Load<SpriteFont>("Sprite Fonts/Castellar60Point");
            fontOfText = game.Content.Load<SpriteFont>("Sprite Fonts/Arial20");
            selected = game.Content.Load<Texture2D>("Button Textures/SelectedButtonTexture1");
            unselected = game.Content.Load<Texture2D>("Button Textures/UnselectedButtonTexture1");
            this.GraphicsDevice = game.GraphicsDevice;
            Initialize();
        }

        public void Initialize()
        {
            statusVector = new Vector2(50, 250);
            port = new TextBox(new Rectangle(50, 350, 150, 50), 1, 5, Color.Black, Color.White, Color.White, Color.White, GraphicsDevice, fontOfText);
            join = new Button(new Rectangle(50, 450, 150, 50), unselected, selected, "Connect", fontOfText, Color.White, null, null);
        }

        public void Update(KeyboardState kb, KeyboardState oldKb, MouseState mouse, MouseState oldMouse)
        {
            port.Update(mouse, oldMouse, kb, oldKb);
            join.Update(mouse, oldMouse);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = fontOfTitle.MeasureString("Multiplayer");
            spriteBatch.DrawString(fontOfTitle, "Multiplayer", new Vector2((GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2), (GraphicsDevice.Viewport.Height / 12) - (textSize.Y / 2)), Color.White);
            textSize = fontOfText.MeasureString("Press Escape To Return To Main Menu");
            spriteBatch.DrawString(fontOfText, "Press Escape To Return To Main Menu", new Vector2((GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2), GraphicsDevice.Viewport.Height - textSize.Y), Color.White);
            spriteBatch.DrawString(fontOfText, Game1.status, statusVector, Color.White);
            port.Draw(spriteBatch);
            join.Draw(spriteBatch);
        }

        public String getPort()
        {
            if (port.text.Length == 5) // Makes sure it's a port
            {
                return port.text;
            }
            else
            {
                return ""; // If its not a port return nothing
            }
        }

        public Button getJoin()
        {
            return join;
        }
    }
}