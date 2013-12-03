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

        public FlygplanX2000()
        {

            graphics = new GraphicsDeviceManager(this);
        
            //MAX FPS SPEED WROOM
            this.IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;

            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;

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
            effect = new BasicEffect(GraphicsDevice);
            ground = new Ground(GraphicsDevice);
            houses = new Houses(GraphicsDevice);
            airplane = new Airplane(this, GraphicsDevice);

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
            
            this.camera = new Camera(GraphicsDevice, new Vector3(0, 55, 55));
            effect.Projection = camera.ViewProjectionMatrix;

            // Set cullmode to none
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;
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
            float moveSpeed = gameTime.ElapsedGameTime.Milliseconds / 500.0f * gameSpeed;
            
            MoveForward(ref airplane.airplanePosition, airplane.airplaneRotation, moveSpeed);

            camera.Update(airplane);
            base.Update(gameTime);
        }

        private void ProcessInput(GameTime gameTime)
        {
            

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
                Debug.Write("Airplane Position: " + airplane.airplanePosition + "\n Propeller Position:   " + airplane.propLeft.position + "\n");

            Quaternion additionalRot = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, -1), leftRightRot) * Quaternion.CreateFromAxisAngle(new Vector3(1, 0, 0), upDownRot) * Quaternion.CreateFromAxisAngle(new Vector3(0, 1, 0), yawRot);

            airplane.airplaneRotation *= additionalRot;
            airplane.propLeft.additionalRot = additionalRot;
            airplane.propRight.additionalRot = additionalRot;
        }

        private void MoveForward(ref Vector3 position, Quaternion rotationQuaternion, float speed)
        {
            Vector3 addVector = Vector3.Transform(new Vector3(1, 0, 0), rotationQuaternion);
            position += addVector * speed;
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
            effect.VertexColorEnabled = true;

            ground.Draw(effect);
            airplane.Draw(effect);
            houses.Draw(effect);

            base.Draw(gameTime);
        }

    }
}
