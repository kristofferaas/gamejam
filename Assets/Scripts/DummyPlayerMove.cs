using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.position = gameObject.transform.position + new Vector3(3.0f, 0.0f, 0.0f);
	}
}
