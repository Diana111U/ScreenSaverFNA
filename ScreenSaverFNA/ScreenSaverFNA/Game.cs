using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ScreenSaverFNA.Classes;
using System;

namespace ScreenSaverFNA
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private const int SnowflakesCount = 1250;
        private int activeSnowflakesCount = 0;
        private readonly Snowflake[] Snowflakes = new Snowflake[SnowflakesCount];

        public Game()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snowflakeTexture = Content.Load<Texture2D>("snowflake");
            backgroundTexture = Content.Load<Texture2D>("switzerkand");
            var rnd = new Random();
            var Sizes = new[] { 24, 32 };
            for (var i = 0; i < SnowflakesCount; i++)
            {
                var x = rnd.Next(graphics.PreferredBackBufferWidth);
                var size = Sizes[rnd.Next(2)];
                var y = -size;
                var speed = 6 * size / 64;
                Snowflakes[i] = new Snowflake(x, y, size, speed);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }
            for (var i = 0; i < activeSnowflakesCount; i++)
            {
                Snowflakes[i].Y += Snowflakes[i].Speed;
                if (Snowflakes[i].Y > graphics.PreferredBackBufferHeight)
                {
                    Snowflakes[i].Y = -Snowflakes[i].Size;
                }
            }
            if (activeSnowflakesCount < SnowflakesCount)
            {
                activeSnowflakesCount++;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            for (int i = 0; i < activeSnowflakesCount; i++)
            {
                spriteBatch.Draw(snowflakeTexture, new Rectangle(Snowflakes[i].X, Snowflakes[i].Y, Snowflakes[i].Size, Snowflakes[i].Size), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
