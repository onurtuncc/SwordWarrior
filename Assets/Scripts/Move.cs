using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float checkPoint;
    private Rigidbody boss;
    private CollectSword cs;
    Rigidbody rb;
    float speed = 8f;
    float x = 0f;
    private bool isInBossState = false;
    private bool alreadyHit = false;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cs = GetComponent<CollectSword>();
        boss = GameObject.Find("Boss").GetComponent<Rigidbody>();
        checkPoint = GameObject.Find("BossCheckPoint").transform.position.z;
        PlayerPrefs.SetFloat("Collected", 0);
        rb = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame

    private void Update()
    {
        
        if (transform.position.z >= checkPoint)
        {
            isInBossState = true;

        }
    }
    public void HitBoss(int swordA)
    {
        //Play hit to boss animation
        anim.SetTrigger("hitEnemyTrigger");
        anim.SetTrigger("winTrigger");
        boss.AddForce(0, 1, swordA*40);
        alreadyHit = true;
    }


    void FixedUpdate()
    {
        
        if (!isInBossState)
        {
            x = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector3(x*4, 0, 1) * speed);
        }
        else
        {
            if (!alreadyHit)
            {
                transform.SetPositionAndRotation(new Vector3(0, 0, checkPoint), Quaternion.identity);
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                HitBoss(cs.getSwordAmount());
            }
            
            
        }
        

    }
   
}
