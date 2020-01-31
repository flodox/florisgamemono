using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace florisgamemono
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        Hero myhero;
        Slime slime1;
        Sheep sheep1;
        Blok blok;
        Level level;
        Texture2D heroTexLeft;
        Texture2D heroTexRight;
        Texture2D blokTex;
        Texture2D waterTex;
        Texture2D slimeTex;
        Texture2D sheepTex;
        Vector2 sheepPos;
        Vector2 slimePos1;
        Vector2 blokpos;

        
        CollisionCheck collisionCheck;
        Rectangle Colblok;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 21);
            graphics.PreferredBackBufferWidth = 1190; 
            graphics.PreferredBackBufferHeight = 700;
           
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            heroTexRight = Content.Load<Texture2D>("psyduckright");
            heroTexLeft = Content.Load<Texture2D>("psyduckleft");
            blokTex = Content.Load<Texture2D>("blok");
            slimeTex = Content.Load<Texture2D>("slime_walk");
            sheepTex = Content.Load<Texture2D>("sheep");
            blokpos = new Vector2(100, 100);
            waterTex = Content.Load<Texture2D>("water");
            slimePos1 = new Vector2(420, 140 - slimeTex.Height);
            sheepPos = new Vector2(490, 230);
            

            // TODO: use this.Content to load your game content here

            level = new Level(blokTex, waterTex);
            blok = new Blok(blokpos, blokTex);
            slime1 = new Slime(slimePos1, slimeTex, 350, 910);
            myhero = new Hero(heroTexRight, heroTexLeft);
            sheep1 = new Sheep(sheepPos, sheepTex);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            colcheck(myhero.ColHeroRect);
            myhero.Update();
            sheepstatus();
            slime1.Update();
            sheep1.Update(myhero.Position);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            myhero.Draw(_spriteBatch);
            level.Draw(_spriteBatch);
            slime1.Draw(_spriteBatch);
            sheep1.Draw(_spriteBatch);
            base.Draw(gameTime);
            _spriteBatch.End();
        }

        public void colcheck(Rectangle heroRect)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    if (level.blokTileArray[x, y] != null)
                    {

                        Colblok = level.blokTileArray[x, y].ColRectangle;

                        if (heroRect.Intersects(Colblok))
                        {


                            if (heroRect.Y + heroRect.Height >= Colblok.Y && heroRect.X + heroRect.Width >= Colblok.X && heroRect.X <= Colblok.X + Colblok.Width)
                            {
                                myhero._fall = false;
                                myhero.Ground = true;

                                //check botsing tegen blokje aan rechterkant van hero
                                if (heroRect.Intersects(Colblok) && heroRect.X - heroRect.Width <= Colblok.X && heroRect.Y >= Colblok.Y)
                                {
                                    myhero.WalkRight = false;

                                    myhero.Position = new Vector2(heroRect.X - 5, heroRect.Y);
                                }else
                                {
                                    myhero.WalkRight = true;
                                }
                                //einde botsing tegen rechterkant van hero
                                //begin botsing tegen blokje aan linkerkant van hero
                                if (heroRect.Intersects(Colblok) && heroRect.X + heroRect.Width >= Colblok.X + Colblok.Width && heroRect.Y >= Colblok.Y)
                                {
                                    myhero.WalkLeft = false;
                                    myhero.Position = new Vector2(heroRect.X + 5, heroRect.Y);

                                }
                                else
                                {
                                    myhero.WalkLeft = true;
                                }
                                //einde bosting tegen linkerkant van hero

                                //begin onderkant blokje detectie
                                if (heroRect.Intersects(Colblok) && heroRect.Y <= Colblok.Y + Colblok.Height && myhero.JumpCheck == true)
                                {
                                    myhero.Ground = false;
                                }
                                

                            }
                            if (heroRect.Intersects(Colblok) && heroRect.Y >= Colblok.Y)
                            {
                                myhero._fall = true;
                            }

                            
                            

                        }

                        
                        






                    }
                }
            }
        }

        public void sheepstatus()

        {

            if (sheep1.SheepRect.Intersects(myhero.ColHeroRect))

                {

                sheep1.Gevangen = true;

                }

            if (sheep1.SheepRect.Intersects(slime1.SlimeRect))
            {
                slime1.Life = false;
            }

        }
    }

}







             
         

