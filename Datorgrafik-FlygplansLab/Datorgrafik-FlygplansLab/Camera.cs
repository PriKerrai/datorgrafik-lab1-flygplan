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


        public Camera(GraphicsDevice graphics)
        {
            this.device = graphics;            

            //Settings
            this.AspectRatio = device.DisplayMode.AspectRatio;
            this.Position = new Vector3(0, 3, 5);
            this.nearPlaneDistance = 0.1f;
            this.farPlaneDistance = 10000f;


            this.ViewMatrix = Matrix.CreateLookAt(this.Position, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, this.AspectRatio, this.nearPlaneDistance, this.farPlaneDistance);
        }

        public void Update(Airplane player) {
            this.Rotation = Quaternion.Lerp(this.Rotation, player.airplaneRotation, 0.1f);
            
            Vector3 campos = new Vector3(1, 3, 5);
            campos = Vector3.Transform(campos, Matrix.CreateFromQuaternion(this.Rotation));
            campos += player.CameraPosition;

            Vector3 camup = new Vector3(0, 1, 0);
            camup = Vector3.Transform(camup, Matrix.CreateFromQuaternion(this.Rotation));

            this.Position = campos;
            this.UpDirection = camup;

            this.ViewMatrix = Matrix.CreateLookAt(this.Position, player.CameraPosition, this.UpDirection);
            this.ViewProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, this.AspectRatio, this.nearPlaneDistance, this.farPlaneDistance);
        }

    }
}

