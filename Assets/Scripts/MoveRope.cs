using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRope : MonoBehaviour
{
    Rigidbody rb;
    CharacterController cc;
    public Transform cp;
    float speed = 5f;
    Vector3 vc3;
    bool isPlayerOnGround = false;
    void Start()
    {
        vc3= new Vector3(2.5f, 1f, 2.5f);
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cp.position.z > transform.position.z)
        {
            cc.Move(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (!isPlayerOnGround)
            {
                GameObject.Find("Player").transform.localScale = vc3;
                GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
                isPlayerOnGround = true;
            }
        }
        
        
    }
}
