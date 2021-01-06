﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public string nextLevel;
    public float speed, jumpForce, checkRadius;
    private float moveInput;
    private bool isGrounded, facingRight = true, movement;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Animator animator;

    public Text deadValue;
    public Text deadValueAll;

    public GameObject activeRestartUI, player;

    private Rigidbody2D rb;

    private void Start()
    {
        deadValue.text = PlayerPrefs.GetInt("deadVal").ToString();
        deadValueAll.text = PlayerPrefs.GetInt("deadValAll").ToString();
        movement = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movement)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
                Flip();
        }
        
    }

    private void Update()
    {
        if (movement)
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded == true)
            {
                SoundManager.PlaySound("Jump");
                rb.velocity = Vector2.up * jumpForce;
            }
                
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            activeRestartUI.SetActive(true);

            int d = PlayerPrefs.GetInt("deadVal");
            d++;
            PlayerPrefs.SetInt("deadVal", d);
            deadValue.text = PlayerPrefs.GetInt("deadVal").ToString();

            int dAll = PlayerPrefs.GetInt("deadValAll");
            dAll++;
            PlayerPrefs.SetInt("deadValAll", dAll);
            deadValueAll.text = PlayerPrefs.GetInt("deadValAll").ToString();


            Destroy(player);
            SoundManager.PlaySound("Dead");
        }

        if (collision.CompareTag("fruit"))
            FruitFollow.trig = true;

        if (collision.CompareTag("tp"))
        {
            movement = false;
            Debug.Log(LevelTimer.time);
            LevelLoader.nextLevel = true;
        }
            


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform")){
            this.transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            this.transform.parent = null;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}