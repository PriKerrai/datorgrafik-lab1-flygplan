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


namespace Datorgrafik_FlygplansLab
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {

        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }
        float speed = 0.005f;

        //Camera vectors
        public Vector3 cameraPosition { get; protected set; }
        Vector3 cameraDirection;
        Vector3 cameraUp;
        MouseState prevMouseState;


        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up)
            : base(game)
        {
            // Build camera view matrix
            cameraPosition = pos;
            cameraDirection = target - pos;
            cameraDirection.Normalize();
            cameraUp = up;
            CreateLookAt();

            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, 
                (float)Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height,
                1,
                100);

            // TODO: Construct any child components here
        }

        private void CreateLookAt()
        {
            view = Matrix.CreateLookAt(cameraPosition,cameraPosition + cameraDirection, cameraUp);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            // Set mouse position and do initial get state
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2,
            Game.Window.ClientBounds.Height / 2);
            prevMouseState = Mouse.GetState();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            // Move forward/backward
            if (Keyboard.GetState( ).IsKeyDown(Keys.W))
            cameraPosition += cameraDirection * speed;
            if (Keyboard.GetState( ).IsKeyDown(Keys.S))
            cameraPosition -= cameraDirection * speed;
            // Move side to side
            if (Keyboard.GetState( ).IsKeyDown(Keys.A))
            cameraPosition += Vector3.Cross(cameraUp, cameraDirection) * speed;
            if (Keyboard.GetState( ).IsKeyDown(Keys.D))
            cameraPosition -= Vector3.Cross(cameraUp, cameraDirection) * speed;
            
            // Yaw rotation
            cameraDirection = Vector3.Transform(cameraDirection,
            Matrix.CreateFromAxisAngle(cameraUp, (-MathHelper.PiOver4 / 350) *
            (Mouse.GetState( ).X - prevMouseState.X)));
            
            
            // Reset prevMouseState
            prevMouseState = Mouse.GetState( );
            // Roll rotation
            if (Mouse.GetState( ).LeftButton == ButtonState.Pressed)
            {
            cameraUp = Vector3.Transform(cameraUp,
            Matrix.CreateFromAxisAngle(cameraDirection,
            MathHelper.PiOver4 / 400));
            }
            if (Mouse.GetState( ).RightButton == ButtonState.Pressed)
            {
            cameraUp = Vector3.Transform(cameraUp,
            Matrix.CreateFromAxisAngle(cameraDirection,
            -MathHelper.PiOver4 / 400));
            }

            // Pitch rotation
            cameraDirection = Vector3.Transform(cameraDirection,
            Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection),
            (MathHelper.PiOver4 / 400) *
            (Mouse.GetState( ).Y - prevMouseState.Y)));
            cameraUp = Vector3.Transform(cameraUp,
            Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection),
            (MathHelper.PiOver4 / 400) *
            (Mouse.GetState( ).Y - prevMouseState.Y)));

            CreateLookAt();
            base.Update(gameTime);
        }
    }
}
