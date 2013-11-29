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
        int[] houseHeights = new int[numberOfHouseHeights] { 2, 4, 76 };
        int[,] housePositions;
        List<VertexPositionColor> housesVertices = new List<VertexPositionColor>();
        private const int numberOfHouseColors = 3;
        Color[] houseColors = new Color[numberOfHouseColors] { Color.Goldenrod, Color.Gainsboro, Color.Firebrick };
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
                    foreach (VertexPositionColor vertex in HouseVertices(x, z, houseColors[random.Next(0, numberOfHouseColors)]))
                    {
                        housesVertices.Add(vertex);
                    }
                }
            }

                houseBuffer = new VertexBuffer(device, typeof(VertexPositionColor), housesVertices.Count, BufferUsage.WriteOnly);
                houseBuffer.SetData<VertexPositionColor>(housesVertices.ToArray());
        }

        private List<VertexPositionColor> HouseVertices(int xOffset, int zOffset, Color houseColor)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            // roof
            vList.Add(new VertexPositionColor(new Vector3(0 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 0 + zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 0 + zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(0 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 1 + zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 0 + zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(1 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 1 + zOffset), houseColor));
            vList.Add(new VertexPositionColor(new Vector3(0 + xOffset, houseHeights[random.Next(0, numberOfHouseHeights)], 1 + zOffset), houseColor));

            // north wall


            // east wall

            // south wall

            // west wall


            return vList;
        }

        public void Draw(Camera camera, BasicEffect effect)
        {
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(houseBuffer);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, houseBuffer.VertexCount / 3);
            }
        }
    }
}
