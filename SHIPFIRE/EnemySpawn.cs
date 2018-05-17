using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHIPFIRE
{
   public class EnemySpawn :BaseSprite
    {
        public Texture2D enemy;
        public Vector2 enemyPosition;
        private Vector2 enemyVelocity;

        public bool isvisible = true;

        Random random = new Random();

        int randX, randY;

        public EnemySpawn(Texture2D newEnemy, Vector2 newEnemyPosition)
        {
            enemy = newEnemy;
            enemyPosition = newEnemyPosition;

            randY = random.Next(-4, -4);
            randX = random.Next(-4, -1);

            enemyVelocity = new Vector2(randX, randY);
        }

        public void Update(GraphicsDevice graphics)
        {
            enemyPosition += enemyVelocity;

            if (enemyPosition.Y <= 0 || enemyPosition.Y >= graphics.Viewport.Height - enemy.Height)
                enemyVelocity.Y = -enemyVelocity.Y;

            if (enemyPosition.X < 0 - enemy.Width)
                isvisible = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
            {
            spriteBatch.Draw(enemy, enemyPosition, Color.White);
            }
           
    }
}
