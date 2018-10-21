using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.tag.Equals("PickUp"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(-other.gameObject.GetComponent<Collidable>().damage, 0.0f);
            other.gameObject.SetActive(false);
        }
    }
}
