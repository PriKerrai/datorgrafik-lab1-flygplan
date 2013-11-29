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

            

            #region helpstuffz
            
            //vertices[0] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.Brown);
            //vertices[1] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Brown);
            //vertices[2] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.Brown);
            //vertices[3] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Brown);

            //vertices[4] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.Red);
            //vertices[5] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.Red);
            //vertices[6] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Red);
            //vertices[7] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Red);

            //vertices[8] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.Green);
            //vertices[9] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Green);
            //vertices[10] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.Green);
            //vertices[11] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Green);

            //vertices[12] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.Blue);
            //vertices[13] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.Blue);
            //vertices[14] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Blue);
            //vertices[15] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Blue);

            //vertices[16] = new VertexPositionColor(new Vector3(1.0f, 1.0f, -2.0f), Color.Black);
            //vertices[17] = new VertexPositionColor(new Vector3(1.0f, 1.0f, 2.0f), Color.Black);
            //vertices[18] = new VertexPositionColor(new Vector3(1.0f, -1.0f, -2.0f), Color.Black);
            //vertices[19] = new VertexPositionColor(new Vector3(1.0f, -1.0f, 2.0f), Color.Black);

            //vertices[20] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, -2.0f), Color.White);
            //vertices[21] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, -2.0f), Color.White);
            //vertices[22] = new VertexPositionColor(new Vector3(-1.0f, 1.0f, 2.0f), Color.White);
            //vertices[23] = new VertexPositionColor(new Vector3(-1.0f, -1.0f, 2.0f), Color.White);

            //// wings
            //vertices[33] = new VertexPositionColor(new Vector3(-5f, -2f, 0f), Color.Black);
            //vertices[34] = new VertexPositionColor(new Vector3(5f, -2f, 0f), Color.Black);
            //vertices[35] = new VertexPositionColor(new Vector3(-5f, -2f, 0f), Color.Black);

            //vertices[40] = new VertexPositionColor(new Vector3(-2f, -5f, 0f), Color.Black);
            ////// Top right
            //vertices[41] = new VertexPositionColor(new Vector3(-2f, 5f, 0f), Color.Black);
            ////// Bottom right
            //vertices[42] = new VertexPositionColor(new Vector3(-2f, -5f, 0f), Color.Black);

            //// left side
            //vertices[0] = new VertexPositionColor(new Vector3(0, 1, 1), Color.White);
            //vertices[1] = new VertexPositionColor(new Vector3(2, 1, 1), Color.White);
            //vertices[2] = new VertexPositionColor(new Vector3(0, -1, 1), Color.White);
            //vertices[3] = new VertexPositionColor(new Vector3(2, -1, 1), Color.White);

            //// right side
            //vertices[10] = new VertexPositionColor(new Vector3(0, 1, -1), Color.Black);
            //vertices[11] = new VertexPositionColor(new Vector3(2, 1, -1), Color.Black);
            //vertices[12] = new VertexPositionColor(new Vector3(0, -1, -1), Color.Black);
            //vertices[13] = new VertexPositionColor(new Vector3(2, -1, -1), Color.Black);

            //// front side
            //vertices[20] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Blue);
            //vertices[21] = new VertexPositionColor(new Vector3(2, 1, 1), Color.Blue);
            //vertices[22] = new VertexPositionColor(new Vector3(0, 1, -1), Color.Blue);
            //vertices[23] = new VertexPositionColor(new Vector3(2, 1, -1), Color.Blue);

            //// left side
            //vertices[0] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.White);
            //vertices[1] = new VertexPositionColor(new Vector3(1, 1, 1), Color.White);
            //vertices[2] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);
            //vertices[3] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);

            //// right side
            //vertices[10] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Black);
            //vertices[11] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Black);
            //vertices[12] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Black);
            //vertices[13] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Black);

            //// front side
            //vertices[20] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            //vertices[21] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);
            //vertices[22] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);
            //vertices[23] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Blue);


            //vertices = new VertexPositionColor[36];

            ////Windshield
            //Color windshieldColor = new Color(125, 203, 245);
            //// Top left
            //vertices[0] = new VertexPositionColor(new Vector3(-0.5f, 0.5f, -0.5f), windshieldColor);
            //// Bottom right
            //vertices[1] = new VertexPositionColor(new Vector3(0.5f, 0f, 0.5f), windshieldColor);
            //// Bottom left
            //vertices[2] = new VertexPositionColor(new Vector3(-0.5f, 0f, 0.5f), windshieldColor);
            //// Top right
            //vertices[3] = new VertexPositionColor(new Vector3(0.5f, 0.5f, -0.5f), windshieldColor);
            //// Rightside
            //vertices[4] = new VertexPositionColor(new Vector3(0.5f, 0f, -0.5f), windshieldColor);
            //// Leftside
            //vertices[5] = new VertexPositionColor(new Vector3(-0.5f, 0f, -0.5f), windshieldColor);

            ////Wings
            //Color wingColor = new Color(163, 181, 191);
            //// Top left
            //vertices[6] = new VertexPositionColor(new Vector3(-4f, 0.5f, -1.5f), wingColor);
            //// Top right
            //vertices[7] = new VertexPositionColor(new Vector3(4f, 0.5f, -1.5f), wingColor);
            //// Bottom right
            //vertices[8] = new VertexPositionColor(new Vector3(4f, 0.5f, -0.5f), wingColor);
            //// Bottom left
            //vertices[9] = new VertexPositionColor(new Vector3(-4f, 0.5f, -0.5f), wingColor);

            ////Body
            //Color bodyColor = new Color(255, 247, 0);
            //// Front top left
            //vertices[16] = new VertexPositionColor(new Vector3(-0.5f, 0f, 0.5f), bodyColor);
            //// Front top right
            //vertices[17] = new VertexPositionColor(new Vector3(0.5f, 0f, 0.5f), bodyColor);
            //// Front bottom left
            //vertices[18] = new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.5f), bodyColor);
            //// Front bottom right
            //vertices[19] = new VertexPositionColor(new Vector3(0.5f, -0.5f, 0.5f), bodyColor);

            //// Side-Right-Front top right
            //vertices[20] = new VertexPositionColor(new Vector3(0.5f, 0f, -0.5f), bodyColor);
            //// Side-Right-Front bottom right
            //vertices[21] = new VertexPositionColor(new Vector3(0.5f, -0.5f, -0.5f), bodyColor);

            //// Side-Left-Front top left
            //vertices[22] = new VertexPositionColor(new Vector3(-0.5f, 0f, -0.5f), bodyColor);
            //// Side-Left-Front bottom left
            //vertices[23] = new VertexPositionColor(new Vector3(-0.5f, -0.5f, -0.5f), bodyColor);

            //// Side-Right-Back top left
            //vertices[24] = new VertexPositionColor(new Vector3(0.5f, 0.5f, -0.5f), bodyColor);
            //// Side-Right-Back top right
            //vertices[25] = new VertexPositionColor(new Vector3(0.25f, 0.5f, -4f), bodyColor);
            //// Side-Right-Back bottom right
            //vertices[26] = new VertexPositionColor(new Vector3(0.25f, 0.25f, -4f), bodyColor);

            //// Side-Left-Back top left
            //vertices[27] = new VertexPositionColor(new Vector3(-0.25f, 0.5f, -4f), bodyColor);
            //// Side-Left-Back top right
            //vertices[28] = new VertexPositionColor(new Vector3(-0.5f, 0.5f, -0.5f), bodyColor);
            //// Side-Left-Back bottom left
            //vertices[29] = new VertexPositionColor(new Vector3(-0.25f, 0.25f, -4f), bodyColor);

            //// Top top left
            //vertices[30] = new VertexPositionColor(new Vector3(0.5f, 0.5f, -1.5f), bodyColor);
            //// Top top right
            //vertices[31] = new VertexPositionColor(new Vector3(-0.5f, 0.5f, -1.5f), bodyColor);

            //// Backwing top left
            //vertices[32] = new VertexPositionColor(new Vector3(0f, 1.25f, -4f), bodyColor);
            //// Backwing top right
            //vertices[33] = new VertexPositionColor(new Vector3(0f, 1.25f, -5f), bodyColor);
            //// Backwing bottom left
            //vertices[34] = new VertexPositionColor(new Vector3(0f, 0.5f, -3f), bodyColor);
            //// Backwing bottom right
            //vertices[35] = new VertexPositionColor(new Vector3(0f, 0.5f, -4f), bodyColor);
            #endregion
        }

        private Random rand = new Random();

        //public void PositionCube(Vector3 playerLocation, float minDistance) {
        //Vector3 newLocation;
        //do
        //{
        //    newLocation = new Vector3(
        //    rand.Next(0, Ground.mazeWidth) + 0.5f,
        //    0.5f,
        //    rand.Next(0, Ground.mazeHeight) + 0.5f);
        //}
        //while (
        //    Vector3.Distance(playerLocation, newLocation) < minDistance);
        //    location = newLocation;
        //}
        
    }
}