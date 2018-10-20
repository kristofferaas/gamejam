using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float thrust;
    public float energy = 100;
	public GameObject energyText;
	public GameObject distanceText;
    public Transform startPos;

    public bool hasLaunched = false;
    bool isFinished = false;
    float distance = 0;
	

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
		UpdateEnergyText();
        UpdateDistanceText();
    }

	private void UpdateEnergyText()
    {
        energyText.GetComponent<Text>().text = (int) energy + "ml";
    }

    private void UpdateDistanceText()
    {
        distanceText.GetComponent<Text>().text = (int) distance + "m";
    }

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Energy"))
        {
            energy += 20f;
            UpdateEnergyText();
            c.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(hasLaunched) {
            distance = Vector2.Distance(new Vector2(startPos.position.x, startPos.position.y), new Vector2(transform.position.x, transform.position.y));
            UpdateDistanceText();
        }
    }

	private void Boost()
    {
		energy--;
		rb2d.AddForce(new Vector2(thrust, thrust), ForceMode2D.Impulse);
        UpdateEnergyText();
    }

    private void Launch(float forceForward, float forceUpward)
    {
        hasLaunched = true;
		rb2d.AddForce(new Vector2(forceForward, forceUpward), ForceMode2D.Impulse);
    }

    private void Finished()
    {
        isFinished = true;
		Debug.Log("Finished!");
    }


    private void FixedUpdate()
    {  
        
        /*if (Input.GetAxis("Jump") == 1 && !hasLaunched)
        {
            Launch(15f, 15f);
        }*/

        if (Input.GetAxis("Jump") == 1 && energy > 0 && hasLaunched)
        {
            Boost();
        }  
        
    }

}

/*



 */