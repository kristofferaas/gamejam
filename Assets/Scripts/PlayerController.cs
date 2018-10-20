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
	[SerializeField] private GameObject energyText;
    bool hasLaunched = false;
	float energy = 100;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
		updateEnergyText();
    }

	private void updateEnergyText()
    {
        energyText.GetComponent<Text>().text = "Energy: " + energy;
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

	private void boost()
    {
		energy--;
		rb2d.AddForce(Vector2.up*thrust*0.35f, ForceMode2D.Impulse);
		rb2d.AddForce(Vector2.right*thrust*0.15f, ForceMode2D.Impulse);
        updateEnergyText();
    }

    private void FixedUpdate()
    {  
        if (Input.GetAxis("Jump") == 1 && energy > 0)
        {
            boost();
            hasLaunched = true;
        }
        
    }

}

/*



 */