using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Start()
    {
        if (Physics.Raycast(transform.position, transform.up))
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
