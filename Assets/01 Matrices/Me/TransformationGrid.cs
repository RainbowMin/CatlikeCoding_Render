using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Me
{
    public class TransformationGrid : MonoBehaviour
    {
        public Transform prefab;
        public int m_GridResolution = 10;
        public Transform[] m_Grid;

        List<TransformationBase> m_Transformations;

        void Awake()
        {
            m_Grid = new Transform[m_GridResolution * m_GridResolution * m_GridResolution];
            for (int i = 0, z = 0; z < m_GridResolution; z++)
            {
                for (int y = 0; y < m_GridResolution; y++)
                {
                    for (int x = 0; x < m_GridResolution; x++, i++)
                    {
                        m_Grid[i] = CreateGridPoint(x,y,z);
                    }
                }
            }

            m_Transformations = new List<TransformationBase>();
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
            return new Vector3(
                x - (m_GridResolution - 1) * 0.5f,
                y - (m_GridResolution - 1) * 0.5f,
                z - (m_GridResolution - 1) * 0.5f
            );
        }

        Vector3 TransformPoint(int x, int y, int z)
        {
            Vector3 coordinate = GetCoordinates(x,y,z);
            Matrix4x4 matrix = Matrix4x4.identity;
            foreach(TransformationBase t in m_Transformations)
            {
                //coordinate = t.Apply(coordinate);
                matrix *= t.Matrix;
            }
            return matrix.MultiplyPoint(coordinate);
        }

        void Update()
        {
            GetComponents<TransformationBase>(m_Transformations);

            for (int i = 0, z = 0; z < m_GridResolution; z++)
            {
                for (int y = 0; y < m_GridResolution; y++)
                {
                    for (int x = 0; x < m_GridResolution; x++, i++)
                    {
                        m_Grid[i].localPosition = TransformPoint(x,y,z);
                    }
                }
            }
        }
    }
}


