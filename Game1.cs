using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hobbyprojekt
{
    public class Game1 : Game
    {
        //https://docs.monogame.net/articles/getting_started/3_understanding_the_code.html
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 ballVelocity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            ballVelocity = new Vector2(550f, 400f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                ballPosition.Y -= ballVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Down))
                ballPosition.Y += ballVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Left))
                ballPosition.X -= ballVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Right))
                ballPosition.X += ballVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            else if (ballPosition.X < ballTexture.Width / 2)
                ballPosition.X = ballTexture.Width / 2;

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            else if (ballPosition.Y < ballTexture.Height / 2)
                ballPosition.Y = ballTexture.Height / 2;          



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballPosition,null,Color.White,0f,new Vector2(ballTexture.Width/2,ballTexture.Height/2),Vector2.One,SpriteEffects.None,0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
