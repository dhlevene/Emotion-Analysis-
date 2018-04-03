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
    public ButtonFunctions notifier;
    bool firstTime = true;
    public void Check()
    {
        if (firstTime == true)
        {
            isOn = !isOn;
            firstTime = false;
        }
        else
        {
            isOn = !isOn;
            checker.SetActive(true);
            video.GetComponent<VideoPlayer>().Pause();
        }
    }

    public void Switch()
    {
        Debug.Log(isOn);

        if (isOn)
        {
            GameObject.Find("Background Processes").GetComponent<Affdex.CameraInput>().enabled = false;
            GameObject.Find("Background Processes").GetComponent<Affdex.PlayMovie>().enabled = true;
            video.SetActive(true);
            track.SetActive(true);
            webcam.SetActive(false);
            play_btn.SetActive(true);
            pause_btn.SetActive(true);
            notifier.addToScrollView("Video analysis started:");

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
            notifier.addToScrollView("Webcam capture started:");
        }
        //GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled = !GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled;
        //GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled = !GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled;
        
    }

    public void toggleFirstTime()
    {
        firstTime = !firstTime;
    }


}
