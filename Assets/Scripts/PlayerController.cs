using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float Speed =4;
    float xvector;
    float yvector;
    float xdirection;
    float ydirection;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;
    int Coins;
    int health = 5; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        
       
    }

    private void Update()
    {
       // get input
       xdirection = Input.GetAxisRaw("Horizontal");
       ydirection = Input.GetAxisRaw("Vertical");
       //assign vector
       xvector = xdirection * Speed * Time.deltaTime;
       yvector = ydirection * Speed * Time.deltaTime;
       //Position
       transform.position += new Vector3 (xvector,yvector,0);
        //rb.MovePosition( transform.position + new Vector3(xvector,yvector,0));
       AnimationUpdate();
    }
    void OnTriggerEnter2D (Collider2D other)
    {
       
       
        if(other.gameObject.CompareTag("Coin"))
        {
           // Coins = Coins + 1;
           ChangeCoins (1);
            Destroy (other.gameObject);
            //print ("You have " + Coins + " coins");
        }
        if (other.gameObject.CompareTag("Health Potion"))
        {
            
            if (health <= 4)
            {
                Destroy (other.gameObject);
                health = health + 1;
                print ("You have " + health + " health remaining");
            }
            else if (health >= 5)
            {
                health = health = 5; 
                print ("You have max health");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Spikes"))
        {
            health = health - 1;
            if (health <= 0)
            {
                print ("You Died");
                health = 5;
                Coins = Coins / 2;
                print ("You now have " + Coins + (" coins"));
            }  
            else if (health >= 1)
                {
                    print ("You have " + health + " health remaining");
                }
             
        }
        
    }

    void ChangeCoins (int Amount)
    {
        Coins = Coins + Amount;
        print ("You have " + Coins + " Coins ");


    }



void ChangeHealth (int Amount)
    {
        health = health - 1




    }


    private void AnimationUpdate()    
    {
        bool ismoving = xvector != 0 || yvector != 0;
        animator . SetBool ("IsWalking" , ismoving);

        if (Mathf.Abs(xvector) > Mathf.Abs(yvector))
        {
            animator.SetInteger("WalkDir" , 1);

            if (xvector>0)
            {
                renderer.flipX = true;
            }
            else if (xvector<0)
            {
                renderer.flipX = false;
            }
        }
        else if (yvector > 0)
        {
            animator.SetInteger("WalkDir",0);
        }
        else if (yvector < 0)
        {
            animator.SetInteger("WalkDir",2);
        }
        
    }
    
   
    

   
}