using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public class RotateTransformation : TransformationBase
    {
        public Vector3 rotation;
        public override Vector3 Apply(Vector3 point) 
        {            
            float radX = rotation.x * Mathf.Deg2Rad;
            float radY = rotation.y * Mathf.Deg2Rad;
            float radZ = rotation.z * Mathf.Deg2Rad;
            float sinX = Mathf.Sin(radX);
            float cosX = Mathf.Cos(radX);
            float sinY = Mathf.Sin(radY);
            float cosY = Mathf.Cos(radY);            
            float sinZ = Mathf.Sin(radZ);
            float cosZ = Mathf.Cos(radZ);

            Vector3 XAxis = new Vector3(
                cosY * cosZ,
                cosX * sinZ + sinX * sinY * cosZ,
                sinX * sinZ - cosX * sinY * cosZ
            );

            Vector3 YAxis = new Vector3(
                -cosY * sinZ,
                cosX * cosZ - sinX * sinY * sinZ,
                sinX * cosZ + cosY * sinY * sinZ
            );

            Vector3 ZAxis = new Vector3(
                sinY,
                -sinX * cosY,
                cosX * cosY
            );

            Vector3 rotatePoint = 
               point.x * XAxis +
               point.y * YAxis +
               point.z * ZAxis;

            return rotatePoint;
        }
    }
}
