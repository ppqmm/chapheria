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
        Vector2 charPosition = new Vector2(50, 50);
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
            for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 20 * j));
                }

            }

            for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 1180 + (20 * j)));
                }

            }

            for (int i = 0; i < 8; i++)
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
                    grassList.Add(new Vector2(26 * i, 130 + (20 * j)));
                }

            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    grassList.Add(new Vector2(26 * i, 364 + (20 * j)));
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
                for (int j = 0; j < 7; j++)
                {
                    grassList.Add(new Vector2(130 + (26 * i), 364 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    grassList.Add(new Vector2(234 + (26 * i), 364 + (20 * j)));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    grassList.Add(new Vector2(234 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    grassList.Add(new Vector2(442 + (26 * i), 20 * j));
                }

            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    grassList.Add(new Vector2(338 + (26 * i), 20 * j));
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


                cam.Update(gameTime);


                if (time == 0) endScreen = true;

                //------------------------------ walk ------------------------//
                GraphicsDevice device = graphics.GraphicsDevice;

                if (keyboard.IsKeyDown(Keys.Left))
                {
                    if (charPosition.X > 0)
                    {
                        charPosition.X = charPosition.X - 2;
                        circleSprite = 78 * 2;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    }

                }
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    if (charPosition.X < 740)
                    {
                        charPosition.X = charPosition.X + 2;
                        circleSprite = 78 * 3;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    }

                }
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    if (charPosition.Y > 0)
                    {
                        charPosition.Y = charPosition.Y - 2;
                        circleSprite = 78;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    }

                }
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    if (charPosition.Y < 540)
                    {
                        charPosition.Y = charPosition.Y + 2;
                        circleSprite = 0;
                        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    }

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
                spriteBatch.Draw(bg1, new Vector2(0, 0), Color.White);

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
