using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace florisgamemono
{
    public class Level 
    {
        Texture2D BlokTex;
        Texture2D WaterTex;
       

        private byte[,] byteTileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            {0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0  },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            {0,0,0,0,1,1,1,1,0,1,0,0,0,0,0,0,0  },
            {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0  },
            {0,0,0,1,1,0,1,1,1,0,0,0,0,0,0,0,0  },
            {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0  },
            {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1  }
        };

        public Blok[,] blokTileArray = new Blok[10, 17];
        public Water[,] waterTileArray = new Water[10, 17];
        public Level(Texture2D _BlokTex, Texture2D _waterTex)
        {
            WaterTex = _waterTex;
            BlokTex = _BlokTex;
            CreateWorld();
        }

        private void CreateWorld()
        {
            for (int rij = 0; rij < 10; rij++)
            {
                for (int kol = 0; kol < 17; kol++)
                {
                    if (byteTileArray[rij, kol] == 1)
                    {

                        //ik loop eerst over rij en kolom, maar in een xy stelsel stelt
                        //x (= horizontaal) de kolom en y de rij = (vertikaal) voor
                        blokTileArray[rij, kol] = new Blok(new Vector2(kol * 70, rij * 70), BlokTex);


                    }

                    if (byteTileArray[rij, kol] == 2)
                    {

                        //ik loop eerst over rij en kolom, maar in een xy stelsel stelt
                        //x (= horizontaal) de kolom en y de rij = (vertikaal) voor
                        waterTileArray[rij, kol] = new Water(new Vector2(kol * 70, rij * 70 + 35), WaterTex);
                    }
                }
            }

    }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    if (blokTileArray[x, y] != null)
                    {
                        blokTileArray[x, y].Draw(_spriteBatch);
                    }

                    if (waterTileArray[x, y] != null)
                    {
                        waterTileArray[x, y].Draw(_spriteBatch);
                    }
                }
            }

            
                   
                
        }
    }
}
