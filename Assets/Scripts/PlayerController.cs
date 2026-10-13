using System;
using TMPro;
using Unity.Mathematics;
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
    bool cooldown = true;
    float cooldowntimer = 1.5f;
    String facing;
    [SerializeField] GameObject player_projectile_prefab;
    [SerializeField] Transform spawnpoint;
     



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

        if (xdirection>0)
        {
            facing = "Right";


        }
            else if (xdirection<0)
             {
            
            facing = "Left";
            }
        if (ydirection>0)
        {
            facing = "Up";
        }
        else if (ydirection<0)
        {
            facing = "Down";
        }
       if (Input.GetKeyDown(KeyCode.Space) &&  cooldown)
        {
            shoot();


        }      


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
               ChangeHealth (1);
            }
            else if (health >= 5)
            {
                print ("You have max health");
            }
        }

        if (other.gameObject.CompareTag("E_Fireball"))
        {
            ChangeHealth (-2);
             
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Spikes"))
        {
            ChangeHealth (-1);
            
             
        }
        
    }

    void ChangeCoins (int Amount)
    {
        Coins = Coins + Amount;
        print ("You have " + Coins + " Coins ");


    }
    void Die (int Amount)
    {
      print ("You Died");  

    }


void ChangeHealth (int Amount)
    {
        health = health + Amount;
    
     if (health <= 0)
            {
                Die (1);
                //print ("You Died");
                health = 5;
                ChangeCoins (- Coins/2);
            }  
            else if (health >= 1)
                {
                    print ("You have " + health + " health remaining");
                }


    }

public void shoot ()
    {
        GameObject player_projectile_copy = Instantiate(player_projectile_prefab, transform.position, quaternion.identity);
        PlayerProjectile projectile_script = player_projectile_copy.GetComponent <PlayerProjectile>();
        projectile_script.SetDirection(facing);


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