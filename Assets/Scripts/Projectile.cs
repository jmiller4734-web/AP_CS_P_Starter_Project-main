using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10; 
    public Transform target; 
    Vector3 target_position;
    float timer;
    float time_between_shots = 1.5f;
    private void Start()
    {
       target_position = target.position;
       timer = time_between_shots;
    }


    private void Update()
    {
        float step = speed * Time.deltaTime; 
       transform.position = Vector3.MoveTowards(transform.position,target_position,step);

       timer -= Time.deltaTime;

       if (timer < 0)
            {
                Destroy(gameObject);
            }
    }
    


}




