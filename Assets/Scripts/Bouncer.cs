using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    public float AlternateAmount = 1.0f;
    public GameObject Indicator;

    private RectTransform _rectTransform;
    private Vector2 _anchor;
    
    // Use this for initialization
    void Start()
    {

        _rectTransform = Indicator.GetComponent<RectTransform>();

        _anchor = _rectTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        var sin = Mathf.Sin(Time.time * AlternateAmount) * 128.0f;
        
        _rectTransform.position = new Vector2( _anchor.x + sin, _anchor.y );

        if (Input.GetButtonDown("Submit"))
        {
            print( Mathf.Clamp( Mathf.Abs(sin), 0f, 100f ) );
        }

    }

}
