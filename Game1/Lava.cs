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
    public class Lava
    {
        Game1 game;
        Vector2 position;

        protected int frame;
        protected float totalElapsed;
        protected float timePerFrame;
        protected int framePerSec;

        int maxframe;
        int maxrow;

        int row;

        public Lava(Game1 game, Vector2 position)
        {

            this.game = game;
            this.position = position;

            maxframe = 5;
            maxrow = 2;


            framePerSec = 6;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            row = 0;

        }
        public void Update(GameTime gameTime)
        {
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Game1.fire, position, new Rectangle(frame * 141, row * 226, 141, 226), Color.White);


        }
        protected void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % (maxframe +1); //Console.WriteLine(frame);
                if (frame == maxframe) {
                    row++; frame -= maxframe;
                }
                if (row == maxrow) row = 0;
                //Console.WriteLine(frame + " " + row);
                totalElapsed -= timePerFrame;
            }
        }
    }
}
