using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SHIPFIRE
{
    public class Ship : BaseSprite
    {
        private Keys left, right, up, shoot;
        private Texture2D bulletTexture;

        private List<Bullet> bullets = new List<Bullet>();

        private KeyboardState presentKey, pastKey;
        public Ship(ContentManager Content, Vector2 newPosition)
        {

            texture = Content.Load<Texture2D>("SS2");

            position = newPosition;

            minSpeed = 0;
            maxSpeed = 7.5f;

            bulletTexture = Content.Load<Texture2D>("bullet3");

        }

        public void SetControls(Keys newLeft, Keys newRight, Keys newUp, Keys newShoot)
        {
            left = newLeft;
            right = newRight;
            up = newUp;
            shoot = newShoot;
        }

        public void Update(List<Ship> ships)
        {
            presentKey = Keyboard.GetState();

            position += velocity;

            rectangle = new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            
            if (presentKey.IsKeyDown(left))
            {
                rotation -= 0.075f;
            }

            if (presentKey.IsKeyDown(right))
            {
                rotation += 0.075f;
            }
           
            if (presentKey.IsKeyDown(up))
            {
                Speed += 0.5f;
            }
            else Speed -= 0.25f;

            if (presentKey.IsKeyDown(shoot) && pastKey.IsKeyUp(shoot) && bullets.Count < 30)
            {
                bullets.Add(new Bullet(this, bulletTexture, 5));
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (Vector2.Distance(bullets[i].Position, Position) > 1290)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }

            velocity.X = (float)Math.Cos(Rotation) * Speed;
            velocity.Y = (float)Math.Sin(Rotation) * Speed;

            bullets.ForEach(b => b.Update());

            foreach (Ship ship in ships)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].Rectangle.Intersects(ship.Rectangle))
                    {
                        bullets.RemoveAt(i);
                        i--;
                    }
                }
            }

            pastKey = presentKey;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bullets.ForEach(b => b.Draw(spriteBatch));

            base.Draw(spriteBatch);
        }
    }
}