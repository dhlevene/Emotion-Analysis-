using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphFunctions : MonoBehaviour {

    public PlayerEmotions emotions;
    public Text textArea;
    public EmotionGraph.EmotionGraph.Node graph;

    List<int> affectivaData;
    int frameCount = 0;
    string fileName = "DEFAULT_GRAPH.txt";

    public void Start()
    {
        graph = EmotionGraph.EmotionGraph.InitGraph(fileName);
        //graph.AddNode(new List<int>() { 20, 0, 0, 0, 0 }, "Neutral");
    }

    public void Update()
    {
        frameCount++;

        if (frameCount % 30 == 0)
        {
            affectivaData = emotions.getEmotions();
            populateTextArea(affectivaData);
        }
    }

    public void populateTextArea(List<int> emotionValues)
    {
        string emotion = graph.FindEmotion(emotionValues);
        //Debug.Log("Joy: " + emotionList[0] + ", Sadness: " + emotionList[1] + ", Anger: " + emotionList[2] + ", Disgust: " + emotionList[3] + ", Surprise: " + emotionList[4]);
        //Debug.Log(temp);
        textArea.text = emotion;
    }

    public void addToGraph(List<int> tagValues, string tagName)
    {
        graph.AddNode(tagValues, tagName);
    }
}
