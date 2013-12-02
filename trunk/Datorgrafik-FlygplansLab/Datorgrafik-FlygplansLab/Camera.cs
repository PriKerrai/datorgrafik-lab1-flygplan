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


        public Camera(GraphicsDevice graphics, Vector3 startingPosition)
        {
            this.device = graphics;            

            //Settings
            this.AspectRatio = device.DisplayMode.AspectRatio;
            this.Position = startingPosition;
            this.nearPlaneDistance = 0.0001f;
            this.farPlaneDistance = 100000f;


            this.ViewMatrix = Matrix.CreateLookAt(this.Position, new Vector3(0, 2, 1), new Vector3(0, 1, 0));
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, this.AspectRatio, this.nearPlaneDistance, this.farPlaneDistance);
        }

        public void Update(Airplane airplane) {
            this.Rotation = Quaternion.Lerp(this.Rotation, airplane.airplaneRotation, 0.1f);


            Vector3 campos = new Vector3(0, 0.15f, 0.5f);
            campos = Vector3.Transform(campos, Matrix.CreateFromQuaternion(airplane.airplaneRotation));
            campos += airplane.airplanePosition;

            Vector3 camup = new Vector3(0, 1, 0);
            camup = Vector3.Transform(camup, Matrix.CreateFromQuaternion(airplane.airplaneRotation));

            this.ViewMatrix = Matrix.CreateLookAt(campos, airplane.airplanePosition, camup);
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, nearPlaneDistance, farPlaneDistance);
        }

    }
}

