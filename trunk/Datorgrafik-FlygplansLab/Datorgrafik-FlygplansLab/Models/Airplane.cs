using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Datorgrafik_FlygplansLab.Models
{
    public class Airplane
    {

        public short[] indices { get; set; }
        public VertexPositionColor[] vertices { get; set; }

        public void InitializeVertices()
        {
            // 
            vertices = new VertexPositionColor[100];


            vertices[0] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.Black);
            vertices[1] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Black);
            vertices[2] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.Black);
            vertices[3] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Black);

            vertices[4] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.Red);
            vertices[5] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.Red);
            vertices[6] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Red);
            vertices[7] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Red);

            vertices[8] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.Red);
            vertices[9] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Red);
            vertices[10] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.Red);
            vertices[11] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Red);

            vertices[12] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.Red);
            vertices[13] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.Red);
            vertices[14] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Red);
            vertices[15] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Red);

            vertices[16] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Red);
            vertices[17] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Red);
            vertices[18] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Red);
            vertices[19] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Red);

            vertices[20] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.Red);
            vertices[21] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.Red);
            vertices[22] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.Red);
            vertices[23] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.Red);

            
            //vertices[33] = new VertexPositionColor(new Vector3(-5f, -2f, 0f), Color.Black);
            
            //vertices[34] = new VertexPositionColor(new Vector3(5f, -2f, 0f), Color.Black);
            
            //vertices[35] = new VertexPositionColor(new Vector3(-5f, -2f, 0f), Color.Black);

            //vertices[40] = new VertexPositionColor(new Vector3(-2f, -5f, 0f), Color.Black);
            //// Top right
            //vertices[41] = new VertexPositionColor(new Vector3(-2f, 5f, 0f), Color.Black);
            //// Bottom right
            //vertices[42] = new VertexPositionColor(new Vector3(-2f, -5f, 0f), Color.Black);


        }

        public void InitializeIndices()
        {

            short[] indices = new short[6];

            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            indices[3] = 0;
            indices[4] = 3;
            indices[5] = 1;

            
        }

    }
}