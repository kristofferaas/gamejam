using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    public GameObject poolParent;
    public GameObject pooledObject;
    public int pooledAmount = 10;
    public bool willGrow = true;

    public List<GameObject> pooledObjects;

    private void Awake()
    {
    }

    // Use this for initialization
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (var i = 0; i < pooledAmount; i++)
        {
            var obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(poolParent.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // if no objects are found, it can expand. But only if willGrow is set to true
        if (!willGrow) return null;
        {
            var obj = (GameObject)Instantiate(pooledObject);
            obj.transform.SetParent(poolParent.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

    }
}