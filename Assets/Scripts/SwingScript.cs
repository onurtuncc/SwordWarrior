using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    public GameObject ropeBottom;
    Rigidbody rb;
    bool active = false;
    void Start()
    {
        rb = ropeBottom.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal")*10;
        //float v = Input.GetAxis("Vertical")*10;

        //rb.AddForce(transform.forward * v, ForceMode.Acceleration);
        rb.AddForce(transform.right * h, ForceMode.Acceleration);
    }
}
