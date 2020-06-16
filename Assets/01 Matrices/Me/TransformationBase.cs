using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public abstract class TransformationBase : MonoBehaviour
    {
        public abstract Vector3 Apply(Vector3 point);
    }
}

