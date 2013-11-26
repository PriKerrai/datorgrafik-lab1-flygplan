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
            vertices = new VertexPositionColor[36];

        }

        public void InitializeIndices()
        {
            
        }

    }
}
