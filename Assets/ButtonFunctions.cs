using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public PlayerEmotions handler;
    public LiveToggle toggle;
    public GameObject panel;
    public GameObject tag;
    public GameObject description;


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

    public void enableTag()
    {
        panel.SetActive(true);
        pauseButton();
    }

    public void cancelButton()
    {
        panel.SetActive(false);
        playButton();
    }

    public void emotionSubmit()
    {
        ArrayList emotions = new ArrayList();
        Debug.Log(tag.GetComponent<InputField>().text);
        Debug.Log(description.GetComponent<InputField>().text);
        emotions = handler.getEmotion(1);
        Debug.Log("Tag Title: " + tag.GetComponent<InputField>().text + "    Joy is: " + emotions[0] + 
            ", Sadness is: " + emotions[1] + ", Surprise is: " + emotions[2] + ", Disgust is: " + emotions[3]);
        panel.SetActive(false);
        playButton();
    }

    public void attentionSubmit()
    {
        
        Debug.Log(tag.GetComponent<InputField>().text);
        Debug.Log(description.GetComponent<InputField>().text);
        panel.SetActive(false);
        playButton();
    }

}
