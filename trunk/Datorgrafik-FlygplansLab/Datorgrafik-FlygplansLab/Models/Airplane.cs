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

        public VertexPositionColor[] airplaneVertices { get; set; }

        public void InitializeVertices()
        {
            airplaneVertices = new VertexPositionColor[100];
            
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
    }
}