using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoPong.Objects
{
    public class GameObject
    {
        public Vector2 Position;
        public Vector2 Size;

        public string textureName;
        public Texture2D texture;

        public GameObject (Rectangle rect)
        {
            Start();

            this.SetFromRect(rect);
        }

        public GameObject (Vector2 _Position, Vector2 _Size)
        {
            Start();

            Position = _Position;
            Size = _Size;
        }

        public void SetFromRect(Rectangle Rect)
        {
            Position = new Vector2(Rect.X, Rect.Y);
            Size = new Vector2(Rect.Width, Rect.Height);
        }

        public virtual void Start()
        {
            //Called on creation
        }

        public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(textureName);
        }

        public virtual void Update(GameTime time)
        {
            //Call in Game.Update()
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            //Call in Game.Draw()
        }

        public Rectangle GetRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
    }
}
