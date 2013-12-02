using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Datorgrafik_FlygplansLab.Models
{
    public class Airplane : GameComponent
    {

        public VertexPositionColor[] airplaneVertices { get; set; }
        public Vector3 CameraPosition { get; set; }


        private GraphicsDevice device;
        private VertexBuffer airPlaneVertexBuffer;

        public Vector3 airplanePosition = new Vector3(8, 1, -3);
        public Quaternion airplaneRotation = Quaternion.Identity;
        private float MoveSpeed = 2f;

        public Airplane(Game game)
            : base(game)
        {
            
        }

        public void loadAirplane(GraphicsDevice graphicsDevice, Vector3 playerLocation, float minDistance)
        {
            device = graphicsDevice;

            InitializeVertices();

            airPlaneVertexBuffer = new VertexBuffer(device, VertexPositionTexture.VertexDeclaration, airplaneVertices.Length, BufferUsage.WriteOnly);
            airPlaneVertexBuffer.SetData<VertexPositionColor>(airplaneVertices.ToArray());

        }



        public void InitializeVertices()
        {
            airplaneVertices = new VertexPositionColor[36];

            Color colorNose = Color.White;
            Color colorBody = Color.Black;
            Color colorWings = Color.Gray;

            // left facing -----------

            // nose
            airplaneVertices[0] = new VertexPositionColor(new Vector3(-2, -1, 2), colorNose);
            airplaneVertices[1] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);
            airplaneVertices[2] = new VertexPositionColor(new Vector3(-2, 1, 0), colorNose);

            // body
            airplaneVertices[3] = new VertexPositionColor(new Vector3(-2, 1, 0), colorBody);
            airplaneVertices[4] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            airplaneVertices[5] = new VertexPositionColor(new Vector3(-2, -1, 2), colorBody);

            // rear wing
            airplaneVertices[6] = new VertexPositionColor(new Vector3(6, 3, 0), colorWings);
            airplaneVertices[7] = new VertexPositionColor(new Vector3(6, 1, 0), colorWings);
            airplaneVertices[8] = new VertexPositionColor(new Vector3(2, 1, 0), colorWings);


            // right facing -----------

            // nose
            airplaneVertices[9] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);
            airplaneVertices[10] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            airplaneVertices[11] = new VertexPositionColor(new Vector3(-2, 1, 0), colorNose);

            // body
            airplaneVertices[12] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            airplaneVertices[13] = new VertexPositionColor(new Vector3(-2, 1, 0), colorBody);
            airplaneVertices[14] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            // rear wing
            airplaneVertices[15] = new VertexPositionColor(new Vector3(6, 1, 0), colorWings);
            airplaneVertices[16] = new VertexPositionColor(new Vector3(6, 3, 0), colorWings);
            airplaneVertices[17] = new VertexPositionColor(new Vector3(2, 1, 0), colorWings);

            // bottom facing -----------

            // nose
            airplaneVertices[18] = new VertexPositionColor(new Vector3(-2, -1, 2), colorNose);
            airplaneVertices[19] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            airplaneVertices[20] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);

            // body
            airplaneVertices[21] = new VertexPositionColor(new Vector3(-2, -1, 2), colorBody);
            airplaneVertices[22] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            airplaneVertices[23] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            // Wing left
            airplaneVertices[24] = new VertexPositionColor(new Vector3(1, 0, 12), colorWings);
            airplaneVertices[25] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            airplaneVertices[26] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);

            // Wing right
            airplaneVertices[27] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            airplaneVertices[28] = new VertexPositionColor(new Vector3(1, 0, -12), colorWings);
            airplaneVertices[29] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);


            // top facing -----------

            // wing left
            airplaneVertices[30] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            airplaneVertices[31] = new VertexPositionColor(new Vector3(1, 0, 12), colorWings);
            airplaneVertices[32] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);

            // Wing right
            airplaneVertices[33] = new VertexPositionColor(new Vector3(1, 0, -12), colorWings);
            airplaneVertices[34] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            airplaneVertices[35] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);
        }

        public void Draw(Camera camera, BasicEffect effect)
        {
            effect.VertexColorEnabled = true;

            Matrix worldMatrix = Matrix.CreateScale(0.005f, 0.005f, 0.005f) * Matrix.CreateRotationY(MathHelper.Pi) * Matrix.CreateFromQuaternion(airplaneRotation) * Matrix.CreateTranslation(airplanePosition);
            effect.World = worldMatrix;
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ViewProjectionMatrix;
            
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(airPlaneVertexBuffer);

                device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, airplaneVertices, 0, 12);

            }
        }

        public override void Update(GameTime gameTime)
        {
            float distance = (float)(this.MoveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            Vector3 addVector = Vector3.Transform(new Vector3(1, 0, 0), airplaneRotation);
            this.airplanePosition += addVector * distance;
            this.CameraPosition += addVector * distance;

            base.Update(gameTime);
        }

    }
} 