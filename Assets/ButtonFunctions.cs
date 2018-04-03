using System.Collections;
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
    int yValue = -10;
    public Affdex.Detector detector;
    public GameObject scrollView;
    public GameObject TextPrefab;

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

    public void toggleVideo()
    {
        toggle.toggleFirstTime();
        panel.SetActive(false);
    }
    public void toggleWebcam()
    {
        toggle.GetComponent<Toggle>().isOn = !toggle.GetComponent<Toggle>().isOn;
        toggle.Switch();
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

        addToScrollView(title);

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

    public void addToScrollView(string textToAdd)
    {
        GameObject go = Instantiate(TextPrefab);
        go.transform.SetParent(scrollView.transform);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = new Vector3(10, yValue, 0);
        yValue = yValue - 30;
        go.GetComponent<Text>().text = textToAdd;
    }

}
