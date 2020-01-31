using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    class Hero
    {
        int frameWidth = 33;
        int frameHeight = 44;
        Texture2D HeroTex;
        private Vector2 position;
        Rectangle visrect;
        KeyboardState state;
        Texture2D heroTexLeft;
        Texture2D heroTexRight;
        public int walkspeed = 5;
        int jumpSpeed = 10;
        int fallspeed = 10;
        private bool jump = false;
        int jumpIndex;
        public Rectangle ColHeroRect;
        
        public bool _fall = true;
        private bool ground = false;
        private bool walkRight = true;
        private bool walkLeft = true;
        

        public Hero(Texture2D textureright, Texture2D textureleft)
        {

            
            heroTexLeft = textureleft;
            heroTexRight = textureright;
            visrect = new Rectangle(0, 0, frameWidth, frameHeight);
            position = new Vector2(400, 100);
            HeroTex = heroTexRight;
            ColHeroRect = new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), frameWidth, frameHeight);
        }

         public bool WalkRight { set { walkRight = value; } }
        public bool WalkLeft { set { walkLeft = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public bool Ground { set { ground = value; } }
        public bool JumpCheck { get { return jump; } }
        public void checkinput()
        {
            state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                HeroTex = heroTexLeft;

                if (walkLeft == true)
                {
                    position.X -= walkspeed;
                    animate();
                }

            }

            if (state.IsKeyDown(Keys.Right))
            {
                HeroTex = heroTexRight;
                if (walkRight == true)
                {
                    position.X += walkspeed;
                    animate();
                }
            }

            if (state.IsKeyDown(Keys.Space))
            {
               
                
                jump = true;
                Jump();
                
                
            }
        }
        public void animate()
        {
            if (visrect.X == 231)
            {
                visrect.X = 0;

            }
            else visrect.X += 33;
        }
        public void Update()
        {
            checkinput();

            Jump();
            
            fall();
            ColHeroRect.X = (int)position.X;
            ColHeroRect.Y = (int)position.Y;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            

            spriteBatch.Draw(HeroTex, position, visrect, Color.White);
           
        }

        private void Jump()
        {

            if (jumpIndex < 15 && jump == true && ground == true)
            {
                position.Y -= jumpSpeed;
                jumpIndex++;
                _fall = true;
            }
            else
            {
                ground = false;
                jump = false;
                jumpIndex = 0;
            }

        }

        private void fall()
        {
            if (!jump)

                if (_fall == true)
                {
                    
                        fallspeed = 10;
                        position.Y += jumpSpeed;
                    
                    
                }
            if (_fall == false)
            {
                fallspeed = 0;
                _fall = true;
            }



        }
        
              
        
    }

}
