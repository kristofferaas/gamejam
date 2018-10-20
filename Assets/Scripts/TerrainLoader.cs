using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
	public GameObject currentTerrain;
	public GameObject nextTerrain;

    float blueCounter = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Debug.Log(currentTerrain.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > currentTerrain.transform.position.x)
		{
			SwitchTerrainX();
		}
		if (gameObject.transform.position.y > currentTerrain.transform.position.y)
		{
			SwitchTerrainY();
		}
        float negate = 1 - gameObject.transform.position.y / 200;
        currentTerrain.GetComponent<SpriteRenderer>().color = new Color(negate, negate, negate);
    }

	private void SwitchTerrainX()
	{
		GameObject save = currentTerrain;
		currentTerrain = nextTerrain;
		currentTerrain.transform.position = nextTerrain.transform.position + new Vector3(10.0f, 0.0f, 0.0f);
		nextTerrain = save;
	}
	
	private void SwitchTerrainY()
	{
		GameObject save = currentTerrain;
		currentTerrain = nextTerrain;
		currentTerrain.transform.position = nextTerrain.transform.position + new Vector3(0.0f, 3.0f, 0.0f);
		nextTerrain = save;
	}
}
