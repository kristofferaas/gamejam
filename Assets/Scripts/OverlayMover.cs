using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayMover : MonoBehaviour {

    public GameObject currentOverlay;
    public GameObject nextOverlay;

    float overlayHeightStart = 400;
    float overlayHeightEnd = 1200;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > currentOverlay.transform.position.x - 10)
        {
            SwitchTerrain();
        }

        if (gameObject.transform.position.y > overlayHeightStart && gameObject.transform.position.y < overlayHeightEnd)
        {
            currentOverlay.SetActive(true);
            nextOverlay.SetActive(true);
            float negateAlpha = gameObject.transform.position.y / overlayHeightStart - 1;
            currentOverlay.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, negateAlpha);
            nextOverlay.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, negateAlpha);
        }
        else
        {
            currentOverlay.transform.position = gameObject.transform.position;
            nextOverlay.transform.position = gameObject.transform.position;
            currentOverlay.SetActive(false);
            nextOverlay.SetActive(false);
        }
        currentOverlay.transform.position = new Vector3(currentOverlay.transform.position.x, gameObject.transform.position.y, currentOverlay.transform.position.z);
        nextOverlay.transform.position = new Vector3(nextOverlay.transform.position.x, gameObject.transform.position.y, nextOverlay.transform.position.z);
    }

    private void SwitchTerrain()
    {
        GameObject save = currentOverlay;
        currentOverlay = nextOverlay;
        currentOverlay.transform.position = nextOverlay.transform.position + new Vector3(75, 0, 0);
        nextOverlay = save;
    }
}
