using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject cubeDirt, cubeGrass, cubeSnow;
    public int width, large, height;
    public int seed;
    public float detail;
    private int maxHeight = 0;

    void Start()
    {
        GeneratePerlingNoise();
        GenerateMap();
    }

    private void GeneratePerlingNoise()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < large; z++)
            {
                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }
        }
        Debug.Log("MAX HEIGHT -> " + maxHeight);
    }

    private void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < large; z++)
            {
                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);
                int heightEdgeDirt = maxHeight / 3;
                int heightEdgeGrass = (maxHeight / 3) * 2;

                for (int y = 0; y < height; y++)
                {
                    if (y <= heightEdgeDirt)
                    {
                        Instantiate(cubeDirt, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else if (y > heightEdgeDirt && y <= heightEdgeGrass)
                    {
                        Instantiate(cubeGrass, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else if (y > heightEdgeGrass)
                    {
                        Instantiate(cubeSnow, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
    }
}
