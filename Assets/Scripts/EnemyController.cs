using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    float speed = 3;
    bool inRange = false; 
    Vector3 target_position;

    Transform target;


    public void Start()
    {
        
    }

    public void Update()
    {
        if(inRange)
        {
            target_position = target.position;
            float step = speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position,target_position,step);
        }

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