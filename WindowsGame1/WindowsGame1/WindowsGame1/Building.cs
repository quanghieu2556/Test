using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Building: GameVisibleEntity
    {
        Model3D _model;
          public Building(string assetName, Vector3 position, float xScale, float yScale, float zScale, float xRot, float yRot, float zRot)
          {
              _model = new Model3D(assetName,position,xScale,yScale,zScale,xRot,yRot,zRot);     
          }
    }
}
