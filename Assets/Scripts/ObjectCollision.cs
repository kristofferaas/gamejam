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

            var currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;     
            
            var modifier = new Vector2(-other.gameObject.GetComponent<Collidable>().damage, 0.0f);

            if ( (currentVelocity + modifier).x <= 0)
            {
               
                other.gameObject.SetActive(false);                   
                return;

            }
              
            gameObject.GetComponent<Rigidbody2D>().velocity += modifier;
            other.gameObject.SetActive(false);    
         
        }
    }
}
