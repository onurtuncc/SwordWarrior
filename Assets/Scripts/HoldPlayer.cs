using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    public GameObject rope;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==14)
        {
            Debug.Log("Collision");
            //Play swing animation
            collision.gameObject.transform.SetParent(rope.transform);
            rope.GetComponentInParent<SwingScript>().enabled = true;
            rope.GetComponentInParent<MoveRope>().enabled = true;
        }
    }
}
