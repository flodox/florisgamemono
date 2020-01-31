using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    public class Water
    {
        private Texture2D waterTex;
        private Vector2 waterPos;
        private Rectangle waterRectangle;


        public Water(Vector2 WaterPos, Texture2D WaterTex)
        {
            waterPos = WaterPos;
            waterTex = WaterTex;
            waterRectangle = new Rectangle((int)waterPos.X, (int)waterPos.Y, 70, 45);
        }

        public Rectangle WaterRect { get { return waterRectangle; } set { waterRectangle = value; } }


        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(waterTex, waterPos);
        }
    }
}
