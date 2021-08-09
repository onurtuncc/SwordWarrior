using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSword : MonoBehaviour
{
    Animator anim;
    
    Rigidbody rb;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 increaseVector;
    [SerializeField] private int swordAmount=1;
    Text scoreText;
    bool alive = true;
    
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = swordAmount.ToString();
        increaseVector = new Vector3(0.2f,0.2f,0.2f);
        sword = GameObject.Find("SwordDisplay");
        player = GameObject.Find("PlayerDisplay");
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            anim.SetTrigger("hitObstacleTrigger");
            swordAmount -= 1;
            player.transform.localScale -= increaseVector;
            scoreText.text = swordAmount.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 13)
        {
            Debug.Log("Collision");
            transform.SetParent(collision.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform);
            rb.isKinematic = true;
            anim.SetTrigger("swingTrigger");
        }




    }
    public int getSwordAmount()
    {
        return swordAmount;
    }
   
    private void Update()
    {
        if (swordAmount == 0 && alive)
        {
            Die();
        }
    }
    void Die()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        anim.SetTrigger("deathTrigger");
        alive = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 )
        {
            if(other.gameObject.GetComponent<Renderer>().material.color == sword.GetComponentInChildren<Renderer>().material.color)
            {
                player.transform.localScale += increaseVector;
                swordAmount += 1;
          
            }
            else
            {
                player.transform.localScale -= increaseVector;
                swordAmount -= 1;
             
            }
            
            scoreText.text = swordAmount.ToString();
        }
        if (other.gameObject.layer == 10)
        {
            sword.GetComponentInChildren<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
        }
        if (other.gameObject.layer == 12)
        {
            anim.SetTrigger("getHitTrigger");
            player.transform.localScale -= increaseVector;
            swordAmount -= 1;
        
            scoreText.text = swordAmount.ToString();
            
        }
        Destroy(other.gameObject);
    }
}
