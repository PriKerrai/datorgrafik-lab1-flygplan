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
            vertices = new VertexPositionColor[100];

            Color colorNose = Color.White;

            // left side

            // nose
            vertices[0] = new VertexPositionColor(new Vector3(-2, -1, 2), colorNose);
            vertices[1] = new VertexPositionColor(new Vector3(-6, -1, 0), colorNose);
            vertices[2] = new VertexPositionColor(new Vector3(-2, 1, 0), colorNose);

            // body
            vertices[3] = new VertexPositionColor(new Vector3(-2, 1, 0), Color.Black);
            vertices[4] = new VertexPositionColor(new Vector3(6, 1, 0), Color.Black);
            vertices[5] = new VertexPositionColor(new Vector3(-2, -1, 2), Color.Black);
            
            // B - nose right
            vertices[6] = new VertexPositionColor(new Vector3(6, 3, 0), Color.Gray);
            vertices[7] = new VertexPositionColor(new Vector3(6, 1, 0), Color.Gray);
            vertices[8] = new VertexPositionColor(new Vector3(2, 1, 0), Color.Gray);

            // C - nose top left


            // D - nose top right


            // E - nose bot left


            // F - nose bot right


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

        public void InitializeIndices()
        {

            //short[] indices = new short[6];

            //indices[0] = 0;
            //indices[1] = 1;
            //indices[2] = 2;
            //indices[3] = 0;
            //indices[4] = 3;
            //indices[5] = 1;

            //6 vertices make up 2 triangles which make up our rectangle

            #region morehelkpstuzz
            
            //indices = new short[102];

            ////Windshield
            ////Front Triangle 1 (bottom portion) |\
            //indices[0] = 0; //top left;
            //indices[1] = 1; // bottom right;
            //indices[2] = 2; // bottom left;

            ////Front Triangle 2 (top portion) \|
            //indices[3] = 0; // top left;
            //indices[4] = 3; // top right;
            //indices[5] = 1; // bottom right;

            ////Right Triangle /|
            //indices[6] = 3; //top left;
            //indices[7] = 4; // bottom right;
            //indices[8] = 1; // bottom left;

            ////Left Triangle |\
            //indices[9] = 0; // top left;
            //indices[10] = 2; // top right;
            //indices[11] = 5; // bottom right;

            ////Wings
            ////Wings Triangle 1 (top portion) \|
            //indices[12] = 6; // top left;
            //indices[13] = 7; // top right;
            //indices[14] = 8; // bottom right;

            ////Wings Triangle 2 (bottom portion) |\
            //indices[15] = 6; // top left;
            //indices[16] = 8; // top right;
            //indices[17] = 9; // bottom right;

            ////Wings Triangle 1 (top portion) \|
            //indices[18] = 6; // top left;
            //indices[19] = 8; // top right;
            //indices[20] = 7; // bottom right;

            ////Wings Triangle 2 (bottom portion) |\
            //indices[21] = 6; // top left;
            //indices[22] = 9; // top right;
            //indices[23] = 8; // bottom right;

            ////Body
            //// Front Triangle 1 (top portion) |/
            //indices[36] = 16; // top left;
            //indices[37] = 17; // top right;
            //indices[38] = 18; // bottom right;
            //// Front Triangle 2 (bottom portion) /|
            //indices[39] = 17; // top left;
            //indices[40] = 19; // top right;
            //indices[41] = 18; // bottom right;  

            //// Side-Right-Front Triangle 1 (top portion) |/
            //indices[42] = 17; // top left;
            //indices[43] = 20; // top right;
            //indices[44] = 19; // bottom right;
            //// Side-Right-Front Triangle 2 (bottom portion) /|
            //indices[45] = 20; // top left;
            //indices[46] = 21; // top right;
            //indices[47] = 19; // bottom right;

            //// Side-Left-Front Triangle 1 (top portion) |/
            //indices[48] = 22; // top left;
            //indices[49] = 16; // top right;
            //indices[50] = 23; // bottom right;
            //// Side-Left-Front Triangle 2 (bottom portion) /|
            //indices[51] = 16; // top left;
            //indices[52] = 18; // top right;
            //indices[53] = 23; // bottom right;


            //// Side-Right-Back Triangle 1 (top portion) |/
            //indices[54] = 24; // top left;
            //indices[55] = 25; // top right;
            //indices[56] = 21; // bottom right;
            //// Side-Right-Back Triangle 2 (bottom portion) /|
            //indices[57] = 25; // top left;
            //indices[58] = 26; // top right;
            //indices[59] = 21; // bottom right;

            //// Side-Left-Back Triangle 1 (top portion) |/
            //indices[60] = 27; // top left;
            //indices[61] = 28; // top right;
            //indices[62] = 29; // bottom right;
            //// Side-Left-Back Triangle 2 (bottom portion) /|
            //indices[63] = 28; // top left;
            //indices[64] = 23; // top right;
            //indices[65] = 29; // bottom right;


            //// Bottom-Front Triangle 1 (top portion) |/
            //indices[66] = 18; // top left;
            //indices[67] = 19; // top right;
            //indices[68] = 23; // bottom right;
            //// Bottom-Front Triangle 2 (bottom portion) /|
            //indices[69] = 19; // top left;
            //indices[70] = 21; // top right;
            //indices[71] = 23; // bottom right;  


            //// Bottom-Back Triangle 1 (top portion) |/
            //indices[72] = 23; // top left;
            //indices[73] = 21; // top right;
            //indices[74] = 29; // bottom right;
            //// Bottom-Back Triangle 2 (bottom portion) /|
            //indices[75] = 21; // top left;
            //indices[76] = 26; // top right;
            //indices[77] = 29; // bottom right;  

            //// Back Triangle 1 (top portion) |/
            //indices[78] = 25; // top left;
            //indices[79] = 27; // top right;
            //indices[80] = 26; // bottom right;  

            //// Back Triangle 2 (bottom portion) /|
            //indices[81] = 27; // top left;
            //indices[82] = 29; // top right;
            //indices[83] = 26; // bottom right;  

            //// Top Triangle 1 (top portion) |/
            //indices[84] = 30; // top left;
            //indices[85] = 31; // top right;
            //indices[86] = 25; // bottom right;  

            //// Top Triangle 2 (bottom portion) /|
            //indices[87] = 31; // top left;
            //indices[88] = 27; // top right;
            //indices[89] = 25; // bottom right;

            //// Backwing-Right Triangle 1 (top portion) |/
            //indices[90] = 32; // top left;
            //indices[91] = 33; // top right;
            //indices[92] = 34; // bottom right;  

            //// Backwing-Right Triangle 2 (bottom portion) /|
            //indices[93] = 33; // top left;
            //indices[94] = 35; // top right;
            //indices[95] = 34; // bottom right;

            //// Backwing-Left Triangle 1 (top portion) |/
            //indices[96] = 33; // top left;
            //indices[97] = 32; // top right;
            //indices[98] = 35; // bottom right;  

            //// Backwing-LEft Triangle 2 (bottom portion) /|
            //indices[99] = 32; // top left;
            //indices[100] = 34; // top right;
            //indices[101] = 35; // bottom right;
            #endregion
        }

    }
}