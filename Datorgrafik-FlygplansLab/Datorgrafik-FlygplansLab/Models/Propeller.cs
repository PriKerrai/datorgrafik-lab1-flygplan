using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Datorgrafik_FlygplansLab.Models;

namespace Datorgrafik_FlygplansLab.Models
{
    public class Propeller : GameObject
    {
        private float propellerRotation = 0f;

        public Propeller(GraphicsDevice device, Vector3 pos, float scale)
            : base(device, pos, Quaternion.Identity, scale)
        { }

        protected override void InitializeVertices()
        {
            vertices = new VertexPositionColor[36];

            Color propellerThingy = Color.Red;
            Color propellerBlade = Color.Brown;

            // BladeTop
            vertices[0] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerBlade);
            vertices[1] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            vertices[2] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerBlade);

            // BladeBot
            vertices[3] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerBlade);
            vertices[4] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            vertices[5] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerBlade);

            // ThingyOneTop
            vertices[7] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);
            vertices[6] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerThingy);
            vertices[8] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);

            // ThingyTwoTop
            vertices[10] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);
            vertices[9] = new VertexPositionColor(new Vector3(-.4f, 2.5f, 0), propellerThingy);
            vertices[11] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);

            // ThingyOneBot
            vertices[14] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerThingy);
            vertices[12] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerThingy);
            vertices[13] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);

            // ThingyTwoBot
            vertices[17] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);
            vertices[15] = new VertexPositionColor(new Vector3(-.6f, -2.5f, 0), propellerThingy);
            vertices[16] = new VertexPositionColor(new Vector3(-.6f, -2f, 0), propellerThingy);

            // BladeTop
            vertices[19] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerBlade);
            vertices[18] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            vertices[20] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerBlade);

            // BladeBot
            vertices[22] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerBlade);
            vertices[21] = new VertexPositionColor(new Vector3(0, 0, 0), propellerBlade);
            vertices[23] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerBlade);

            // ThingyOneTop
            vertices[26] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);
            vertices[24] = new VertexPositionColor(new Vector3(.6f, 2, 0), propellerThingy);
            vertices[25] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);

            // ThingyTwoTop
            vertices[29] = new VertexPositionColor(new Vector3(.4f, 2.5f, 0), propellerThingy);
            vertices[27] = new VertexPositionColor(new Vector3(-.4f, 2.5f, 0), propellerThingy);
            vertices[28] = new VertexPositionColor(new Vector3(-.6f, 2, 0), propellerThingy);

            // ThingyOneBot
            vertices[31] = new VertexPositionColor(new Vector3(-.6f, -2, 0), propellerThingy);
            vertices[30] = new VertexPositionColor(new Vector3(.6f, -2, 0), propellerThingy);
            vertices[32] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);

            // ThingyTwoBot
            vertices[34] = new VertexPositionColor(new Vector3(.4f, -2.5f, 0), propellerThingy);
            vertices[33] = new VertexPositionColor(new Vector3(-.6f, -2.5f, 0), propellerThingy);
            vertices[35] = new VertexPositionColor(new Vector3(-.6f, -2f, 0), propellerThingy);
        }

        //public void Draw(BasicEffect effect)
        //{
        //    effect.VertexColorEnabled = true;

        //    oldWorld = effect.World;

        //    Matrix propMatrix = Matrix.CreateScale(scale, scale, scale) * Matrix.CreateFromQuaternion(propellerRotation) * Matrix.CreateTranslation(position);

        //    effect.World = propMatrix;

        //    // position propeller

  
        //    foreach (EffectPass pass in effect.CurrentTechnique.Passes)
        //    {
        //        pass.Apply();
        //        device.SetVertexBuffer(propellerVertexBuffer);
        //        device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, 12);
        //    }
        //}

        public override void Update(GameTime gameTime)
        {
            propellerRotation += 0.75f;

            this.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, propellerRotation);

            base.Update(gameTime);
        }
    }


}

            

           
