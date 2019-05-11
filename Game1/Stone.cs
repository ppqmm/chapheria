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
    public class Stone
    {
        Game1 game;
        int type;
        public Vector2 position;

        protected int frame;
        protected float totalElapsed;
        protected float timePerFrame;
        protected int framePerSec;

        int maxframe;

        int dir = 1;
        float speed;

        public Stone(Game1 game, int type, Vector2 start, float speed)
        {
            this.game = game;
            this.type = type;
            this.speed = speed;
            maxframe = 3;
            framePerSec = 6;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            

            position = start;

        }

        public void Update(GameTime gameTime)
        {
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

            Vector2 oldPosition = position;

            switch (this.type)
            {
                case 1:
                    position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds * dir;
                    //if (position.X > destination2.X || position.X < destination1.X)
                    //{
                    //    dir *= -1;
                    //}
                    break;
                case 2:
                    position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds * dir;
                    //if (position.Y > destination2.Y || position.Y < destination1.Y)
                    //{
                    //    dir *= -1;
                    //}
                    break;
            }


            for (int i = 0; i < game.currentStage.grassList.Count; i++)
            {
                //---------------------- collision -----------------------//
                Rectangle stoneRectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
                Rectangle glassBlockRectangle = new Rectangle((int)game.currentStage.grassList[i].X, (int)game.currentStage.grassList[i].Y, 26, 15);

                if (stoneRectangle.Intersects(glassBlockRectangle))
                {
                    position = oldPosition;
                    dir *= -1;
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            //spriteBatch.Draw(Game1.blx,new Rectangle((int)position.X, (int)position.Y,50,50),Color.Magenta);

            spriteBatch.Draw(Game1.stone, position - new Vector2(20,15),new Rectangle(frame*100,0,100,81),Color.White);
            
        }
        protected void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % (maxframe );// Console.WriteLine(frame);

                //Console.WriteLine(frame + " " + row);
                totalElapsed -= timePerFrame;
            }
        }
    }
}
