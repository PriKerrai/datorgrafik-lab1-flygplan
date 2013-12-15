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
using Datorgrafik_FlygplansLab.Models;
using System.Diagnostics;

namespace Datorgrafik_FlygplansLab
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FlygplanX2000 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        Airplane airplane;
        Ground ground;
        Houses houses;
        float gameSpeed = 1.0f;
        BasicEffect effect;
        SoundEffect engineSound;
        SoundEffectInstance soundeffectInstance;
        RasterizerState rs = new RasterizerState() { CullMode = CullMode.CullCounterClockwiseFace, FillMode = FillMode.Solid };

        public FlygplanX2000()
        {
            // graphics settings
            graphics = new GraphicsDeviceManager(this);
            //this.IsFixedTimeStep = false;
            //graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = false;

            Components.Add(new FPS(this));
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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            effect = new BasicEffect(GraphicsDevice);
            

            // setup sound
            engineSound = Content.Load<SoundEffect>("Running");
            Song song = Content.Load<Song>("1944 UST - Opening");
            MediaPlayer.Play(song);
            
            soundeffectInstance = engineSound.CreateInstance();
            soundeffectInstance.IsLooped = true;
            soundeffectInstance.Volume = 0.3f;
            soundeffectInstance.Play();

            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            
            // setup effect
            this.camera = new Camera(GraphicsDevice, new Vector3(-10, 25, 10));
            effect.VertexColorEnabled = true;
            effect.Projection = camera.ViewProjectionMatrix;
            
            // Set cullmode to none
            //rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;

            // add objects
            ground = new Ground(GraphicsDevice);
            houses = new Houses(GraphicsDevice);
            airplane = new Airplane(GraphicsDevice, new Vector3(25, 5, 25), .1f);
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
            ProcessInput(gameTime);
            MoveAirPlane(gameTime);

            airplane.Update(gameTime);
            camera.Update(airplane);

            base.Update(gameTime);
        }

        private void ProcessInput(GameTime gameTime)
        {
            #region Controlling airplane
            
            float turningSpeed = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            turningSpeed *= 1.6f * gameSpeed;
            KeyboardState keys = Keyboard.GetState();

            float yawRot = 0;
            if (keys.IsKeyDown(Keys.Q))
                yawRot += turningSpeed;
            if (keys.IsKeyDown(Keys.E))
                yawRot -= turningSpeed;

            float leftRightRot = 0;
            if (keys.IsKeyDown(Keys.D))
                leftRightRot += turningSpeed;
            if (keys.IsKeyDown(Keys.A))
                leftRightRot -= turningSpeed;

            float upDownRot = 0;
            if (keys.IsKeyDown(Keys.W))
                upDownRot += turningSpeed;
            if (keys.IsKeyDown(Keys.S))
                upDownRot -= turningSpeed;

            if (keys.IsKeyDown(Keys.B))
                camera.Lerp = true;
            if (keys.IsKeyDown(Keys.N))
                camera.Lerp = false;

            Quaternion additionalRot = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, -1), leftRightRot) 
                                       * Quaternion.CreateFromAxisAngle(new Vector3(1, 0, 0), upDownRot) 
                                       * Quaternion.CreateFromAxisAngle(new Vector3(0, 1, 0), yawRot);

            airplane.Rotation *= additionalRot;

            #endregion
        }

        private void MoveAirPlane(GameTime gameTime)
        {
            float moveSpeed = gameTime.ElapsedGameTime.Milliseconds / 500.0f * gameSpeed;
            Vector3 addVector = Vector3.Transform(new Vector3(0, 0, -1), airplane.Rotation);
            airplane.Position += addVector * moveSpeed;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            effect.View = camera.ViewMatrix;
            effect.World = Matrix.Identity;
            effect.CurrentTechnique.Passes[0].Apply();

            Matrix identity = Matrix.Identity;

            ground.Draw(effect);
            airplane.Draw(ref effect, ref identity);
            houses.Draw(effect);

            base.Draw(gameTime);
        }

    }
}
