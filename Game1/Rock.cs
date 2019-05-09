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
    public class Rock
    {
        Game1 game;

        protected int frame;
        protected float totalElapsed;
        protected float timePerFrame;
        protected int framePerSec;
    }

    public Rock(Game1 game)
    {

    }

    public void Update(GameTime gameTime)
    {
        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);


    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {


    }

    protected void UpdateFrame(float elapsed)
    {
        totalElapsed += elapsed;
        if (totalElapsed > timePerFrame)
        {
            frame = (frame + 1) % (maxframe + 1); //Console.WriteLine(frame);
            if (frame == maxframe)
            {
                row++; frame -= maxframe;
            }
            if (row == maxrow) row = 0;
            //Console.WriteLine(frame + " " + row);
            totalElapsed -= timePerFrame;
        }
    }
}
