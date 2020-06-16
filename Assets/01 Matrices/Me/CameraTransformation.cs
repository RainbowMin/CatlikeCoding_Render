using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public class CameraTransformation : TransformationBase
    {
        public enum CameraType
        {           
            None,

            [Header("正交投影")]
            Orthographic,

            [Header("透视投影")]
            perspective,
        }

        public CameraType m_CameraType;

        [Range(0,10)]
        public float _焦距;

        public override Matrix4x4 Matrix
        {
            get
            {
                Matrix4x4 matrix = new Matrix4x4();

                if(m_CameraType == CameraType.Orthographic)
                {
                    matrix.SetRow(0, new Vector4(1f,0f,0f,0));
                    matrix.SetRow(1, new Vector4(0f,1f,0f,0));
                    matrix.SetRow(2, new Vector4(0f,0f,0f,0));
                    matrix.SetRow(3, new Vector4(0f,0f,0f,1f));
                }
                else if(m_CameraType == CameraType.perspective)
                {
                    matrix.SetRow(0, new Vector4(_焦距,0f,0f,0));
                    matrix.SetRow(1, new Vector4(0f,_焦距,0f,0));   
                    matrix.SetRow(2, new Vector4(0f,0f,0f,0));
                    matrix.SetRow(3, new Vector4(0f,0f,1f,0));
                }
                else 
                {
                    matrix = Matrix4x4.identity;
                }


                return matrix;
            }
        }
    }

}
