using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    StatManager manager;
    void Start()
    {
        manager = FindAnyObjectByType <StatManager>();
        if (manager.maxJumps > 1)
        {
            Destroy (gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
