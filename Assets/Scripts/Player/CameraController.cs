using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform refPly;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, refPly.transform.position.y + 4, transform.position.z);
    }
}
