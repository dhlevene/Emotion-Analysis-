using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LiveToggle : MonoBehaviour {
    
    public bool isOn = true;
    public GameObject track;
    public GameObject video;
    public GameObject webcam;
    public GameObject play_btn;
    public GameObject pause_btn;
    public GameObject checker;
    public void Check()
    {
        isOn = !isOn;
        checker.SetActive(true);
        video.GetComponent<VideoPlayer>().Pause();
    }

    public void Switch()
    {

        if (isOn)
        {
            GameObject.Find("Background Processes").GetComponent<Affdex.CameraInput>().enabled = false;
            GameObject.Find("Background Processes").GetComponent<Affdex.PlayMovie>().enabled = true;
            video.SetActive(true);
            track.SetActive(true);
            webcam.SetActive(false);
            play_btn.SetActive(true);
            pause_btn.SetActive(true);

        }
        else
        {
            video.SetActive(false);
            track.SetActive(false);
            play_btn.SetActive(false);
            pause_btn.SetActive(false);
            GameObject.Find("Background Processes").GetComponent<Affdex.PlayMovie>().enabled = false;
            GameObject.Find("Background Processes").GetComponent<Affdex.CameraInput>().enabled = true;
            webcam.SetActive(true);



        }
        //GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled = !GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled;
        //GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled = !GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled;
        
    }


}
