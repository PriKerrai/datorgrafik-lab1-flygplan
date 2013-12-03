using System;
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
        private float rotation = 0;
        private float rotateSpeed = 1f;
        private float scale = .012f;
        
        public Quaternion propellerRotation = Quaternion.Identity;
        public Quaternion additionalRot = Quaternion.Identity;
        public Vector3 position;
        Matrix world;
        Matrix oldWorld;

        public Propeller(Game game)
        : base(game)
        { }

        public Propeller(Game game, Vector3 position, GraphicsDevice device)
            : base(game)
        {
            this.device = device;
            this.position = position;
            world = Matrix.CreateTranslation(position);
            game.Components.Add(this);
            this.Enabled = true;
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

            // BladeTop
            propellerVertices[19] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerBlade);
            propellerVertices[18] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            propellerVertices[20] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerBlade);

            // BladeBot
            propellerVertices[22] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerBlade);
            propellerVertices[21] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            propellerVertices[23] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerBlade);

            // ThingyOneTop
            propellerVertices[26] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);
            propellerVertices[24] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerThingy);
            propellerVertices[25] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);

            // ThingyTwoTop
            propellerVertices[29] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);
            propellerVertices[27] = new VertexPositionColor(new Vector3(-.4f, 2.5f, 0), propellerThingy);
            propellerVertices[28] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);

            // ThingyOneBot
            propellerVertices[31] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerThingy);
            propellerVertices[30] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerThingy);
            propellerVertices[32] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);

            // ThingyTwoBot
            propellerVertices[34] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);
            propellerVertices[33] = new VertexPositionColor(new Vector3(-.6f, -2.5f, 0), propellerThingy);
            propellerVertices[35] = new VertexPositionColor(new Vector3(-.6f, -2f, 0), propellerThingy);
        }

        public void Draw(BasicEffect effect)
        {
            effect.VertexColorEnabled = true;

            oldWorld = effect.World;

            Matrix propMatrix = Matrix.CreateScale(scale, scale, scale) * Matrix.CreateFromQuaternion(propellerRotation) * Matrix.CreateTranslation(position);

            effect.World = propMatrix;

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
            rotation += rotateSpeed;
            propellerRotation *= additionalRot;
            this.propellerRotation *= Quaternion.CreateFromAxisAngle(Vector3.UnitZ, rotation);

            base.Update(gameTime);

        }
    }


}

            

           
