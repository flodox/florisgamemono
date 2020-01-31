using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    public class Blok
    {
        private Texture2D blokTex;
        private Vector2 blokPos;
        private  Rectangle _colRectangle;
        

        public Blok (Vector2 _blokPos,Texture2D _blokTex)
        {
            blokTex = _blokTex;
            blokPos = _blokPos;
            _colRectangle = new Rectangle((int)_blokPos.X, (int)_blokPos.Y, 70, 70);
        }

        public Rectangle ColRectangle
        {
            get { return _colRectangle; }
            set { _colRectangle = value; }
        }



        public void Draw(SpriteBatch _spriteBatch)
        {
            
            _spriteBatch.Draw(blokTex, blokPos);
            
        }

        
    }
}
