using System;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.GetComponent<GameManager>().StopGame();
        }
    }
}
