﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public PlayerEmotions affectiva;
    public LiveToggle toggle;
    public GraphFunctions graphHandler;
    public GameObject panel;
    public GameObject tagTitle;
    public GameObject tagDescription;
    List<int> emotionValues;
    public Affdex.Detector detector;

    public void playButton()
    {
        affectiva.resumeStream();
    }

    public void pauseButton()
    {
        affectiva.pauseStream();
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
        affectiva.pauseStream();
        //detector.StopDetector();
    }

    public void cancelButton()
    {
        affectiva.resumeStream();
        tagTitle.GetComponent<InputField>().text = "";
        panel.SetActive(false);
        //detector.StartDetector();
    }

    public void emotionSubmit()
    {
        emotionValues = affectiva.getEmotions();
        string title = tagTitle.GetComponent<InputField>().text;
        graphHandler.addToGraph(emotionValues, title);

        Debug.Log("Tag Title: " + tagTitle.GetComponent<InputField>().text + "    Joy is: " + emotionValues[0] + 
            ", Sadness is: " + emotionValues[1] + ", Anger is: " + emotionValues[2] + ", Disgust is: " + emotionValues[3] + ", Surprise is: " + emotionValues[4]);
        panel.SetActive(false);
        tagTitle.GetComponent<InputField>().text = "";
        playButton();
        //detector.StartDetector();
    }

    public void attentionSubmit()
    {
        Debug.Log(tagTitle.GetComponent<InputField>().text);
        Debug.Log(tagDescription.GetComponent<InputField>().text);
        panel.SetActive(false);
        tagTitle.GetComponent<InputField>().text = "";
        playButton();
    }

}
