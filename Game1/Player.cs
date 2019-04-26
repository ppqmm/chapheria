using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Player
    {
        protected Game1 game;
        public Vector2 position;
        public Vector2 old_position;
        public Vector2 size;

        protected int frame;
        protected float totalElapsed;
        protected float timePerFrame;
        protected int framePerSec;

        public int health;

        float delayTime;

        int blinkframe = 0;

        int containIndex = 0;

        float falloutTime = 0;

        public bool falling = false;

        protected enum Direction
        {
            up = 99 * 3,
            down = 99 * 0,
            left = 99 * 1,
            right = 99 * 2
        }

        protected Direction direction;

        public Player(Game1 game)
        {
            this.game = game;

            health = 5;

            size = new Vector2(66, 100);

            framePerSec = 6;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;

            delayTime = 0;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {


            old_position = position;
            bool hit = false;
            bool walk = false;

            if (!falling)
            {
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    position.X = position.X - 6;
                    direction = Direction.left;
                    walk = true;
                }

                if (keyboard.IsKeyDown(Keys.Right))
                {
                    position.X = position.X + 6;
                    direction = Direction.right;
                    walk = true;
                }

                if (keyboard.IsKeyDown(Keys.Up))
                {
                    position.Y = position.Y - 6;
                    direction = Direction.up;
                    walk = true;
                }

                if (keyboard.IsKeyDown(Keys.Down))
                {
                    position.Y = position.Y + 6;
                    direction = Direction.down;
                    walk = true;
                }
            }
            Rectangle charRectangle;

            switch (game.currentStage.stageNumber)
            {
                case 1:
                case 2:
                case 3:
                case 5:
                case 6:
                case 7:

                    for (int i = 0; i < game.currentStage.grassList.Count; i++)
                    {
                        //---------------------- collision -----------------------//
                        charRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
                        Rectangle glassBlockRectangle = new Rectangle((int)game.currentStage.grassList[i].X, (int)game.currentStage.grassList[i].Y, 26, 15);

                        if (charRectangle.Intersects(glassBlockRectangle))
                        {
                            hit = true;
                        }
                        else if (!charRectangle.Intersects(glassBlockRectangle))
                        {
                            hit = false;
                        }


                        if (hit)
                        {
                            position = old_position;
                        }

                    }
                    break;
                case 4:

                    charRectangle = new Rectangle(
                        (int)position.X + (int)((size.X - 2) / 2),
                        (int)position.Y + (int)(size.Y) - 10,2,2);

                    var isOnBlock = false;

                    for (int i = 0; i < game.currentStage.movingBlocksList.Count; i++)
                    {
                        MovingBlock movingBlock = game.currentStage.movingBlocksList[i];
                        Rectangle movingRectangle = new Rectangle((int)movingBlock.position.X, (int)movingBlock.position.Y, (int)movingBlock.size.X, (int)movingBlock.size.Y);

                        movingBlock.isPlayerOnMe = false;

                        if (charRectangle.Intersects(movingRectangle))
                        {
                            containIndex = i;
                            movingBlock.isPlayerOnMe = true;
                            isOnBlock = true;
                            
                        }

                    }

                    if (!isOnBlock)
                    {
                        game.currentStage.movingBlocksList[containIndex].isPlayerOnMe = true;
                        position = old_position;
                        falloutTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (falloutTime <= 0)
                        {
                            //game.GameOver();
                            falling = true;
                        }
                    }
                    else
                    {
                        falloutTime = 0.1f;
                    }

                    if (falling)
                    {
                        position.Y += 10;
                        if(position.Y > 600)
                        {
                            //game.GameOver();
                            position = game.currentStage.movingBlocksList[containIndex].position;
                            falling = false;
                        }

                    }

                    //Rectangle charRectangle = new Rectangle()

                    break;
            }

            // check witch
            for (int i = 0; i < game.currentStage.witchList.Count; i++)
            {
                //---------------------- collision -----------------------//
                charRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
                Rectangle witchRectangle = new Rectangle((int)game.currentStage.witchList[i].position.X, (int)game.currentStage.witchList[i].position.Y, (int)size.X, (int)size.Y);

                if (charRectangle.Intersects(witchRectangle) && delayTime <= 0)
                {
                    blinkframe = 0;
                    health -= 1;
                    delayTime = 5;
                    if (health <= 0)
                    {
                        game.GameOver();
                    }
                }
            }
            // check witch
            for (int i = 0; i < game.currentStage.lavaList.Count; i++)
            {
                //---------------------- collision -----------------------//
                charRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
                //Rectangle witchRectangle = new Rectangle((int)game.currentStage.witchList[i].position.X, (int)game.currentStage.witchList[i].position.Y, (int)size.X, (int)size.Y);

                if (charRectangle.Intersects(game.currentStage.lavaList[i].hitbox) && delayTime <= 0)
                {
                    blinkframe = 0;
                    health -= 1;
                    delayTime = 5;
                    if (health <= 0)
                    {
                        game.GameOver();
                    }
                }
            }

            if (delayTime >= 0)
            {
                blinkframe++;
                delayTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // check exit
            for (int i = 0; i < game.currentStage.exitList.Count; i++)
            {
                //---------------------- collision -----------------------//
                charRectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
                Rectangle exitBlockRectangle = new Rectangle((int)game.currentStage.exitList[i].X, (int)game.currentStage.exitList[i].Y, 26, 15);

                if (charRectangle.Intersects(exitBlockRectangle))
                {
                    game.progressNextStage();
                }
            }

            if (walk)
            {
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                frame = 1;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (delayTime >= 0)
            {
                if ((gameTime.TotalGameTime.TotalSeconds / gameTime.ElapsedGameTime.TotalSeconds) % 8 < 4)
                {
                    spriteBatch.Draw(Game1.charTexture, position, new Rectangle(frame * (int)size.X, (int)direction, (int)size.X, (int)size.Y), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(Game1.charTexture, position, new Rectangle(frame * (int)size.X, (int)direction, (int)size.X, (int)size.Y), Color.White);
            }


            Rectangle
                    charRectangle = new Rectangle(
                        (int)position.X + (int)((size.X - 2) / 2),
                        (int)position.Y + (int)(size.Y) - 10,
                        2,
                        2
                        );
            //spriteBatch.Draw(Game1.blx, charRectangle, Color.Red);


            float scale = 1;

            var drawingVector = position - new Vector2(Game1.light.Width / 2 * scale, Game1.light.Height / 2 * scale) + new Vector2(size.X / 2, size.Y / 2);

            switch (game.currentStage.stageNumber)
            {
                case 1:
                case 2:
                case 3:
                    spriteBatch.Draw(Game1.light, new Rectangle((int)drawingVector.X, (int)drawingVector.Y, (int)(Game1.light.Width * scale), (int)(Game1.light.Height * scale)), new Rectangle(0, 0, Game1.light.Width, Game1.light.Height), Color.White);
                    break;
            }

        }


        protected void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % 3;
                totalElapsed -= timePerFrame;
            }
        }
    }
}
