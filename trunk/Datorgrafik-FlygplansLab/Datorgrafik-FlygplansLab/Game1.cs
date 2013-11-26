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

namespace GrafikTest
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
        VertexBuffer vertexBuffer;
        BasicEffect effect;

        Matrix worldTranslation = Matrix.Identity;
        Matrix worldRotation = Matrix.Identity;

        RasterizerState WIREFRAME_RASTERIZER_STATE = new RasterizerState() { CullMode = CullMode.CullCounterClockwiseFace, FillMode = FillMode.Solid };

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            airplane = new Airplane();

            //MAX FPS SPEED WROOM
            this.IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            
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
            camera = new Camera(this, new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            Components.Add(camera);
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

            airplane.InitializeIndices();
            airplane.InitializeVertices();

            // Set vertex data in VertexBuffer
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), airplane.vertices.Length, BufferUsage.None);
            vertexBuffer.SetData(airplane.vertices);

            //---
            GraphicsDevice.RasterizerState = WIREFRAME_RASTERIZER_STATE;
            //---


            //Initialize the BasicEffect
            effect = new BasicEffect(GraphicsDevice);
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keyboardState = Keyboard.GetState();
            // move left
            if (keyboardState.IsKeyDown(Keys.A))
                worldTranslation *= Matrix.CreateTranslation(-.005f, 0, 0);
            // move right
            if (keyboardState.IsKeyDown(Keys.D))
                worldTranslation *= Matrix.CreateTranslation(.005f, 0, 0);
            // move up
            if (keyboardState.IsKeyDown(Keys.W))
                worldTranslation *= Matrix.CreateTranslation(0, .005f, 0);
            // move down
            if (keyboardState.IsKeyDown(Keys.S))
                worldTranslation *= Matrix.CreateTranslation(0, -.005f, 0);
            // yaw left
            if(keyboardState.IsKeyDown(Keys.Q)) {
            worldRotation *= Matrix.CreateFromYawPitchRoll(MathHelper.PiOver4 / 60, 0, 0);
            }
            // yaw right
            if(keyboardState.IsKeyDown(Keys.E)) {
            worldRotation *= Matrix.CreateFromYawPitchRoll(MathHelper.PiOver4 / 60, 0, 0);
            }
            // pith up
            if (keyboardState.IsKeyDown(Keys.R))
            {
                worldRotation *= Matrix.CreateFromYawPitchRoll(0, MathHelper.PiOver4 / 60, 0);
            }
            // pith down
            if (keyboardState.IsKeyDown(Keys.F))
            {
                worldRotation *= Matrix.CreateFromYawPitchRoll(0, MathHelper.PiOver4 / 60, 0);
            }

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
            effect.View = camera.view;
            effect.Projection = camera.projection;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, airplane.vertices, 0, 98);
            }

            base.Draw(gameTime);
        }
    }
}
