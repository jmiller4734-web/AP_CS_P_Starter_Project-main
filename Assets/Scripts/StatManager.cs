using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int health = 5;
    
    public int Coins;
    public static StatManager original;



    void Awake()
    {
        if (original != null && original != this)
        {
            Destroy (gameObject);   
            return;

        }

        original = this;
        DontDestroyOnLoad(gameObject);

    }

    //code here
    public void ChangeCoins (int Amount)
    {
        Coins = Coins + Amount;
        print ("You have " + Coins + " Coins ");


    }
    public void Die (int Amount)
    {
        print ("You Died");  
        health = 5;
        ChangeCoins (- Coins/2);
    }

public void ChangeHealth (int Amount)
    {
        health = health + Amount;
    
     if (health <= 0)
            {
                Die (1);
                //print ("You Died");
                
            }  
            else if (health >= 1)
                {
                    print ("You have " + health + " health remaining");
                }


    }




}
