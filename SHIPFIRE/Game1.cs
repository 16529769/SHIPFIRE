using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHIPFIRE
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ship player;

        Texture2D background;

        List<EnemySpawn> enemyspawn = new List<EnemySpawn>();

        Random random = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background");

            // TODO: use this.Content to load your game content here
            player = new Ship(Content, new Vector2(150, 200));
            player.SetControls(Keys.A, Keys.D, Keys.W, Keys.Space);
        }

       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        float spawn = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(new List<Ship> { });

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (EnemySpawn enemy2 in enemyspawn)
                enemy2.Update(graphics.GraphicsDevice);
            // TODO: Add your update logic here
            LoadEnemies();
            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randY = random.Next(100, 600);
            if(spawn>1)
            {
                spawn = 0;
                if (enemyspawn.Count() < 10)
                {
                    enemyspawn.Add(new EnemySpawn(Content.Load<Texture2D>("enemy1"), new Vector2(1270, randY)));
                }
            }

            for(int i =0; i<enemyspawn.Count;i++)
            {
                if(!enemyspawn[i].isvisible)
                {
                    enemyspawn.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);

            player.Draw(spriteBatch);

            foreach (EnemySpawn enemy2 in enemyspawn)
                enemy2.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
