using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace GrafikTest
{
    class Airplane
    {

        public int[] indices { get; set; }
        public VertexPositionColor[] vertices { get; set; }

        public void InitializeVertices()
        {
            // 
            vertices = new VertexPositionColor[100];


            //vertices[0] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), Color.Magenta);
            //vertices[1] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), Color.Magenta);
            //vertices[2] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), Color.Magenta);
            //vertices[3] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), Color.Magenta);

            //vertices[4] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), Color.Magenta);
            //vertices[5] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), Color.Magenta);
            //vertices[6] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), Color.Magenta);
            //vertices[7] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), Color.Magenta);

            //vertices[8] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), Color.Chartreuse);
            //vertices[9] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), Color.Chartreuse);
            //vertices[10] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), Color.Chartreuse);
            //vertices[11] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), Color.Chartreuse);

            //vertices[12] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), Color.Magenta);
            //vertices[13] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), Color.Magenta);
            //vertices[14] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), Color.Magenta);
            //vertices[15] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), Color.Magenta);

            //vertices[16] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), Color.Magenta);
            //vertices[17] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 1.0f), Color.Magenta);
            //vertices[18] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -1.0f), Color.Magenta);
            //vertices[19] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 1.0f), Color.Magenta);

            //vertices[20] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f), Color.Magenta);
            //vertices[21] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), Color.Magenta);
            //vertices[22] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 1.0f), Color.Magenta);
            //vertices[23] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 1.0f), Color.Magenta);

            // left side
            vertices[0] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.White);
            vertices[1] = new VertexPositionColor(new Vector3(1, 1, 1), Color.White);
            vertices[2] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);
            vertices[3] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);

            // right side
            vertices[10] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Black);
            vertices[11] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Black);
            vertices[12] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Black);
            vertices[13] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Black);

            // front side
            vertices[20] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            vertices[21] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);
            vertices[22] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);
            vertices[23] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Blue);
        }

        public void InitializeIndices()
        {
            
        }

    }
}
