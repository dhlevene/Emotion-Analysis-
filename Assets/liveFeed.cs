using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveFeed : MonoBehaviour {

	// Use this for initialization
	void Start () {

        WebCamTexture webcam = new WebCamTexture("Integrated Webcam");
        GetComponent<UnityEngine.UI.RawImage>().texture = webcam;
        webcam.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
