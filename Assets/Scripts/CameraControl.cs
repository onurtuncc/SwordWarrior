using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform trcube;
    float distance;
    Transform tr;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
        tr = GetComponent<Transform>();
        trcube = cube.GetComponent<Transform>();
        distance = trcube.position.z - tr.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        tr.position = new Vector3(0f, 10f, cube.transform.position.z - distance);
    }
}
