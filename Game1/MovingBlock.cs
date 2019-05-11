using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MovingBlock
    {
        Game1 game;
        int type;
        public Vector2 position;

        public Vector2 destination1;
        public Vector2 destination2;

        public Vector2 size;

        public bool isPlayerOnMe = false;

        Texture2D currentblock;

        int dir = 1;

        float delta;
        float duration;

        public MovingBlock(Game1 game, int type, Vector2 start, Vector2 des, float duration)
        {
            this.game = game;
            this.type = type;
            this.duration = duration;
            position = start;
            switch (this.type)
            {
                case 1:
                case 2:
                    if (des.X >= 0)
                    {
                        destination1 = start;
                        destination2 = start + des;
                    }
                    else
                    {
                        destination1 = start + des;
                        destination2 = start;
                    }
                    delta = des.X;

                    break;
                case 3:
                case 4:

                    if (des.Y >= 0)
                    {
                        destination1 = start;
                        destination2 = start + des;
                    }
                    else
                    {
                        destination1 = start + des;
                        destination2 = start;
                    }
                    delta = des.Y;
                    break;
            }

            switch (this.type)
            {
                case 1:
                    size = new Vector2(179, 50);
                    currentblock = Game1.wood1;
                    break;

                case 2:
                    size = new Vector2(154, 51);
                    currentblock = Game1.wood2;
                    break;

                case 3:
                    size = new Vector2(79, 100);
                    currentblock = Game1.wood3;
                    break;

                case 4:
                    size = new Vector2(76, 75);
                    currentblock = Game1.wood4;
                    break;
            }



        }

        public void Update(GameTime gameTime)
        {
            switch (this.type)
            {
                case 1:
                case 2:
                    position.X +=  delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                    if (isPlayerOnMe)
                    {
                        game.player.position.X += delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                        game.player.old_position.X += delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                    }
                    if (position.X > destination2.X || position.X < destination1.X)
                    {
                        dir *= -1;
                    }
                    break;
                case 3:
                case 4:
                    position.Y += delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                    if (isPlayerOnMe)
                    {
                        game.player.position.Y += delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                        game.player.old_position.Y += delta * (float)gameTime.ElapsedGameTime.TotalSeconds * dir / duration;
                    }
                    if (position.Y > destination2.Y || position.Y < destination1.Y)
                    {
                        dir *= -1;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(currentblock, position, Color.White);
            //spriteBatch.Draw(Game1.blx, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y),Color.GreenYellow);
        }
    }
}
