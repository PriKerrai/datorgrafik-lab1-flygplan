using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Datorgrafik_FlygplansLab
{
    public abstract class GameObject
    {
        protected GraphicsDevice device;
        private VertexBuffer vertexBuffer { get; set; }

        public Quaternion Rotation;
        public Vector3 Position;
        public float Scale { get; protected set; }
        private Matrix world;

        protected VertexPositionColor[] vertices;
        protected List<GameObject> children = new List<GameObject>();

        public GameObject(GraphicsDevice graphicsDevice, Vector3 position, Quaternion rotation, float scale)
        {
            this.device = graphicsDevice;
            InitializeVertices();
            this.vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), this.vertices.Length, BufferUsage.None);
            this.vertexBuffer.SetData<VertexPositionColor>(this.vertices);

            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;

            this.world = Matrix.Identity * Matrix.CreateScale(scale) * Matrix.CreateFromQuaternion(this.Rotation) * Matrix.CreateTranslation(this.Position);
        }

        protected abstract void InitializeVertices();

        public virtual void Draw(ref BasicEffect effect, ref Matrix parentWorld)
        {
            Matrix newWorld = world * parentWorld;
            effect.World = newWorld;
            effect.CurrentTechnique.Passes[0].Apply();

            device.SetVertexBuffer(vertexBuffer);
            device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, vertices.Length / 3);

            foreach (GameObject child in children)
            {
                child.Draw(ref effect, ref newWorld);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            world = Matrix.Identity * Matrix.CreateScale(Scale) * Matrix.CreateFromQuaternion(Rotation) * Matrix.CreateTranslation(Position);

            foreach (GameObject child in children)
            {
                child.Update(gameTime);
            }
        }

        public void AddChild(GameObject child)
        {
            children.Add(child);
        }

    }
}
