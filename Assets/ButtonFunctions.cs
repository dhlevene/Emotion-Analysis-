using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public PlayerEmotions handler;
    public LiveToggle toggle;
    public GameObject panel;


    public void playButton()
    {
        handler.resumeStream();
    }

    public void pauseButton()
    {
        handler.pauseStream();
    }

    public void toggleYes()
    {
        toggle.Switch();
        panel.SetActive(false);
    }
    public void toggleNo()
    {
        toggle.GetComponent<Toggle>().isOn = !toggle.GetComponent<Toggle>().isOn;
        panel.SetActive(false);
    }

}
