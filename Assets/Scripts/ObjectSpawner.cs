using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public ObjectPooling pool;
    public float spawnChance = 0.0f;
    float spawnTimer = 0.0f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0.2f && rb.velocity.magnitude > 10)
        {
            float roll = Random.Range(0, 100);
            float height = gameObject.transform.position.y;

            float randomY = Random.Range(-40, 40);
            float randomX = Random.Range(-10, 50);

            float positionY = gameObject.transform.position.y + randomY + (rb.velocity.y * 2);
            float positionX = gameObject.transform.position.x + randomX + (rb.velocity.x * 2);

            if (positionY < 1)
            {
                positionY = 0.5f;
            }

            if (roll > 100 - spawnChance)
            {
                GameObject spawn = pool.GetPooledObject();
                spawn.transform.position = new Vector3(positionX, positionY, 50);
                spawn.SetActive(true);
            }
            spawnTimer = 0.0f;
        }
        spawnTimer += Time.deltaTime;
    }
}
