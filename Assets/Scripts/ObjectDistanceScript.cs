using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceScript : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - player.transform.position.x < - 50)
        {
            gameObject.SetActive(false);
        }
	}
}
