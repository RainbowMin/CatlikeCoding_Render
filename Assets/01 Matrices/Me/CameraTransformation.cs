using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public class CameraTransformation : TransformationBase
    {
        public override Matrix4x4 Matrix
        {
            get
            {
                Matrix4x4 matrix = new Matrix4x4();
                matrix.SetRow(0, new Vector4(1f,0f,0f,0));
                matrix.SetRow(1, new Vector4(0f,1f,0f,0));
                matrix.SetRow(2, new Vector4(0f,0f,0f,0));
                matrix.SetRow(3, new Vector4(0f,0f,0f,1f));
                return matrix;
            }
        }
    }

}
