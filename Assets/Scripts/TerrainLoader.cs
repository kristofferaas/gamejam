using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
	public GameObject currentTerrain;
	public GameObject nextTerrain;

    public GameObject sky;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > currentTerrain.transform.position.x + 50)
		{
			SwitchTerrain();
		}
        float negate = 1 - gameObject.transform.position.y / 200;
        float negateAlpha = 1 - gameObject.transform.position.y / 500;
        sky.GetComponent<SpriteRenderer>().color = new Color(0, negate - 0.1f, negate, 1 - negateAlpha);
        sky.transform.position = gameObject.transform.position + new Vector3(0, 0, 100);
    }

	private void SwitchTerrain()
	{
		GameObject save = currentTerrain;
		currentTerrain = nextTerrain;
		currentTerrain.transform.position = nextTerrain.transform.position + new Vector3(200.0f, 0.0f, 0.0f);
		nextTerrain = save;
	}
}
