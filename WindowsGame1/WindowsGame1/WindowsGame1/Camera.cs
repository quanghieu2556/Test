using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Camera: GameInvisibleEntity
    {
        Vector3 _camPos;

        public Vector3 CamPos
        {
            get { return _camPos; }
            set { _camPos = value; }
        }
        Vector3 _camTarget;
        Vector3 _upVector;
        float _zNear;
        float _zFar;
        float _ViewAngle;
        float _aspectRatio;
        Matrix _World;       
        Matrix _View;
        Matrix _projection;
        public Matrix View
{
  get { return _View; }
}
        public Matrix World
        {
            get { return _World; }

        }
        public Matrix Projection
{
  get { return _projection; }  
}
        public Matrix WVPMatrix
        {
            get {
                return _World*_View*_projection;
            }
        }
        public Matrix InvWVPMatrix
        {
            get {
                return Matrix.Invert(WVPMatrix);
            }
        }
        public Camera(Vector3 pos, Vector3 target, Vector3 upVector, float viewAngle, float aspecRatio, float zNear, float zFar) 
        {
            _camPos = pos;
            _camTarget = target;
            _upVector = upVector;
            _ViewAngle = viewAngle;
            _aspectRatio = aspecRatio;
            _zNear = zNear;
            _zFar = zFar;

            _World = Matrix.Identity;
            _View = Matrix.CreateLookAt(_camPos, _camTarget, _upVector);
            _projection = Matrix.CreatePerspectiveFieldOfView(_ViewAngle, _aspectRatio, _zNear, _zFar);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _View = _View + Matrix.CreateTranslation(_camPos);
        }

        public Vector3 Position { get; set; }
    }
}
