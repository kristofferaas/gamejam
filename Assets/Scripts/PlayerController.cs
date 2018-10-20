using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] private float thrust;
    bool hasLaunched = false;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {  
        if (Input.GetAxis("Jump") == 1)
        {
            rb2d.AddForce(Vector2.up*thrust*0.75f, ForceMode2D.Impulse);
            rb2d.AddForce(Vector2.right*thrust, ForceMode2D.Impulse);
            hasLaunched = true;
        }
        
    }

}