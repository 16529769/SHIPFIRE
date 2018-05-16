using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHIPFIRE
{
    public class Bullet : BaseSprite
    {
        public Bullet(Ship ship, Texture2D newTexture, float newSpeed)
        {
            minSpeed = 0;
            maxSpeed = 20;

            position = ship.Position;
            rotation = ship.Rotation;

            texture = newTexture;
            Speed = ship.Speed + newSpeed;
        }

        public void Update()
        {
            position += velocity;
            rectangle = new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            velocity.X = (float)Math.Cos(Rotation) * Speed;
            velocity.Y = (float)Math.Sin(Rotation) * Speed;
        }
    }
}
