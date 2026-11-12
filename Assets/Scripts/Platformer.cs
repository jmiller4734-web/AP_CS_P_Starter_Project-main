using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float speed = 3;
   public bool isOn;
    Vector3 target_position;

    Transform target;
    int patrolNumber = 0;
    [SerializeField] private List <Transform> patrolpoints = new List<Transform>();

    void Start()
    {
        //target = patrolpoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            
        
        
            target_position = patrolpoints[patrolNumber].position;
            if(Vector3.Distance(transform.position, patrolpoints[patrolNumber].position)<.1)
            {
               patrolNumber +=1;
                if(patrolNumber == patrolpoints.Count)
                {
                    patrolNumber = 0;


                }
                

            }
        
            float step = speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position,target_position,step);
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = true; 

            target = other.transform;
           other.gameObject.transform.SetParent(transform);
        }
      

    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = false; 
            target = null;
            other.gameObject.transform.SetParent(null);
        }
    }





    
}
