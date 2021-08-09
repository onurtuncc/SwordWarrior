using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DönenEngel : MonoBehaviour
{
    private float rotateSpeed=1.5f;
   
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0), Space.Self);
    }
}
