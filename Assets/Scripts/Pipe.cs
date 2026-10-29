using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    
    private GameObject gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 pos = GetComponent<Transform>().position;

        pos.x -= speed;

        GetComponent<Transform>().position = pos;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gm.GetComponent<GameManager>().addScore();
        }
    }
    
    
}

