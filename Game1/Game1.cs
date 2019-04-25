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
            talk,
            play,
            tower,
            end
        };

        State gamestate;

        public enum Scene
        {
            palace,
            forest,
            tower,
        };

        Scene scene;

        public enum Character
        {
            prince,
            princess,
            knight
        };

        Character character;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D start, end;
        public static Texture2D blx;
        public static Texture2D bg1, bg2, bg3, b4;
        public static Texture2D glassBlock;
        public static Texture2D hex;
        public static Texture2D wood1, wood2, wood3, wood4;
        public static Texture2D enter;
        public static Texture2D exit;
        public static Texture2D charTexture;
        public static Texture2D hexTexture;
        public static Texture2D light;
        public static Texture2D blockBlood, blood;
        public static Texture2D fire;

        public static Texture2D bgForest;
        public static Texture2D bgTower;
        public static Texture2D bgPalace;
        public static Texture2D prince;
        public static Texture2D princess;
        public static Texture2D knight;
        public static Texture2D message;
        public static Texture2D nextScreen;
        public static Texture2D skip;

        
        Texture2D clock;
        Texture2D ui;
        Texture2D bgHelp;
        Texture2D board;
        Texture2D button;
        Texture2D state1_1;
        Texture2D state1_2;
        Texture2D state1_3;
        
        Texture2D towerbg;
        Texture2D tower;
        Texture2D flag;

        //Vector2 position = new Vector2(0, 0);

        Vector2 flagPosition3 = new Vector2(440 - 100, 227);
        Vector2 flagPosition2 = new Vector2(450 - 100, 347);
        Vector2 flagPosition1 = new Vector2(460 - 100, 475);

        SpriteFont font;
        Rectangle screen;


        float time = 0;

        bool startScreen = true, endScreen = false;
        bool grassBlockHit;

        Camera cam;

        //------------------------ collision mouse click ----------------------//

        Rectangle playRect = new Rectangle(0, 180, 250, 140);
        Rectangle tutorialRect = new Rectangle(0, 310, 250, 85);
        Rectangle exitRect = new Rectangle(0, 385, 250, 110);
        Rectangle backtomenu = new Rectangle(0, 0, 160, 130);
        Rectangle nextRect = new Rectangle(650, 515, 36, 31);
        Rectangle skipRect = new Rectangle(700, 5, 74, 71);


        bool isPlayClicked = false;
        bool isTutorialClicked = false;
        bool isExitClicked = false;
        bool isBackClicked = false;
        bool isNextsceneClicked = false;
        bool isSkipClicked = false;


        public Stage currentStage;

        public Player player;

        int sceneNumber;
        int dialougeIndex;
        string[] dialouge = new string[]
        {
        };

        string[] sc1_dialouge = new string[]
        {
            "ฟหกดฟหกดฟหกด",
            "ดหกฟดฟหกดฟหกดฟหดกฟหดกห"
        };

        string[] sc2_dialouge = new string[]
        {
            "dfsddsfgsdfgds",
            "asfdasdfasdf"
        };

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

            player = new Player(this);

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            blx = new Texture2D(GraphicsDevice, 1, 1);
            blx.SetData(new[] { Color.White });

            bg1 = Content.Load<Texture2D>("bgstage1");
            bg2 = Content.Load<Texture2D>("bgstage2 (1)");
            font = Content.Load<SpriteFont>("default");
            charTexture = Content.Load<Texture2D>("splite1 (1)");
            hexTexture = Content.Load<Texture2D>("splite2 (1)");
            glassBlock = Content.Load<Texture2D>("object1");
            clock = Content.Load<Texture2D>("timeblood_01");
            start = Content.Load<Texture2D>("bgMenu");
            end = Content.Load<Texture2D>("end");
            ui = Content.Load<Texture2D>("menu2");
            light = Content.Load<Texture2D>("light2");
            bgHelp = Content.Load<Texture2D>("bghelp");
            board = Content.Load<Texture2D>("howto");
            button = Content.Load<Texture2D>("button");
            state1_1 = Content.Load<Texture2D>("font1");
            state1_2 = Content.Load<Texture2D>("font2");
            state1_3 = Content.Load<Texture2D>("font3");
            enter = Content.Load<Texture2D>("object2 (2)");
            exit = Content.Load<Texture2D>("object3");
            blockBlood = Content.Load<Texture2D>("timeblood_02");
            blood = Content.Load<Texture2D>("timeblood_03");
            fire = Content.Load<Texture2D>("firefire");

            towerbg = Content.Load<Texture2D>("bglevelup");
            tower = Content.Load<Texture2D>("levelup_02");
            flag = Content.Load<Texture2D>("levelup_01");

            wood1 = Content.Load<Texture2D>("wood_01");
            wood2 = Content.Load<Texture2D>("wood_02");
            wood3 = Content.Load<Texture2D>("wood_03");
            wood4 = Content.Load<Texture2D>("wood_04");

            bgPalace = Content.Load<Texture2D>("bgpalace");
            bgForest = Content.Load<Texture2D>("bgforest");
            bgTower = Content.Load<Texture2D>("bgtower");
            prince = Content.Load<Texture2D>("princepng_01");
            princess = Content.Load<Texture2D>("princess&knight_02");
            knight = Content.Load<Texture2D>("princess&knight_01");
            message = Content.Load<Texture2D>("message (1)_01");
            nextScreen = Content.Load<Texture2D>("button_08");
            skip = Content.Load<Texture2D>("button_01");



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
                            //newStage(4);
                            sceneNumber = 0;
                            gamestate = State.talk;
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

                case State.talk:

                    switch (sceneNumber)
                    {
                        case 0:
                            // start bg
                            scene = Scene.palace;
                            // start charecter
                            character = Character.knight;
                            // set dialogue
                            dialouge = sc1_dialouge;
                            Console.WriteLine(dialouge);
                            break;
                        case 1:
                            // start bg
                            scene = Scene.palace;
                            // start charecter
                            character = Character.knight;
                            dialouge = sc2_dialouge;
                            break;
                    }

                    if(mouseRect.Intersects(nextRect) == true)
                    {
                        if (mouse.LeftButton == ButtonState.Released && isNextsceneClicked == true)
                        {
                            dialougeIndex++;

                            switch (sceneNumber)
                            {
                                case 0:
                                    switch (dialougeIndex)
                                    {
                                        case 1:
                                            character = Character.knight;
                                            break;
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                        case 6:
                                            character = Character.princess;
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (dialougeIndex)
                                    {
                                        case 1:
                                            character = Character.prince;
                                            break;
                                        case 2:
                                            character = Character.knight;
                                            break;
                                    }
                                    break;
                            }


                            if (dialougeIndex == dialouge.Length)
                            {
                                dialougeIndex = 0;
                                endDialogue();
                            }

                        }
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            isNextsceneClicked = true;
                        }
                        else
                        {
                            isNextsceneClicked = false;
                        }
                    }
                    if(mouseRect.Intersects(skipRect) == true)
                    {
                        if(mouse.LeftButton == ButtonState.Released && isSkipClicked == true)
                        {
                            endDialogue();
                        }
                        if(mouse.LeftButton == ButtonState.Pressed)
                        {
                            isSkipClicked = true;
                        }
                        else
                        {
                            isSkipClicked = false;
                        }
                    }
                    break;

                case State.play:
                    currentStage.Update(gameTime);
                    player.Update(gameTime, keyboard);

                    switch (currentStage.stageNumber)
                    {
                        case 1:
                        case 2:
                        case 3:
                            time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา

                            if (time <= 0)
                            {
                                time = 3;
                                gamestate = State.end;

                            }
                            break;
                    }
                    //------------------------- camera -------------------------------------//

                    var screenPosition = Vector2.Zero;
                    var worldPosition = Vector2.Zero;
                    var offset = new Vector2(graphics.PreferredBackBufferWidth * 0.5f, graphics.PreferredBackBufferHeight * 0.5f);

                    cam.ToScreen(ref player.position, out screenPosition);

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

                case State.tower:

                    time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา
                    if (time <= 0)
                    {
                        newStage(currentStage.stageNumber + 1);
                    }

                    switch (currentStage.stageNumber)
                    {
                        case 3:
                            flagPosition1.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds / 4;
                            break;
                        case 4:
                            flagPosition2.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds / 4;
                            break;
                        case 7:
                            flagPosition3.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds / 4;
                            break;
                    }

                    break;

                case State.end:
                    time -= (float)gameTime.ElapsedGameTime.TotalSeconds; //ตัวที่จะทำให้ + หรือ - ค่าเวลา
                    if (time <= 0)
                    {
                        gamestate = State.menu;
                    }
                    break;

            }

            base.Update(gameTime);

        }

        void endDialogue()
        {

            switch (sceneNumber)
            {
                case 0:
                    newStage(4);
                    break;
                case 1:
                    newStage(1);
                    break;
            }
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
                        case 4:
                            spriteBatch.Draw(state1_3, new Rectangle(180, 200, 440, 650), new Rectangle(200, 300, 450, 650), Color.White);
                            break;

                    }

                    //spriteBatch.DrawString(font, "stage " + currentStage.stageNumber, new Vector2(100, 31), Color.White);

                    spriteBatch.End();

                    break;
                case State.play:
                    spriteBatch.Begin(cam);
                    //---------------------------- draw play ------------------------------//
                    currentStage.Draw(spriteBatch, gameTime);
                    player.Draw(spriteBatch, gameTime);
                    spriteBatch.End();

                    //---------------------------------- draw time ----------------------------//
                    spriteBatch.Begin();
                    //spriteBatch.Draw(blood, new Vector2(550, 30), Color.White);

                    float healthwidth = blood.Width * player.health/5f;

                    spriteBatch.Draw(blood,new Rectangle(580, 40,(int)healthwidth, 30), new Rectangle(0, 0, (int)healthwidth, 30), Color.White);
                    spriteBatch.Draw(blockBlood, new Vector2(530, 20), Color.White);
                    switch (currentStage.stageNumber)
                    {
                        case 1:
                        case 2:
                        case 3:
                            spriteBatch.Draw(clock, new Rectangle(10, 5, 192, 88), Color.White);
                            spriteBatch.DrawString(font, time.ToString("0"), new Vector2(110, 40), Color.Black);


                            //spriteBatch.DrawString(font, player.health.ToString("0"), new Vector2(400, 40), Color.White);

                            break;
                    }
                    spriteBatch.End();

                    break;


                case State.tower:
                    //------------------------------------- draw tower -----------------------------//
                    spriteBatch.Begin();
                    spriteBatch.Draw(towerbg, new Vector2(0,0), Color.White);
                    spriteBatch.Draw(flag, flagPosition1, Color.White);
                    spriteBatch.Draw(flag, flagPosition2, Color.White);
                    spriteBatch.Draw(flag, flagPosition3, Color.White);

                    spriteBatch.Draw(tower, new Vector2((graphics.PreferredBackBufferWidth - tower.Width) / 2, graphics.PreferredBackBufferHeight - tower.Height), Color.White);

                    spriteBatch.End();
                    break;

                case State.end:
                    //------------------------------------- draw end -----------------------------//
                    spriteBatch.Begin();
                    spriteBatch.Draw(end, screen, Color.White);
                    spriteBatch.Draw(state1_1, new Rectangle(120, 180, 580, 200), new Rectangle(100, 0, 580, 200), Color.White);
                    spriteBatch.End();
                    break;

                    //----------------------------- draw cut screen -------------------//
                case State.talk:
                    spriteBatch.Begin();
                    switch (scene)
                    {
                        case Scene.palace:
                            spriteBatch.Draw(bgPalace, new Vector2(0, 0), Color.White);
                            break;
                        case Scene.forest:
                            spriteBatch.Draw(bgForest, new Vector2(0, 0), Color.White);
                            break;
                        case Scene.tower:
                            spriteBatch.Draw(bgTower, new Vector2(0, 0), Color.White);
                            break;

                    }

                    switch (character)
                    {
                        case Character.prince:
                            spriteBatch.Draw(prince, new Vector2(100, 50), Color.White);
                            break;
                        case Character.princess:
                            spriteBatch.Draw(princess, new Vector2(350, 50), Color.White);
                            break;
                        case Character.knight:
                            spriteBatch.Draw(knight, new Vector2(100, 50), Color.White);
                            break;
                    }

                    
                    spriteBatch.Draw(message, new Vector2(100, 300), Color.White);

                    spriteBatch.Draw(nextScreen, nextRect, Color.White);
                    spriteBatch.Draw(skip, skipRect, Color.White);

                    if (dialouge.Length != 0)
                    {
                        spriteBatch.DrawString(font, dialouge[dialougeIndex], new Vector2(200, 400), Color.Black);

                    }

                    spriteBatch.End();
                    break;

            }

            base.Draw(gameTime);
        }

        public void GameOver()
        {
            time = 3;
            gamestate = State.end;
        }

        void newStage(int stageNumber)
        {

            currentStage = new Stage(this,stageNumber);

            gamestate = State.pre;
            time = 3;
            player.health = 5;

            //-------------------------------- position character -----------------------------//

            switch (stageNumber)
            {
                case 1:
                    player.position = new Vector2(0, 1650);
                    break;
                case 2:
                    player.position = new Vector2(0, 230);
                    break;
                case 3:
                    player.position = new Vector2(0, 1850);
                    break;
                case 4:
                    player.position = new Vector2(0, 270);
                    break;

            }

            //------------------------- position camera ----------------------//
            cam.Position = player.position;

            if (cam.Position.X < graphics.PreferredBackBufferWidth / 2)
            {
                cam.Position = new Vector2(graphics.PreferredBackBufferWidth / 2, cam.Position.Y);
            }
            if (cam.Position.Y < graphics.PreferredBackBufferHeight / 2)
            {
                cam.Position = new Vector2(cam.Position.X, graphics.PreferredBackBufferHeight / 2);
            }
            if (cam.Position.X > currentStage.block.GetLength(1) * 26 - graphics.PreferredBackBufferWidth / 2)
            {
                cam.Position = new Vector2(currentStage.block.GetLength(1) * 26 - graphics.PreferredBackBufferWidth / 2, cam.Position.Y);
            }
            if (cam.Position.Y > currentStage.block.GetLength(0) * 20 - graphics.PreferredBackBufferHeight / 2)
            {
                cam.Position = new Vector2(cam.Position.X, currentStage.block.GetLength(0) * 20 - graphics.PreferredBackBufferHeight / 2);
            }
        }

        public void progressNextStage()
        {

            if (currentStage.stageNumber == 3 || currentStage.stageNumber == 4 || currentStage.stageNumber == 7)
            {
                //
                time = 4;
                gamestate = State.tower;
            }
            else
            {
                newStage(currentStage.stageNumber + 1);
            }
        }
    }
}
