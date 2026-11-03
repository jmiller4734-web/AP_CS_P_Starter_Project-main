using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float speed = 10;
    Vector3 direction;

    Vector3 target_position;
    [SerializeField] GameObject currentEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
     }


public void SetDirection (string facing)
    {
        if(facing == "Right")
        {
            direction = new Vector3(1,0,0);

        }

        if(facing == "Left")
        {
            direction = new Vector3(-1,0,0);

        }
        if(facing == "Up")
        {
            direction = new Vector3(0,1,0);

        }
         if(facing == "Down")
        {
            direction = new Vector3(0,-1,0);

        }
    }   
    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("Enemy"))
        {
          currentEnemy = other.gameObject;
           PlayerHit();
         
        }

    }
    public void PlayerHit()
    {
        currentEnemy.GetComponent<EnemyController>().ChangeHealth(-1);

    }
    


}
