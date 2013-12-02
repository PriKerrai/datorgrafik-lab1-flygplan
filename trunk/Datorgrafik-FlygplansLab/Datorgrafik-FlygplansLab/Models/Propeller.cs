﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Datorgrafik_FlygplansLab.Models
{
    class Propeller
    {
        private GraphicsDevice device;
        private VertexBuffer propellerVertexBuffer;

        public VertexPositionColor[] propellerVertices { get; set; }
        private float rotateSpeed = 0.05f;
        
        public Quaternion propellerRotation = Quaternion.Identity;
        public Vector3 propellerPosition = new Vector3(25, 6, 100);

        public Propeller(GraphicsDevice device)
        {
            this.device = device;
            loadPropeller(device);
        }

        public void loadPropeller(GraphicsDevice graphicsDevice)
        {
            device = graphicsDevice;

            InitializeVertices();

            propellerVertexBuffer = new VertexBuffer(device, VertexPositionTexture.VertexDeclaration, propellerVertices.Length, BufferUsage.WriteOnly);
            propellerVertexBuffer.SetData<VertexPositionColor>(propellerVertices.ToArray());

        }

        private void InitializeVertices()
        {
            propellerVertices = new VertexPositionColor[36];

            Color propellerThingy = Color.Red;
            Color propellerBlade = Color.Brown;

            // BladeTop
            propellerVertices[0] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerBlade);
            propellerVertices[1] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            propellerVertices[2] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerBlade);

            // BladeBot
            propellerVertices[3] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerBlade);
            propellerVertices[4] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            propellerVertices[5] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerBlade);

            // ThingyOneTop
            propellerVertices[7] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);
            propellerVertices[6] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerThingy);
            propellerVertices[8] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);

            // ThingyTwoTop
            propellerVertices[10] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);
            propellerVertices[9] = new VertexPositionColor(new Vector3(-.4f, 2.5f, 0), propellerThingy);
            propellerVertices[11] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);

            // ThingyOneBot
            propellerVertices[14] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerThingy);
            propellerVertices[12] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerThingy);
            propellerVertices[13] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);

            // ThingyTwoBot
            propellerVertices[17] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);
            propellerVertices[15] = new VertexPositionColor(new Vector3(-.6f, -2.5f, 0), propellerThingy);
            propellerVertices[16] = new VertexPositionColor(new Vector3(-.6f, -2f, 0), propellerThingy);
        }

        public void Draw(Camera camera, BasicEffect effect)
        {
            effect.VertexColorEnabled = true;

            //Matrix worldMatrix = Matrix.CreateScale(0.15f, 0.15f, 0.15f) * Matrix.CreateRotationY(MathHelper.ToRadians(270)) * Matrix.CreateFromQuaternion(airplaneRotation) * Matrix.CreateTranslation();
            effect.World = Matrix.Identity;
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ViewProjectionMatrix;

            Vector3 rotAxis = new Vector3(0, 0, rotateSpeed);
            rotAxis.Normalize();
            Matrix worldMatrix = Matrix.CreateFromAxisAngle(rotAxis, rotateSpeed);
            effect.World = worldMatrix;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(propellerVertexBuffer);

                device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, propellerVertices, 0, 12);

            }
        }

        public void Update(GameTime gameTime)
        {
            rotateSpeed += 0.0005f;
                
        }
    }
}
