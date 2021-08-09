using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    public Animator animator;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.z-player.transform.position.z<=30 )
        {
            rb.AddForce(new Vector3(0, 0, -5));
            
        }
        
    }
    private void OnMouseDown()
    {
        //play getting hit animation and sword swing animation
        animator.SetTrigger("hitEnemyTrigger");
        Destroy(gameObject);
    }
}
