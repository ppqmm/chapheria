using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Witch : Player
    {

        float time;
        float delay;

        Vector2 old_position;

        public Witch(Game1 game) : base(game)
        {
            delay = 1f/60f * 2;
            time = delay;
            old_position = position;
        }

        public void Update(GameTime gameTime)
        {

            Vector2 follow = game.player.position - this.position;
            follow.Normalize();
            this.position += follow * 2;

            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);


            Vector2 dir = old_position - position;

            if (Math.Abs(dir.X) >= Math.Abs(dir.Y))
            {

                if (dir.X < 0)
                {
                    direction = Direction.right;
                }
                if (dir.X > 0)
                {
                    direction = Direction.left;
                }
            }
            else
            {

                if (dir.Y < 0)
                {
                    direction = Direction.down;
                }
                if (dir.Y > 0)
                {
                    direction = Direction.up;
                }
            }


            old_position = position;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // https://twitter.com/saint11/status/826503271535751168

            var slice = size.Y / 10;

            for (int i = 0; i < 10; i++)
            {
                var rect = new Rectangle(frame * (int)size.X, (int)((int)direction + i * slice), (int)size.X, (int)slice);
                float displaceX = (float)Math.Sin((gameTime.TotalGameTime.TotalSeconds / gameTime.ElapsedGameTime.TotalSeconds) + i);
                spriteBatch.Draw(Game1.hexTexture, new Vector2(position.X + displaceX * 3, position.Y + i * slice), rect, Color.White * 0.5f);
            }

        }

    }
}
