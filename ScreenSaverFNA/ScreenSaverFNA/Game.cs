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
        Texture2D snowflakeTexture;
        Texture2D backgroundTexture;
        const int SnowflakesCount = 100;
        int activeSnowflakesCount = 0;
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

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            snowflakeTexture = Content.Load<Texture2D>("snowflake");
            backgroundTexture = Content.Load<Texture2D>("switzerkand");
            var rnd = new Random();
            var Sizes = new[] { 32, 64 };
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

            // TODO: Add your update logic here
            for (var i = 0; i < activeSnowflakesCount; i++)
            {
                Snowflakes[i].Y += Snowflakes[i].Speed;
                if (Snowflakes[i].Y > graphics.PreferredBackBufferHeight)
                {
                    Snowflakes[i].Y = -Snowflakes[i].Size;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
