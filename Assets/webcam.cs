using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
    public RawImage rawimage;
    public WebCamTexture webcamTexture;
    void Start()
    {
        webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.requestedHeight = 1080 ;
        webcamTexture.requestedWidth = 1920;
        webcamTexture.Play();
    }
}