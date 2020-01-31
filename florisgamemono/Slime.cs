using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    class Slime
    {
        private Texture2D slimeTex;
        private Vector2 slimePos;
        private Rectangle slimeRect;
        private int slimeSpeed = 2;
        private int posLeft;
        private int posRight;
        private bool life = true;

        public Slime(Vector2 slimePostion, Texture2D slimeTexture, int PosLeft, int PosRight)
        {
            posLeft = PosLeft;
            posRight = PosRight;
            slimeTex = slimeTexture;
            slimePos = slimePostion;
            slimeRect = new Rectangle(Convert.ToInt32(slimePos.X), Convert.ToInt32(slimePos.Y), slimeTexture.Width, slimeTexture.Height);
        }

        public Rectangle SlimeRect { get { return slimeRect; }  }
        public bool Life { get { return life; } set { life = value; } }
        public void Update()
        {
            checkLife();
            slimePos.X += slimeSpeed;
            slimeRect.X = (int)slimePos.X;
            slimeRect.Y = (int)slimePos.Y;
            if(slimePos.X > posRight - slimeTex.Width)
            {
                slimeSpeed *=-1;
            } 
            if (slimePos.X < posLeft)
            {
                slimeSpeed *= -1;
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(slimeTex, slimePos);
        }

        private void checkLife()
        {
            if (life == false)
            {
                slimePos.Y += 5;
            }
        }
    }
}
