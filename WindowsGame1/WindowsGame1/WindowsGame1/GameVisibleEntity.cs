using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
   public abstract class GameVisibleEntity: GameEntity
    {
       protected AbstractModel _model;
       protected Vector3 _position;

       public Vector3 Position
       {
           get { return _position; }
           set { _position = value; }
       }
       public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
       {
           _model.Draw(gameTime, graphicsDevice);
       }
    }
}
