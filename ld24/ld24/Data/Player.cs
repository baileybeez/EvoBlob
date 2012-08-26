﻿using System;
using Microsoft.Xna.Framework;

namespace ld24.Data
{
   class Player
   {
      public const int BOUNDS_W = 32;
      public const int BOUNDS_H = 32;

      public const int MAX_WALK_SPEED = 3;
      public const int SCROLL_FRAMES = 16;

      private Rectangle _bounds;
      private bool _scroll = false;
      private bool _moved = false;
      private bool _left = true;
      private bool _falling = true;

      public Player()
      {
         _bounds = new Rectangle(0, 0, BOUNDS_W, BOUNDS_H);
      }

      public Vector2 GetPos()
      {
         return new Vector2(_bounds.X, _bounds.Y);
      }

      public Rectangle GetBounds()
      {
         return _bounds;
      }

      public bool Falling { get { return _falling; } }
      public bool Moved { get { return _moved; } }
      public bool MovedLeft { get { return _left; } }
      public bool Scroll { get { return _scroll; } }

      public void SetPosition(Vector2 pos)
      {
         _bounds.X = (int)pos.X;
         _bounds.Y = (int)pos.Y;
      }

      public void SetFalling(bool b)
      {
         _falling = b;
      }

      public Point GetTilePos()
      {
         Point pos = new Point();
         pos.X = (int)(_bounds.X / Game1.TILE_SIZE);
         pos.Y = (int)(_bounds.Y / Game1.TILE_SIZE);

         return pos;
      }

      public void ApplyMovementVector(Vector2 move)
      {
         _scroll = false;
         _moved = false;
         if (move.X == 0 && move.Y == 0)
            return;

         int x = (int)(move.X * MAX_WALK_SPEED);
         int y = (int)(move.Y * MAX_WALK_SPEED);

         _bounds.Offset(x, y);
         _moved = true;
         _scroll = move.X != 0;
         _left = (move.X < 0);
      }
   }
}