using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
    public RawImage rawimage;
    public Affdex.CameraInput webcamSource;
    void Start()
    {
        WebCamTexture feed = webcamSource.cameraTexture;
        if (feed.isPlaying)
        {
            rawimage.texture = feed;
            rawimage.material.mainTexture = feed;
        }
    }
}