using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class Model3D: AbstractModel
    {
        Model _model;

        Vector3 _posistion;
        string _assetName;
        float _xScale;
        float _yScale;
        float _zScale;
        float _xRot;
        float _yRot;
        float _zRot;
        public Model3D(string assetName, Vector3 position)
        {
            _assetName = assetName;
            _posistion = position;
            _xScale = _yScale = _zScale = 1f;
            _xRot = _yRot = _zRot = 0f;
            _model = GLOBAL.Content.Load<Model>(_assetName);
        }
       public Model3D(string assetName, Vector3 position, float xScale, float yScale, float zScale, float xRot, float yRot, float zRot)
        {
            _assetName = assetName;
            _posistion = position;
            _xScale = xScale;
            _yScale = yScale;
            _zScale = zScale;
            _xRot = xRot;
            _yRot = yRot;
            _zScale = zRot;
            _model = GLOBAL.Content.Load<Model>(_assetName);
        }
       public override void Update(GameTime gameTime)
       {
           base.Update(gameTime);
       }
       public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
       {
          

           base.Draw(gameTime, graphicsDevice);
           foreach (ModelMesh m in _model.Meshes)
           {

               foreach (BasicEffect effect in m.Effects)
               {
                   effect.EnableDefaultLighting();
                   effect.World = GLOBAL.CurCam.World * Matrix.CreateTranslation(_posistion);
                   effect.View = GLOBAL.CurCam.View;
                   effect.Projection = GLOBAL.CurCam.Projection;
               }
               m.Draw();
           }
       }
    }
}
