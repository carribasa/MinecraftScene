using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject cube;
    public int width, large, height;
    public int seed;
    public float detail;

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < large; z++)
            {
                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);
                for (int y = 0; y < height; y++)
                {
                    Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }
}
