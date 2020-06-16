using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me
{
    public abstract class TransformationBase : MonoBehaviour
    {
        public abstract Matrix4x4 Matrix { get; }
    }
}

