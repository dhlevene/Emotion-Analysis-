using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webcamTexture = new WebCamTexture();

        if (devices.Length > 0)
        {
            Debug.Log("Detected Webcam is: " + devices[0].name);
            webcamTexture.deviceName = devices[0].name;
            webcamTexture.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
