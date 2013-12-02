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
        Propeller propellerLeft;
        Propeller propellerRight;
        float gameSpeed = 1.0f;

        BasicEffect effect;

        Matrix worldTranslation = Matrix.Identity;
        Matrix worldRotation = Matrix.Identity;

        //RasterizerState WIREFRAME_RASTERIZER_STATE = new RasterizerState() { CullMode = CullMode.CullCounterClockwiseFace, FillMode = FillMode.Solid };

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
            // TODO: Add your initialization logic here
            effect = new BasicEffect(GraphicsDevice);
            ground = new Ground(GraphicsDevice);
            houses = new Houses(GraphicsDevice);
            airplane = new Airplane(this);
            propellerLeft = new Propeller(this);
            propellerRight = new Propeller(this);

            
            
            
            
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

            airplane.loadAirplane(GraphicsDevice, camera.Position, 10f);
            propellerLeft.loadPropeller(GraphicsDevice);
            propellerRight.loadPropeller(GraphicsDevice);

            // add game components so that they update themselves
            this.Components.Add(airplane);
            this.Components.Add(propellerLeft);
            this.Components.Add(propellerRight);

            // Set cullmode to none
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;
            // TODO: use this.Content to load your game content here
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

            //airplane.Update(gameTime);
            //propellerLeft.Update(gameTime);
            //propellerRight.Update(gameTime);
            camera.Update(airplane);
            base.Update(gameTime);
        }

        private void ProcessInput(GameTime gameTime)
        {
            float leftRightRot = 0;

            float turningSpeed = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            turningSpeed *= 1.6f * gameSpeed;
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.A))
                leftRightRot += turningSpeed;
            if (keys.IsKeyDown(Keys.D))
                leftRightRot -= turningSpeed;

            float upDownRot = 0;
            if (keys.IsKeyDown(Keys.S))
                upDownRot += turningSpeed;
            if (keys.IsKeyDown(Keys.W))
                upDownRot -= turningSpeed;

            Quaternion additionalRot = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, -1), leftRightRot) * Quaternion.CreateFromAxisAngle(new Vector3(1, 0, 0), upDownRot);
            
            airplane.airplaneRotation *= additionalRot;
            propellerLeft.propellerRotation *= additionalRot;
            propellerRight.propellerRotation *= additionalRot;
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
            effect.World = worldRotation * worldTranslation;
            effect.VertexColorEnabled = true;

            

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Vector3 proLeftPos = new Vector3(airplane.airplanePosition.X, airplane.airplanePosition.Y, airplane.airplanePosition.Z);
                propellerLeft.propellerPosition = proLeftPos;
                Vector3 proRightPos = new Vector3(airplane.airplanePosition.X, airplane.airplanePosition.Y, airplane.airplanePosition.Z);
                propellerRight.propellerPosition = proRightPos;

                propellerLeft.Draw(camera, effect);
                propellerRight.Draw(camera, effect);

                ground.Draw(camera, effect);
                airplane.Draw(camera, effect);
                houses.Draw(camera, effect);
            }

            base.Draw(gameTime);
        }

    }
}
