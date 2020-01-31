using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    class Sheep : Game1
    {
        private Texture2D sheepTex;
        private Vector2 sheepPos;
        private Rectangle sheepRect;
        private bool gevangen;
        KeyboardState state;
        private bool dpressed;

        public Sheep(Vector2 SheepPos, Texture2D SheepTex)
        {
            sheepTex = SheepTex;
            sheepPos = SheepPos;
            sheepRect = new Rectangle(Convert.ToInt32(SheepPos.X), Convert.ToInt32(sheepPos.Y), sheepTex.Width, sheepTex.Height);
        }

        public Rectangle SheepRect { get { return sheepRect; } }

        public bool Gevangen { set { gevangen = value; } }

        public void Update(Vector2 heroPos)
        {
            checkInput();
            sheepRect.X = (int)sheepPos.X;
            sheepRect.Y = (int)sheepPos.Y;
            if (gevangen == true)
            {

                if (dpressed == true)
                {
                    sheepPos.X += 5;
                }
                else
                {

                    sheepPos.X = heroPos.X + 40;
                    sheepPos.Y = heroPos.Y;
                }

            }
        }

        private void checkInput()
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D))
            {
                dpressed = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sheepTex, sheepPos);
        }
    }
}
