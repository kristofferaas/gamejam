using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSpawner : MonoBehaviour {

    float spawnTimer = 0.0f;
    public ObjectPooling cloudPool;
    public ObjectPooling planePool;
    public ObjectPooling sattelitePool;

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

            float positionY = gameObject.transform.position.y + randomY + rb.velocity.y;
            float positionX = gameObject.transform.position.x + rb.velocity.x;

            if (positionY < 3f)
            {
                positionY = 3f;
            }

            GameObject spawn;

            if (height < 100 && rb.velocity.x > 10)
            {
                if (roll > 20)
                {
                    spawn = cloudPool.GetPooledObject();
                    spawn.transform.position = new Vector3(positionX, positionY, 50);
                    spawn.SetActive(true);
                }
            } else if (height < 300 && rb.velocity.magnitude > 20)
            {
                if (roll > 95)
                {
                    spawn = planePool.GetPooledObject();
                    spawn.transform.position = new Vector3(positionX, positionY, 50);
                    spawn.SetActive(true);
                }
            } else if (rb.velocity.magnitude > 20)
            {
                if (roll > 95)
                {
                    spawn = sattelitePool.GetPooledObject();
                    spawn.transform.position = new Vector3(positionX, positionY, 50);
                    spawn.SetActive(true);
                }
            }
            

            spawnTimer = 0.0f;
        }
        spawnTimer += Time.deltaTime;
    }
}
