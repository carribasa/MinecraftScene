using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject cube;

    void Start()
    {
        if (Physics.Raycast(transform.position, transform.up))
        {
            gameObject.SetActive(false);
        }
    }
}
