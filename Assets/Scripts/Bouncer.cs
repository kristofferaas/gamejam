using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    public GameObject throwPrefab;
    
    public float alternateAmount = 1.0f;
    public GameObject indicator;

    public float force = 100;

    private RectTransform _rectTransform;
    private Vector2 _anchor;

    private bool thrown;

    private Vector2 _throwVelocity;

    private float indicatorWidth;

    private float _maxForce = 128.0f;
    
    // Use this for initialization
    void Start()
    {

        _rectTransform = indicator.GetComponent<RectTransform>();

        thrown = false;

        indicatorWidth = _rectTransform.rect.width;
        _anchor = _rectTransform.position;

        indicator.transform.parent.gameObject.SetActive( true );
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {
            
            var posX = Mathf.Sin(Time.time * alternateAmount) * _maxForce;
            
            _rectTransform.position = new Vector2( _anchor.x + posX, _anchor.y );

            if (Input.GetButtonDown("Jump"))
            {

                thrown = true;
                StartCoroutine( ThrowGameObject( _maxForce - Mathf.Abs( posX )) );


            }
            
        }
    }

    IEnumerator ThrowGameObject( float multiplier )
    {
        
        var vel = new Vector2( force, force );
        
        throwPrefab.GetComponent<Rigidbody2D>().AddForce( vel * multiplier );

        throwPrefab.GetComponent<PlayerController>().Launch();

        yield return new WaitForSecondsRealtime(1);
        
        indicator.transform.parent.gameObject.SetActive( false );

    }

}
