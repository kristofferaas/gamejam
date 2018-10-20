using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSpawner : MonoBehaviour {

    float spawnTimer = 0.0f;
    public ObjectPooling cloudPool;
    public GameObject sattelite;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnTimer > 0.3f) { 
            float roll = Random.Range(0, 100);
            float height = gameObject.transform.position.y;

            float randomY = Random.Range(-15, 15);

            if (height < 100 && rb.velocity.magnitude > 20)
            {
                if (roll > 20)
                {
                    GameObject spawn = cloudPool.GetPooledObject();
                    spawn.transform.position = new Vector3(gameObject.transform.position.x + rb.velocity.x, gameObject.transform.position.y + randomY + rb.velocity.y, 50);
                    spawn.SetActive(true);
                }
            } else if (height < 300)
            {
                if (roll > 95)
                {
                    GameObject spawn = Instantiate(sattelite);
                    spawn.transform.position = new Vector3(gameObject.transform.position.x + 50, gameObject.transform.position.y + randomY, 50);
                }
            }
            spawnTimer = 0.0f;
        }
        spawnTimer += Time.deltaTime;
    }
}
