using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHIPFIRE
{

    public class BaseSprite
    {
        protected Texture2D texture = null;
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 origin = Vector2.Zero;
        protected float rotation;
        protected float scale = 1;

        protected Rectangle rectangle = Rectangle.Empty;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(rectangle.X - (rectangle.Width / 2), rectangle.Y - (rectangle.Height / 2), rectangle.Width, rectangle.Height);
            }
            set
            {
                rectangle = value;
            }
        }

        protected float minSpeed, maxSpeed;
        protected float speed = 0;
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = MathHelper.Clamp(value, minSpeed, maxSpeed);
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        
        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
