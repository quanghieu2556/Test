using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Model model = null;
        List<GameVisibleEntity> entites = new List<GameVisibleEntity>();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        float t = 0;
        float dt = 0.1f;
        float R = 15;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures. 
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GLOBAL.Content = Content;
            
            GLOBAL.CurCam = new Camera(new Vector3(0, 140, 20), new Vector3(0, 0, 0), new Vector3(0, 0, -1), MathHelper.PiOver4, 4f / 3f, 0.1f, 10000f);
            for(int r = -2; r<=2; r++)
                for(int c = -3; c<= 3; c++)
                {
        
                entites.Add(new Building("china_monastery", new Vector3(r*5f,0,c*5f),1f,1f,1f,0f,0f,0f));
                }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            GLOBAL.CurCam.Update(gameTime);
            for (int i = 0; i < entites.Count; i++)
                entites[i].Update(gameTime);
            t += dt;
            Vector3 pos = new Vector3(0,0,0);
            pos.Y = 0;
            pos.X = 10 + R * (float)Math.Sin(t);
            pos.Z = 10 + R * (float)Math.Cos(t);
            //entites[0].Position = pos;
            GLOBAL.CurCam.Position = pos;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
            for (int i = 0; i < entites.Count; i++)
            {
                entites[i].Draw(gameTime,GraphicsDevice);
            }
        }
    }
}
