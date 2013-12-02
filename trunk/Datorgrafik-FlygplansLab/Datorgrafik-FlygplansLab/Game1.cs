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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        Airplane airplane;
        Ground ground;
        Houses houses;
        VertexBuffer vertexBuffer;

        BasicEffect effect;

        Matrix worldTranslation = Matrix.Identity;
        Matrix worldRotation = Matrix.Identity;

        float moveScale = 1.5f;
        float rotateScale = MathHelper.PiOver2;

        //RasterizerState WIREFRAME_RASTERIZER_STATE = new RasterizerState() { CullMode = CullMode.CullCounterClockwiseFace, FillMode = FillMode.Solid };

        public Game1()
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
            camera = new Camera(
                new Vector3(-5f, 0.5f, 0.5f),
                0,
                GraphicsDevice.Viewport.AspectRatio,
                0.05f,
                100f);
            effect = new BasicEffect(GraphicsDevice);
            ground = new Ground(GraphicsDevice);
            houses = new Houses(GraphicsDevice);
            
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

            // Set vertex data in VertexBuffer
            //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), airplane.airplaneVertices.Length, BufferUsage.None);
            //vertexBuffer.SetData<VertexPositionColor>(airplane.airplaneVertices);

            airplane = new Airplane(this.GraphicsDevice, camera.Position, 10f);

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
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyState = Keyboard.GetState();
            float moveAmount = 0;

            if (keyState.IsKeyDown(Keys.D))
            {
                camera.Rotation = MathHelper.WrapAngle(
                camera.Rotation - (rotateScale * elapsed));
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                camera.Rotation = MathHelper.WrapAngle(
                camera.Rotation + (rotateScale * elapsed));
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                //camera.MoveForward(moveScale * elapsed);
                moveAmount = moveScale * elapsed;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                //camera.MoveForward(-moveScale * elapsed);
                moveAmount = -moveScale * elapsed;
            }
            if (moveAmount != 0)
            {
                Vector3 newLocation = camera.PreviewMove(moveAmount);
                bool moveOk = true;
                if (newLocation.X < 0 || newLocation.X > Ground.groundWidth)
                    moveOk = false;
                if (newLocation.Z < 0 || newLocation.Z > Ground.groundHeight)
                    moveOk = false;
                if (moveOk)
                    camera.MoveForward(moveAmount);
            }

            // Allows the game to exit
            if (keyState.IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            effect.World = worldRotation * worldTranslation;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                //ground.Draw(camera, effect);
                airplane.Draw(camera, effect);
                //houses.Draw(camera, effect);
            }

            base.Draw(gameTime);
        }

    }
}
