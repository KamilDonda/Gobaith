using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float fallingTime, destroyTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("DropPlatform", fallingTime);
            Destroy(gameObject, destroyTime);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}