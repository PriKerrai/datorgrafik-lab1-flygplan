﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Datorgrafik_FlygplansLab.Models;

namespace Datorgrafik_FlygplansLab.Models
{
    public class Propeller : DrawableGameComponent
    {
        private GraphicsDevice device;
        private VertexBuffer propellerVertexBuffer;

        public VertexPositionColor[] propellerVertices { get; set; }
        private float rotateSpeed = 0.05f;
        private float MoveSpeed = 1.5f;
        
        public Quaternion propellerRotation = Quaternion.Identity;
        public Vector3 propellerPosition;
        Matrix oldWorld;

        public Propeller(Game game)
        : base(game)
        {

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
            //Vector3 rotAxis = new Vector3(0, 0, rotateSpeed);
            //rotAxis.Normalize();

            //Matrix rotationMatrix = Matrix.CreateFromAxisAngle(rotAxis, rotateSpeed);
            //effect.World = rotationMatrix;
            oldWorld = effect.World;

            Matrix propMatrix = oldWorld * Matrix.Identity * Matrix.CreateScale(0.015f, 0.015f, 0.015f) * Matrix.CreateFromQuaternion(propellerRotation) * Matrix.CreateTranslation(propellerPosition);

            effect.World = propMatrix;
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ViewProjectionMatrix;

            // position propeller
  
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(propellerVertexBuffer);
                device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, propellerVertices, 0, 12);

            }
        }

        public override void Update(GameTime gameTime)
        {
            rotateSpeed += 0.7f;

            this.propellerRotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, rotateSpeed);

            base.Update(gameTime);

        }
    }


}

            

           