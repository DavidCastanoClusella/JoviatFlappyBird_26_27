using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float force = 10.0f;
    private Rigidbody2D r;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
                    
            //Vector2 v = new Vector2(0, 1);
        
            if (r != null)
            {
                r.linearVelocity = new Vector2(0f, force);
            }
                    
        }
    }


    
}
