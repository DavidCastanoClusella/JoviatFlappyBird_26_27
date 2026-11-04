using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float force = 10.0f;
    private Rigidbody2D r;

    public float tiltSmoithness = 5f;
    public float maxUpAngle = 35f;
    public float maxDownAngle = -90f;
    
    
    
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

        applyRotation();
    }

    void applyRotation()
    {
        if (r == null)
        {
            return;
        }

        float targetAngle = 0f;

        if (r.linearVelocity.y > 0)
        {
            targetAngle = maxUpAngle;
        }
        else
        {
            targetAngle = Mathf.Lerp(0f, maxDownAngle, -r.linearVelocity.y / 10);
        }
        
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSmoithness * Time.deltaTime);
    }
    
}
