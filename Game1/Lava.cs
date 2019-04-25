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

        public Rectangle hitbox;

        public Lava(Game1 game, Vector2 position)
        {

            this.game = game;
            this.position = position;

            maxframe = 8;
            maxrow = 2;

            hitbox = new Rectangle((int)position.X + 40, (int)position.Y + 550, 50,50);

            framePerSec = 6;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            row = 0;

        }
        public void Update(GameTime gameTime)
        {
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

            switch (frame + 8*row)
            {
                case 0:
                case 1:
                case 2:
                    hitbox.Y = (int)position.Y + 550;
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    hitbox.X = (int)position.X + 40;
                    hitbox.Y -= (int)((float)gameTime.ElapsedGameTime.TotalSeconds * 583f);
                    break;
                case 8:
                case 9:
                    hitbox.X = (int)position.X + 120;
                    break;
                case 10:
                case 11:
                    hitbox.Y += (int)((float)gameTime.ElapsedGameTime.TotalSeconds * 2f  * 583f);
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                    break;
            }


        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            //spriteBatch.Draw(Game1.blx, new Rectangle((int)position.X, (int)position.Y, 199, 583), Color.White);
            //spriteBatch.Draw(Game1.blx, hitbox, Color.Cyan);
            spriteBatch.Draw(Game1.fire, position, new Rectangle(frame * 199, row * 583, 199, 583), Color.White);


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
