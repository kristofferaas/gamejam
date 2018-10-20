using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
	public GameObject currentTerrain;
	public GameObject nextTerrain;

	// Use this for initialization
	void Start ()
	{
		Debug.Log(currentTerrain.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > currentTerrain.transform.position.x - 50)
		{
			SwitchTerrain();
		}
	}

	private void SwitchTerrain()
	{
		GameObject save = currentTerrain;
		currentTerrain = nextTerrain;
		currentTerrain.transform.position = nextTerrain.transform.position + new Vector3(200.0f, 0.0f, 0.0f);
		nextTerrain = save;
	}
}
