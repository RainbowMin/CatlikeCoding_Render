using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Me
{
    public class TransformationGrid : MonoBehaviour
    {
        public Transform prefab;
        public int m_GridResolution = 10;

        //[serialized]
        public Transform[] gird;

        void Awake()
        {
            gird = new Transform[m_GridResolution * m_GridResolution * m_GridResolution];
            for (int i = 0, z = 0; z < m_GridResolution; z++)
            {
                for (int y = 0; y < m_GridResolution; y++)
                {
                    for (int x = 0; x < m_GridResolution; x++, i++)
                    {
                        gird[i] = CreateGridPoint(x,y,z);
                    }
                }
            }
        }
        
        Transform CreateGridPoint(int x, int y, int z)
        {
            Transform point = Instantiate<Transform>(prefab);
            point.localPosition = GetCoordinates(x,y,z);
            MeshRenderer r = point.gameObject.GetComponent<MeshRenderer>();
            r.material.color = new Color((float)x/m_GridResolution, (float)y / m_GridResolution, (float)z / m_GridResolution);
            return point;
        }

        Vector3 GetCoordinates(int x, int y, int z)
        {
            //return new Vector3(x,y,z);

            return new Vector3(
                x - (m_GridResolution - 1) * 0.5f,
                y - (m_GridResolution - 1) * 0.5f,
                z - (m_GridResolution - 1) * 0.5f
            );

            
        }

        void Update()
        {
            
        }
    }
}


