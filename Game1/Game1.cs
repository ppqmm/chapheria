using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Comora;

namespace Game1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D start, end;
        Texture2D bg1, bg2, bg3, b4;
        Texture2D clock;
        Texture2D charTexture;
        Texture2D glassBlock;
        Vector2 charPosition = new Vector2(50, 40);
        Vector2 grassBlockPos = new Vector2(100, 250);
        //Vector2 old_position = Vector2.Zero;

        SpriteFont font;
        Rectangle screen;

        List<Vector2> grassList = new List<Vector2>();

        float time = 180;
        int timecounter;

        bool startScreen = true, endScreen = false;
        bool grassBlockHit;
        int circleSprite = 0;
        int frame;
        float totalElapsed;
        float timePerFrame;
        int framePerSec;

        Camera cam;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            cam = new Camera(graphics.GraphicsDevice);
            //cam.Position = new Vector2(-graphics.PreferredBackBufferWidth/2, -graphics.PreferredBackBufferHeight/2);
            //เส้นบน
            //------------------------------------------- grassblocg --------------------------//

            for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 20 * j));
                }

            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 120 + (20 * j)));
                }

            }


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(936 + (26 * i), 160 + (20 * j)));
                }

            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(132 + (26 * i), 260 + (20 * j)));
                }

            }


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(1144 + (26 * i), 260 + (20 * j)));
                }

            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(1404 + (26 * i), 260 + (20 * j)));
                }

            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(650 + (26 * i), 280 + (24 * j)));
                }

            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(884 + (26 * i), 300 + (20 * j)));
                }

            }


            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(390 + (26 * i), 380 + (20 * j)));
                }

            }



            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 380 + (20 * j)));
                }

            }


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(702 + (26 * i), 520 + (20 * j)));
                }

            }

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(1170 + (26 * i), 520 + (20 * j)));
                }

            }


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(390 + (26 * i), 620 + (20 * j)));
                }

            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 680 + (20 * j)));
                }

            }


            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(130 + (26 * i), 860 + (20 * j)));
                }

            }


            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(780 + (26 * i), 880 + (20 * j)));
                }

            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(468 + (26 * i), 1020 + (20 * j)));
                }

            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(1014 + (26 * i), 1040 + (20 * j)));
                }

            }

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(1274 + (26 * i), 1020 + (20 * j)));
                }

            }

            for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 1180 + (20 * j)));
                }

            }




            //เส้นข้าง
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 49; j++)
                {
                    grassList.Add(new Vector2(26 * i, 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grassList.Add(new Vector2(26 * i, 1100 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grassList.Add(new Vector2(130 + (26 * i), 380 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    grassList.Add(new Vector2(130 + (26 * i), 800 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grassList.Add(new Vector2(260 + (26 * i), 1000 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                   grassList.Add(new Vector2(260 + (26 * i), 400 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    grassList.Add(new Vector2(260 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    grassList.Add(new Vector2(390 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grassList.Add(new Vector2(468 + (26 * i), 860 + (20 * j)));
                }

            }



            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    grassList.Add(new Vector2(520 + (26 * i), 20 * j));
                }

            }


            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grassList.Add(new Vector2(546 + (26 * i), 500 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grassList.Add(new Vector2(598 + (26 * i), 860 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grassList.Add(new Vector2(650 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grassList.Add(new Vector2(754 + (26 * i), 200 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    grassList.Add(new Vector2(754 + (26 * i), 680 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    grassList.Add(new Vector2(884 + (26 * i), 520 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grassList.Add(new Vector2(988 + (26 * i), 1020 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    grassList.Add(new Vector2(1014 + (26 * i), 160 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grassList.Add(new Vector2(1014 + (26 * i), 760 + (20 * j)));
                }

            }



            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                   grassList.Add(new Vector2(1144 + (26 * i), 0 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    grassList.Add(new Vector2(1170 + (26 * i), 760 + (20 * j)));
                }

            }


            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grassList.Add(new Vector2(1404 + (26 * i), 1040 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    grassList.Add(new Vector2(1404 + (26 * i), 160 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                   grassList.Add(new Vector2(1404 + (26 * i), 540 + (20 * j)));
                }

            }




            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    grassList.Add(new Vector2(1585 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 36; j++)
                {
                   grassList.Add(new Vector2(1585 + (26 * i), 520 + (20 * j)));
                }

            }



        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bg1 = Content.Load<Texture2D>("bg1-1");
            font = Content.Load<SpriteFont>("default");
            charTexture = Content.Load<Texture2D>("splite");
            glassBlock = Content.Load<Texture2D>("glassBlock");
            clock = Content.Load<Texture2D>("clock");
            start = Content.Load<Texture2D>("cover2");
            end = Content.Load<Texture2D>("end");

            framePerSec = 4;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;

            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();


            if (startScreen == true)
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    startScreen = false;
                }
            }

            Vector2 old_position = charPosition;

            if (startScreen == false && endScreen == false)
            {
                time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา
                timecounter += (int)time;

                //-------------------- camera ---------------------------//
                cam.Update(gameTime);


                if (time == 0) endScreen = true;

                //------------------------------ walk ------------------------//
                GraphicsDevice device = graphics.GraphicsDevice;

                if (keyboard.IsKeyDown(Keys.Left))
                {
                        charPosition.X = charPosition.X - 2;
                        circleSprite = 78 * 2;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (keyboard.IsKeyDown(Keys.Right))
                {
                        charPosition.X = charPosition.X + 2;
                        circleSprite = 78 * 3;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (keyboard.IsKeyDown(Keys.Up))
                {
                        charPosition.Y = charPosition.Y - 2;
                        circleSprite = 78;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (keyboard.IsKeyDown(Keys.Down))
                {
                        charPosition.Y = charPosition.Y + 2;
                        circleSprite = 0;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }


                for (int i = 0; i < grassList.Count; i++)
                {
                    //---------------------- collision -----------------------//
                    Rectangle charRectangle = new Rectangle((int)charPosition.X, (int)charPosition.Y, 64, 78);
                    Rectangle glassBlockRectangle = new Rectangle((int)grassList[i].X, (int)grassList[i].Y, 26, 15);

                    if (charRectangle.Intersects(glassBlockRectangle) == true)
                    {
                        grassBlockHit = true;
                    }
                    else if (charRectangle.Intersects(glassBlockRectangle) == false)
                    {
                        grassBlockHit = false;
                    }


                    if (grassBlockHit == true)
                    {
                        charPosition = old_position;
                    }

                }

                    cam.Position = charPosition;

                //var screenPosition = charPosition;
                //cam.ToScreen(ref charPosition, out screenPosition);
                //
                //Console.WriteLine(screenPosition);
                //Console.WriteLine(graphics.PreferredBackBufferWidth);
                //
                //if (screenPosition.X > graphics.PreferredBackBufferWidth2x *0.8f)
                //{
                //
                //    cam.Position = charPosition;
                //}


                //Console.WriteLine(cam.Position);
                // TODO: Add your update logic here
            }
            base.Update(gameTime);
            
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (startScreen == true)
            {
                spriteBatch.Draw(start, screen, Color.White);
            }

            if (endScreen == true)
            {
                spriteBatch.Draw(end, screen, Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here
            spriteBatch.Begin(cam);




            if (startScreen == false && endScreen == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        spriteBatch.Draw(bg1, new Vector2(800 * i, 600 * j), Color.White);
                    }

                }

                for (int i = 0; i < grassList.Count; i++)
                {
                    spriteBatch.Draw(glassBlock, grassList[i], Color.White);
                }

                // spriteBatch.Draw(glassBlock, grassBlockPos, new Rectangle(0, 0, 26, 45), Color.White);


                /* for (int i = 0; i < 1; i++)
                 {
                     for (int j = 0; j < 5; j++)
                     {
                         spriteBatch.Draw(glassBlock, new Vector2(26 * i, 520+(20 * j)), Color.White);
                     }

                 }*/


                //spriteBatch.Draw(clock, new Vector2(5, 5), Color.White);

                //  spriteBatch.DrawString(font, time.ToString("0"), new Vector2(100, 31), Color.Black);

                spriteBatch.Draw(charTexture, charPosition, new Rectangle(frame * 64, circleSprite, 64, 78), Color.White);
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }
        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % 4;
                totalElapsed -= timePerFrame;
            }
        }
    }
}
