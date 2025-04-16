using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int numX, numY;
    [SerializeField] float size = 0.75f;
    [SerializeField] Vector3 startPos = new Vector3(-2.5f, 2.45f, 0);
    [SerializeField] GameObject prefabNode;

    private GameObject node;
    private void Awake()
    {
        for (int i = 0; i < numX; i++)
        {
            for (int j = 0; j < numY; j++)
            {
                Vector3 posSpawn = startPos + new Vector3(j * size, -i * size, 0);
                node = Instantiate(prefabNode, posSpawn, Quaternion.identity, this.transform);
            }
        }
    }
}
