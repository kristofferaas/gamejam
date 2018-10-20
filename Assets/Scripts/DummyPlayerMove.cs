using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(3000, 3000));
	}
}
