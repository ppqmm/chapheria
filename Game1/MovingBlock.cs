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
    class MovingBlock
    {
        int type;
        public Vector2 position;

        public Vector2 destination1;
        public Vector2 destination2;

        public Vector2 size;

        Texture2D currentblock;

        int dir = 1;

        public MovingBlock(int type,Vector2 des1,Vector2 des2)
        {
            this.type = type;

            switch (this.type)
            {
                case 1:
                    size = new Vector2(179, 69);
                    currentblock = Game1.wood1;
                    break;

                case 2:
                    size = new Vector2(154, 61);
                    currentblock = Game1.wood2;
                    break;

                case 3:
                    size = new Vector2(79, 127);
                    currentblock = Game1.wood3;
                    break;

                case 4:
                    size = new Vector2(76, 126);
                    currentblock = Game1.wood4;
                    break;
            }

            position = des1;

            destination1 = des1;
            destination2 = des2;

        }

        public void Update(GameTime gameTime)
        {
            switch (this.type)
            {
                case 1:
                case 2:
                    position.X += 1 * dir;
                    if (position.X >= destination2.X - size.X || position.X < destination1.X)
                    {
                        dir *= -1;
                    }
                    break;
                case 3:
                case 4:
                    position.Y += 1 * dir;
                    if (position.Y >= destination2.Y - size.Y || position.Y < destination1.Y)
                    {
                        dir *= -1;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch,GameTime gameTime)
        {
            spriteBatch.Draw(currentblock, position, Color.White);
        }
    }
}
