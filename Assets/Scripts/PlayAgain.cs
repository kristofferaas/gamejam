using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            TaskOnClick();
            timer = 0.0f;
        }
	}

    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
