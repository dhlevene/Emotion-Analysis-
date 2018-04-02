using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEmotion : MonoBehaviour {

    public PlayerEmotions emotions;
    public Text textArea;
    private int temp = 0;
    public EmotionGraph.EmotionGraph.Node graph;
    public string fileName = "DEFAULT_GRAPH.txt";
    // Use this for initialization

    public void Start()
    {
        graph = EmotionGraph.EmotionGraph.InitGraph(fileName);
        graph.AddNode(new List<int>() { 20, 0, 0, 0, 0 }, "Neutral");
    }

    // Update is called once per frame
    public void Update()
    {
        temp++;
        //List<float> affectivaData = emotions.getEmotions();

        if (temp % 30 == 0)
        {
            //populate(affectivaData);
        }
    }

    public void populate(List<float> data)
    {
        List<int> emotionList = new List<int>();
        for (int i = 0; i < data.Count; i++)
        {
            emotionList.Add((int)data[i]);
        }

        string emotion = graph.FindEmotion(emotionList);
        //Debug.Log("Joy: " + emotionList[0] + ", Sadness: " + emotionList[1] + ", Anger: " + emotionList[2] + ", Disgust: " + emotionList[3] + ", Surprise: " + emotionList[4]);
        //Debug.Log(temp);
        textArea.text = emotion;
    }

    public void addToGraph(List<int> values)
    {

    }
}
