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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera
    {

        private GraphicsDevice device;
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 UpDirection { get; set; }
        public Matrix ViewMatrix { get; set; }
        public Matrix ViewProjectionMatrix { get; set; }

        public float AspectRatio { get; set; }
        public float nearPlaneDistance { get; set; }
        public float farPlaneDistance { get; set; }

        public bool Lerp { get; set; }

        public Camera(GraphicsDevice graphics, Vector3 startingPosition)
        {
            this.device = graphics;            

            //Settings
            this.AspectRatio = device.DisplayMode.AspectRatio;
            this.Position = startingPosition;
            this.nearPlaneDistance = 0.01f;
            this.farPlaneDistance = 1000f;


            this.ViewMatrix = Matrix.CreateLookAt(this.Position, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, this.AspectRatio, this.nearPlaneDistance, this.farPlaneDistance);
        }

        public void Update(Airplane airplane) {

            if (Lerp)
            {
                this.Rotation = Quaternion.Lerp(this.Rotation, airplane.airplaneRotation, 0.1f);
            }
            
            Vector3 campos = new Vector3(0f, 0.15f, 0.5f);
            campos = Vector3.Transform(campos, Matrix.CreateFromQuaternion(Rotation));
            campos += airplane.airplanePosition;

            Vector3 camup = new Vector3(0, 1, 0);
            camup = Vector3.Transform(camup, Matrix.CreateFromQuaternion(Rotation));

            this.Position = campos;
            this.UpDirection = camup;

            this.ViewMatrix = Matrix.CreateLookAt(this.Position, airplane.airplanePosition, this.UpDirection);
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, nearPlaneDistance, farPlaneDistance);
        }

        

    }
}

