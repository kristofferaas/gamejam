using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float thrust;
    public float energy = 100;
	public GameObject energyText;
	public GameObject distanceText;
    public Transform startPos;

    private Rigidbody2D rb2d;
    private bool _hasLaunched = false;
    private bool _isFinished = false;
    private float _distance = 0;
	

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
        distanceText.GetComponent<Text>().text = (int) _distance + "m";
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
        if (!_hasLaunched || _isFinished) return;
        
        _distance = Vector2.Distance(new Vector2(startPos.position.x, startPos.position.y), new Vector2(transform.position.x, transform.position.y));
        UpdateDistanceText();

        if (rb2d.velocity == Vector2.zero)
        {
            
            print( (int)_distance + "m");
            Finished();
            
        }
        
    }

	private void Boost()
    {
		energy--;
		rb2d.AddForce(new Vector2(thrust, thrust), ForceMode2D.Impulse);
        UpdateEnergyText();
    }

    public void Launch()
    {
        _hasLaunched = true;
    }

    private void Finished()
    {
        _isFinished = true;
		Debug.Log("Finished!");
    }


    private void FixedUpdate()
    {  
        
        if ( _isFinished ) return;
        
        if (Input.GetAxis("Jump") == 1 && energy > 0 && _hasLaunched)
        {
            Boost();
        }  
        
    }

}