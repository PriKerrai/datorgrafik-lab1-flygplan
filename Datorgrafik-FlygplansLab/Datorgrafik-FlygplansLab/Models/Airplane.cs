using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Datorgrafik_FlygplansLab.Models
{
    public class Airplane : GameObject
    {
        float moveSpeed = 0.01f;

        public Airplane(GraphicsDevice device, Vector3 pos, float scale)
            : base(device, pos, Quaternion.Identity, scale)
        {
            this.Scale = scale;
            AddChild(new Propeller(this.device, new Vector3(-4f , 0f, 1f), 0.9f));
            AddChild(new Propeller(this.device, new Vector3(4f, 0f, 1f), 0.9f));
        }

        protected override void InitializeVertices()
        {
            #region old rotation
            //vertices = new VertexPositionColor[36];

            //Color colorNose = Color.LightBlue;
            //Color colorBody = Color.Black;
            //Color colorWings = Color.Gray;

            //// left facing -----------

            //// nose
            //vertices[0] = new VertexPositionColor(new Vector3(-2, -1, 2), colorNose);
            //vertices[1] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);
            //vertices[2] = new VertexPositionColor(new Vector3(-2, 1, 0), colorNose);

            //// body
            //vertices[3] = new VertexPositionColor(new Vector3(-2, 1, 0), colorBody);
            //vertices[4] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            //vertices[5] = new VertexPositionColor(new Vector3(-2, -1, 2), colorBody);

            //// rear wing
            //vertices[6] = new VertexPositionColor(new Vector3(6, 3, 0), colorWings);
            //vertices[7] = new VertexPositionColor(new Vector3(6, 1, 0), colorWings);
            //vertices[8] = new VertexPositionColor(new Vector3(2, 1, 0), colorWings);


            //// right facing -----------

            //// nose
            //vertices[9] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);
            //vertices[10] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            //vertices[11] = new VertexPositionColor(new Vector3(-2, 1, 0), colorNose);

            //// body
            //vertices[12] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            //vertices[13] = new VertexPositionColor(new Vector3(-2, 1, 0), colorBody);
            //vertices[14] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            //// rear wing
            //vertices[15] = new VertexPositionColor(new Vector3(6, 1, 0), colorWings);
            //vertices[16] = new VertexPositionColor(new Vector3(6, 3, 0), colorWings);
            //vertices[17] = new VertexPositionColor(new Vector3(2, 1, 0), colorWings);

            //// bottom facing -----------

            //// nose
            //vertices[18] = new VertexPositionColor(new Vector3(-2, -1, 2), colorNose);
            //vertices[19] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            //vertices[20] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);

            //// body
            //vertices[21] = new VertexPositionColor(new Vector3(-2, -1, 2), colorBody);
            //vertices[22] = new VertexPositionColor(new Vector3(6, 1, 0), colorBody);
            //vertices[23] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            //// Wing left
            //vertices[24] = new VertexPositionColor(new Vector3(1, 0, 12), colorWings);
            //vertices[25] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            //vertices[26] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);

            //// Wing right
            //vertices[27] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            //vertices[28] = new VertexPositionColor(new Vector3(1, 0, -12), colorWings);
            //vertices[29] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);


            //// top facing -----------

            //// wing left
            //vertices[30] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            //vertices[31] = new VertexPositionColor(new Vector3(1, 0, 12), colorWings);
            //vertices[32] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);

            //// Wing right
            //vertices[33] = new VertexPositionColor(new Vector3(1, 0, -12), colorWings);
            //vertices[34] = new VertexPositionColor(new Vector3(1, 0, 0), colorWings);
            //vertices[35] = new VertexPositionColor(new Vector3(-1.5f, 0, 0), colorWings);
            #endregion

            vertices = new VertexPositionColor[36];

            Color colorNose = Color.LightBlue;
            Color colorBody = Color.Black;
            Color colorWings = Color.Gray;

            // left facing -----------

            // nose
            vertices[0] = new VertexPositionColor(new Vector3(0, -1, -6), colorNose);
            vertices[1] = new VertexPositionColor(new Vector3(2, -1, -2), colorNose);
            vertices[2] = new VertexPositionColor(new Vector3(0, 1, -2), colorNose);

            // body
            vertices[3] = new VertexPositionColor(new Vector3(0, 1, 6), colorBody);
            vertices[4] = new VertexPositionColor(new Vector3(0, 1, -2), colorBody);
            vertices[5] = new VertexPositionColor(new Vector3(2, -1, -2), colorBody);

            // rear wing
            vertices[6] = new VertexPositionColor(new Vector3(0, 1, 6), colorWings);
            vertices[7] = new VertexPositionColor(new Vector3(0, 3, 6), colorWings);
            vertices[8] = new VertexPositionColor(new Vector3(0, 1, 2), colorWings);


            // right facing -----------

            // nose
            vertices[9] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            vertices[10] = new VertexPositionColor(new Vector3(0, -1, -6), colorNose);
            vertices[11] = new VertexPositionColor(new Vector3(0, 1, -2), colorNose);

            // body
            vertices[12] = new VertexPositionColor(new Vector3(0, 1, -2), colorBody);
            vertices[13] = new VertexPositionColor(new Vector3(0, 1, 6), colorBody);
            vertices[14] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            // rear wing
            vertices[15] = new VertexPositionColor(new Vector3(0, 3, 6), colorWings);
            vertices[16] = new VertexPositionColor(new Vector3(0, 1, 6), colorWings);
            vertices[17] = new VertexPositionColor(new Vector3(0, 1, 2), colorWings);

            // bottom facing -----------

            // nose
            vertices[18] = new VertexPositionColor(new Vector3(-2, -1, -2), colorNose);
            vertices[19] = new VertexPositionColor(new Vector3(2, -1, -2), colorNose);
            vertices[20] = new VertexPositionColor(new Vector3(0, -1, -6), colorNose);

            // body
            vertices[21] = new VertexPositionColor(new Vector3(0, 1, 6), colorBody);
            vertices[22] = new VertexPositionColor(new Vector3(2, -1, -2), colorBody);
            vertices[23] = new VertexPositionColor(new Vector3(-2, -1, -2), colorBody);

            // Wing left
            vertices[24] = new VertexPositionColor(new Vector3(0, 0, 1), colorWings);
            vertices[25] = new VertexPositionColor(new Vector3(12, 0, 1), colorWings);
            vertices[26] = new VertexPositionColor(new Vector3(0, 0, -1.5f), colorWings);

            // Wing right
            vertices[27] = new VertexPositionColor(new Vector3(-12, 0, 1), colorWings);
            vertices[28] = new VertexPositionColor(new Vector3(0, 0, 1), colorWings);
            vertices[29] = new VertexPositionColor(new Vector3(0, 0, -1.5f), colorWings);


            // top facing -----------

            // wing left
            vertices[30] = new VertexPositionColor(new Vector3(12, 0, 1), colorWings);
            vertices[31] = new VertexPositionColor(new Vector3(0, 0, 1), colorWings);
            vertices[32] = new VertexPositionColor(new Vector3(0, 0, -1.5f), colorWings);

            // Wing right
            vertices[33] = new VertexPositionColor(new Vector3(0, 0, 1), colorWings);
            vertices[34] = new VertexPositionColor(new Vector3(-12, 0, 1), colorWings);
            vertices[35] = new VertexPositionColor(new Vector3(0, 0, -1.5f), colorWings);
        }

        public override void Draw(ref BasicEffect effect, ref Matrix parentWorld)
        {
            base.Draw(ref effect, ref parentWorld);
        }

        public override void Update(GameTime gameTime)
        {
            float distance = (float)(this.moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            Vector3 addVector = Vector3.Transform(new Vector3(0, 0, 1), Rotation);
            Position += addVector * distance;

            base.Update(gameTime);
        }
    }
} 