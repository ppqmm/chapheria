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

        public enum State
        {
            menu,
            tutorial,
            pre,
            play,
            end
        };

        State gamestate;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D start, end;

        public static Texture2D bg1, bg2, bg3, b4;
        public static Texture2D glassBlock;

        Texture2D clock;
        Texture2D charTexture;
        Texture2D ui;
        Texture2D light;
        Texture2D bgHelp;
        Texture2D board;
        Texture2D button;
        Texture2D state1_1;
        Texture2D state1_2;
        Texture2D state1_3;


        Vector2 charPosition = new Vector2(0, 0);
        //Vector2 old_position = Vector2.Zero;

        SpriteFont font;
        Rectangle screen;


        float time = 0;

        bool startScreen = true, endScreen = false;
        bool grassBlockHit;
        int circleSprite = 0;
        int frame;
        float totalElapsed;
        float timePerFrame;
        int framePerSec;

        Camera cam;

        //------------------------ collision mouse click ----------------------//

        Rectangle playRect = new Rectangle(0, 180, 250, 140);
        Rectangle tutorialRect = new Rectangle(0, 310, 250, 85);
        Rectangle exitRect = new Rectangle(0, 385, 250, 110);
        Rectangle backtomenu = new Rectangle(0, 450, 160, 130);

        bool isPlayClicked = false;
        bool isTutorialClicked = false;
        bool isExitClicked = false;
        bool isBackClicked = false;


        Stage currentStage;


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
            this.IsMouseVisible = true;
            //----------------------- camera -------------------------------------//

            cam = new Camera(graphics.GraphicsDevice);
            cam.Position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            //เส้นบน
            //--------------------------- grassblocg --------------------------//

            gamestate = State.menu;

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
            start = Content.Load<Texture2D>("bgMenu");
            end = Content.Load<Texture2D>("end");
            ui = Content.Load<Texture2D>("menu2");
            light = Content.Load<Texture2D>("light2");
            bgHelp = Content.Load<Texture2D>("bghelp");
            board = Content.Load<Texture2D>("board");
            button = Content.Load<Texture2D>("button");
            state1_1 = Content.Load<Texture2D>("font1");
            state1_2 = Content.Load<Texture2D>("font2");
            state1_3 = Content.Load<Texture2D>("font3");

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

            cam.Update(gameTime);

            //---------------------------------- menu ---------------------------------//
            Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);
            switch (gamestate)
            {
                case State.menu:

                    //---------------------- mouse ui click ------------------------//

                    if (mouseRect.Intersects(playRect) == true)
                    {
                        isPlayClicked = true;

                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            newStage(1);
                        }
                    }
                    else
                    {
                        isPlayClicked = false;
                    }

                    if (mouseRect.Intersects(tutorialRect) == true)
                    {
                        isTutorialClicked = true;
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            gamestate = State.tutorial;
                        }
                    }
                    else
                    {
                        isTutorialClicked = false;
                    }
                    if (mouseRect.Intersects(exitRect) == true)
                    {
                        isExitClicked = true;
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            Exit();
                        }
                    }
                    else
                    {
                        isExitClicked = false;
                    }
                    break;

                case State.tutorial:
                    if (mouseRect.Intersects(backtomenu) == true)
                    {

                        if (mouse.LeftButton == ButtonState.Released && isBackClicked == true)
                        {
                            gamestate = State.menu;
                        }

                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            isBackClicked = true;
                        }
                        else
                        {
                            isBackClicked = false;
                        }
                    }
                    break;
                case State.pre:

                    time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา

                    if (time <= 0)
                    {
                        time = 45;
                        gamestate = State.play;
                    }

                    break;
                case State.play:

                    Vector2 old_position = charPosition;

                    currentStage.Update(gameTime);

                    time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา

                    if(time <= 0)
                    {
                        time = 3;
                        gamestate = State.end;

                    }
                    

                    //-------------------- camera ---------------------------//
                    //cam.Update(gameTime);


                    if (time == 0) endScreen = true;

                    //------------------------------ walk ------------------------//
                    GraphicsDevice device = graphics.GraphicsDevice;

                    if (keyboard.IsKeyDown(Keys.Left))
                    {
                        charPosition.X = charPosition.X - 6;
                        circleSprite = 78 * 2;
                    }

                    if (keyboard.IsKeyDown(Keys.Right))
                    {
                        charPosition.X = charPosition.X + 6;
                        circleSprite = 78 * 3;
                    }

                    if (keyboard.IsKeyDown(Keys.Up))
                    {
                        charPosition.Y = charPosition.Y - 6;
                        circleSprite = 78;
                    }

                    if (keyboard.IsKeyDown(Keys.Down))
                    {
                        charPosition.Y = charPosition.Y + 6;
                        circleSprite = 0;
                    }

                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                    for (int i = 0; i < currentStage.grassList.Count; i++)
                    {
                        //---------------------- collision -----------------------//
                        Rectangle charRectangle = new Rectangle((int)charPosition.X, (int)charPosition.Y, 64, 78);
                        Rectangle glassBlockRectangle = new Rectangle((int)currentStage.grassList[i].X, (int)currentStage.grassList[i].Y, 26, 15);

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

                    for (int i = 0; i < currentStage.exitList.Count; i++)
                    {
                        //---------------------- collision -----------------------//
                        Rectangle charRectangle = new Rectangle((int)charPosition.X, (int)charPosition.Y, 64, 78);
                        Rectangle exitBlockRectangle = new Rectangle((int)currentStage.exitList[i].X, (int)currentStage.exitList[i].Y, 26, 15);

                        if (charRectangle.Intersects(exitBlockRectangle) == true)
                        {
                            newStage(currentStage.stageNumber + 1);
                        }
                    }
                    //cam.Position = charPosition;
                    //------------------------- camera -------------------------------------//

                    var screenPosition = Vector2.Zero;
                    var worldPosition = Vector2.Zero;
                    var offset = new Vector2(graphics.PreferredBackBufferWidth * 0.5f, graphics.PreferredBackBufferHeight * 0.5f);

                    cam.ToScreen(ref charPosition, out screenPosition);

                    if (screenPosition.X < -graphics.PreferredBackBufferWidth * 0.55f * 0.5f)
                    {
                        var scr2world = Vector2.Zero;
                        cam.ToWorld(ref screenPosition, out scr2world);

                        var resultPosition = new Vector2(scr2world.X - -graphics.PreferredBackBufferWidth * 0.55f * 0.5f, cam.Position.Y);

                        if (resultPosition.X - offset.X > 0)
                        {
                            cam.Position = resultPosition;
                        }
                    }

                    if (screenPosition.Y < -graphics.PreferredBackBufferHeight * 0.55f * 0.5f)
                    {
                        var scr2world = Vector2.Zero;
                        cam.ToWorld(ref screenPosition, out scr2world);

                        var resultPosition = new Vector2(cam.Position.X, scr2world.Y - -graphics.PreferredBackBufferHeight * 0.55f * 0.5f);

                        if (resultPosition.Y - offset.Y > 0)
                        {
                            cam.Position = resultPosition;
                        }
                    }

                    if (screenPosition.X > graphics.PreferredBackBufferWidth * 0.55f * 0.5f)
                    {
                        var scr2world = Vector2.Zero;
                        cam.ToWorld(ref screenPosition, out scr2world);

                        var resultPosition = new Vector2(scr2world.X - graphics.PreferredBackBufferWidth * 0.55f * 0.5f, cam.Position.Y);

                        if (resultPosition.X + offset.X <= currentStage.block.GetLength(1) * 26) 
                        {
                            cam.Position = resultPosition;
                        }
                    }

                    if (screenPosition.Y > graphics.PreferredBackBufferHeight * 0.55f * 0.5f)
                    {
                        var scr2world = Vector2.Zero;
                        cam.ToWorld(ref screenPosition, out scr2world);

                        var resultPosition = new Vector2(cam.Position.X, scr2world.Y - graphics.PreferredBackBufferHeight * 0.55f * 0.5f);

                        if (resultPosition.Y + offset.Y <= currentStage.block.GetLength(0) * 20 + 50)
                        {
                            cam.Position = resultPosition;
                        }
                    }


                    break;

                case State.end:
                    time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา
                    if(time <= 0)
                    {
                        gamestate = State.menu;
                    }
                    break;

            }

            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //------------------------------- draw game --------------------------------//

            switch (gamestate)
            {
                case State.menu:

                    spriteBatch.Begin();
                    spriteBatch.Draw(start, screen, Color.White);

                    //-------------------------------- draw ui click -----------------------------//
                    if (isPlayClicked == true)
                    {
                        spriteBatch.Draw(ui, playRect, new Rectangle(270, 0, 250, 140), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(ui, playRect, new Rectangle(0, 0, 250, 140), Color.White);
                    }

                    if (isTutorialClicked == true)
                    {
                        spriteBatch.Draw(ui, tutorialRect, new Rectangle(270, 200, 250, 85), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(ui, tutorialRect, new Rectangle(0, 200, 250, 85), Color.White);
                    }

                    if (isExitClicked == true)
                    {
                        spriteBatch.Draw(ui, exitRect, new Rectangle(270, 350, 250, 110), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(ui, exitRect, new Rectangle(0, 350, 250, 110), Color.White);
                    }

                    spriteBatch.End();
                    break;

                case State.tutorial:
                    //------------------------ draw help ---------------------------//
                    spriteBatch.Begin();
                    spriteBatch.Draw(bgHelp, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(board, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(button, new Rectangle(280, 80, 300, 150), new Rectangle(150, 0, 300, 150), Color.White);
                    spriteBatch.Draw(button, backtomenu, new Rectangle(0, 130, 160, 130), Color.White);
                    spriteBatch.End();
                    break;

                case State.pre:
                    spriteBatch.Begin();

                    spriteBatch.Draw(end, new Vector2(0, 0), Color.White);

                    //-------------------------- draw font state ----------------------------//
                    switch (currentStage.stageNumber)
                    {
                        case 1:
                            spriteBatch.Draw(state1_2, new Rectangle(180, 150, 370, 300), new Rectangle(200, 0, 370, 300), Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(state1_2, new Rectangle(180, 200, 450, 650), new Rectangle(200, 300, 450, 650), Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(state1_3, new Rectangle(180, 150, 400, 300), new Rectangle(200, 0, 400, 300), Color.White);
                            break;

                    }

                    //spriteBatch.DrawString(font, "stage " + currentStage.stageNumber, new Vector2(100, 31), Color.White);

                    spriteBatch.End();

                    break;
                case State.play:
                    spriteBatch.Begin(cam);
                    //---------------------------- draw play ------------------------------//
                    currentStage.Draw(spriteBatch,gameTime);
                    
                    spriteBatch.Draw(charTexture, charPosition, new Rectangle(frame * 64, circleSprite, 64, 78), Color.White);
                    spriteBatch.Draw(light, charPosition - new Vector2(light.Width / 2, light.Height / 2) + new Vector2(64 / 2, 78 / 2), Color.White);
                    spriteBatch.End();

                    //---------------------------------- draw time ----------------------------//
                    spriteBatch.Begin();
                    spriteBatch.Draw(clock, new Vector2(5, 5), Color.White);

                    spriteBatch.DrawString(font, time.ToString("0"), new Vector2(100, 31), Color.Black);

                    spriteBatch.End();

                    break;

                case State.end:
                    //------------------------------------- draw end -----------------------------//
                    spriteBatch.Begin();
                    spriteBatch.Draw(end, screen, Color.White);
                    spriteBatch.Draw(state1_1,new Rectangle(120,180,580,200),new Rectangle(100,0,580,200),Color.White);
                    spriteBatch.End();
                    break;

            }

            base.Draw(gameTime);
        }

        void newStage(int stageNumber)
        {

            currentStage = new Stage(stageNumber);

            gamestate = State.pre;
            time = 3;
            
            //-------------------------------- position character -----------------------------//

            switch (stageNumber)
            {
                case 1:
                    charPosition = new Vector2(100, 1600);
                    break;
                case 2:
                    charPosition = new Vector2(50, 300);
                    break;
                case 3:
                    charPosition = new Vector2(50, 1800);
                    break;
            }

            //------------------------- position camera ----------------------//
            cam.Position = charPosition;

            if (cam.Position.X < graphics.PreferredBackBufferWidth/2)
            {
                cam.Position = new Vector2(graphics.PreferredBackBufferWidth / 2,cam.Position.Y);
            }
            if (cam.Position.Y < graphics.PreferredBackBufferHeight / 2)
            {
                cam.Position = new Vector2(cam.Position.X,graphics.PreferredBackBufferHeight / 2);
            }
            if (cam.Position.X> currentStage.block.GetLength(1)*26 - graphics.PreferredBackBufferWidth/2)
            {
                cam.Position = new Vector2(currentStage.block.GetLength(1) * 26 - graphics.PreferredBackBufferWidth / 2, cam.Position.Y);
            }
            if (cam.Position.Y > currentStage.block.GetLength(0) * 20 - graphics.PreferredBackBufferHeight / 2)
            {
                cam.Position = new Vector2(cam.Position.X, currentStage.block.GetLength(0) * 20 - graphics.PreferredBackBufferHeight / 2);
            }
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
