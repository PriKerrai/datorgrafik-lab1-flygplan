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
            //Initialize vertices
            vertices = new VertexPositionColor[3];
            vertices[0] = new VertexPositionColor(new Vector3(0, 1, -10), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Green);
            vertices[2] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Blue);

        }

        public void InitializeIndices()
        {
            
        }

    }
}
