﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG_Game
{
    class Player
    {
        private Vector2 position = new Vector2(100, 100);
        private int health = 3;
        private int speed = 200;
        private Dir direction = Dir.Down;
        private bool isMooving = false;
        
        public AnimatedSprite anim;
        public AnimatedSprite[] animations = new AnimatedSprite[4];

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public void setX (float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }

        public void Update(GameTime gt)
        {
            KeyboardState ks = Keyboard.GetState();
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            
            
            anim = animations[(int)direction];

            if (isMooving)
                anim.Update(gt);
            else
                anim.setFrame(1); 
            
            isMooving = false;

            if (ks.IsKeyDown(Keys.Right) | ks.IsKeyDown(Keys.D))
            {
                direction = Dir.Right;
                isMooving = true;
            }
            if (ks.IsKeyDown(Keys.Left) | ks.IsKeyDown(Keys.A))
            {
                direction = Dir.Left;
                isMooving = true;
            }
            if (ks.IsKeyDown(Keys.Up) | ks.IsKeyDown(Keys.W))
            {
                direction = Dir.Up;
                isMooving = true;
            }
            if (ks.IsKeyDown(Keys.Down) | ks.IsKeyDown(Keys.S))
            {
                direction = Dir.Down;
                isMooving = true;
            }

            if (isMooving)
            {
                switch (direction)
                {
                    case Dir.Right:
                        position.X += speed * dt;
                        break;
                    case Dir.Left:
                        position.X -= speed * dt;
                        break;
                    case Dir.Up:
                        position.Y -= speed * dt;
                        break;
                    case Dir.Down:
                        position.Y += speed * dt;
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
