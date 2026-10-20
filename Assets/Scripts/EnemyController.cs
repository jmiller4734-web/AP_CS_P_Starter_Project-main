using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    float speed = 3;
    bool inRange = false; 
    Vector3 target_position;

    Transform target;
    int patrolNumber = 0;
    [SerializeField] private List<Transform> patrolpoints = new List<Transform>();

    public void Start()
    {
        target_position = patrolpoints[0].position; 
    }

    public void Update()
    {
        if(inRange)
        {
            target_position = target.position;
        
        }
        else
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
        }
            float step = speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position,target_position,step);
        

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true; 

            target = other.transform;
        }


    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false; 
            target = null;
        }
    }





}