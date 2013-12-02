using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Datorgrafik_FlygplansLab.Models
{
    class Houses
    {
        GraphicsDevice device;
        VertexBuffer houseBuffer;

        private const int numberOfHouseHeights = 3;
        int[] houseHeights = new int[numberOfHouseHeights] { 2, 4, 6 };
        int[,] housePositions;
        List<VertexPositionColor> housesVertices = new List<VertexPositionColor>();
        private const int numberOfHouseColors = 3;
        Color[] houseColors = new Color[numberOfHouseColors] { Color.LightGray, Color.LemonChiffon, Color.MediumAquamarine };
        Random random = new Random();

        public Houses(GraphicsDevice device)
        {
            this.device = device;
            BuildHouseBuffer();
        }

        private void BuildHouseBuffer()
        {
            housePositions = new int[Ground.groundWidth, Ground.groundHeight];

            for (int x = 0; x < Ground.groundWidth; x++)
            {
                for (int z = 0; z < Ground.groundHeight; z++)
                {
                    if (random.Next(0,5) == 0)
                    {
                        foreach (VertexPositionColor vertex in HouseVertices(x, z, houseColors[random.Next(0, numberOfHouseColors)]))
                        {
                            housesVertices.Add(vertex);
                        }
                    }
                    
                }
            }

            houseBuffer = new VertexBuffer(device, typeof(VertexPositionColor), housesVertices.Count, BufferUsage.WriteOnly);
            houseBuffer.SetData<VertexPositionColor>(housesVertices.ToArray());
        }

        private List<VertexPositionColor> HouseVertices(int xOffset, int zOffset, Color houseColor)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            int houseHeight = houseHeights[random.Next(0, numberOfHouseHeights)];

            // roof
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    1 + zOffset),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    1 + zOffset),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    1 + zOffset),   houseColor));


            // front wall
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset + 1),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset + 1),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      0,              zOffset + 1),   houseColor));

            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset + 1),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset + 1),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    zOffset + 1),   houseColor));

            // back wall
            vList.Add(new VertexPositionColor(new Vector3(xOffset, 0, zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset),       houseColor));

            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, houseHeight, zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset),       houseColor));

            // left wall
            vList.Add(new VertexPositionColor(new Vector3(xOffset, 0, zOffset + 1), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      0,              zOffset),       houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset + 1),   houseColor));

            vList.Add(new VertexPositionColor(new Vector3(xOffset, houseHeight, zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      houseHeight,    zOffset + 1),   houseColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset,      0,              zOffset),       houseColor));

            // right wall
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, houseHeight, zOffset + 1), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset),      houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  0,              zOffset + 1),  houseColor));

            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, 0, zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    zOffset + 1),  houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset,  houseHeight,    zOffset),      houseColor));

            return vList;
        }

        public void Draw(Camera camera, BasicEffect effect)
        {
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ViewProjectionMatrix;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(houseBuffer);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, houseBuffer.VertexCount / 3);
            }
        }
    }
}
