using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.name.Equals("player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(-1.0f, 0.0f);
        }
    }
}
