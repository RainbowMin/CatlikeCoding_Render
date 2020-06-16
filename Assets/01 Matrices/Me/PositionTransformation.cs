using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public class PositionTransformation : TransformationBase
    {
        public Vector3 position;
        public override Vector3 Apply(Vector3 point)
        {
            return position + point;
        }        
    }

}
