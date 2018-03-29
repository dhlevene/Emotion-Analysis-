using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varibaleTesting : MonoBehaviour {

    public PlayerEmotions emotions;
    public bool paused = false;
    public GameObject obj;
    public string fileName = "DEFAULT_GRAPH.txt";
    public EmotionGraph.EmotionGraph.Node graph;

    void Start()
    {
        graph = EmotionGraph.EmotionGraph.InitGraph(fileName);
 
    }

    public void buttonPress()
    {

        List<float> testList = emotions.getEmotion(1);
        
        List<int> emotionList = new List<int>();
        for (int i = 0; i < testList.Count; i++)
        {
            emotionList.Add((int)testList[i]);
        }

        string temp = graph.FindEmotion(emotionList);
        Debug.Log("Joy: " + emotionList[0] + ", Sadness: " + emotionList[1] + ", Anger: " + emotionList[2] + ", Disgust: " + emotionList[3] + ", Surprise: " + emotionList[4]);
        Debug.Log(temp);


        //debugging
        /*
        //list of int's before finding emotion
        Debug.Log("Int List: ");
        for (int k = 0; k < emotionList.Count; k++)
        {
            Debug.Log("Int: " + emotionList[k]);
        }

        string temp = graph.FindEmotion(emotionList);
        
        //List of int's after finding emotion
        Debug.Log("Int List again: ");
        for (int k = 0; k < emotionList.Count; k++)
        {
            Debug.Log("Int: " + emotionList[k]);
        }*/

        //string temp = graph.FindEmotion(new List<int> { 99, 1, 0, 72, 14 });

    }
    public void getEmotion()
    {
        //print("Joy is: " + emotions.getEmotion(1));
    }

    public void toggleStream()
    {
        //Affectiva switching
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled = true;

        }
        else
        {
            obj.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<Affdex.PlayMovie>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<Affdex.CameraInput>().enabled = false;

        }

        //Video switching
        if (paused == false)
        {
            emotions.pauseStream();
            paused = true;
        }
        else if (paused == true)
        {
            emotions.resumeStream();
            paused = false;
        }
    }

	/*void Start () {
        print("Joy is: " + emotions.getEmotion(1));
	}
	
	void Update () {
        print("Joy is: " + emotions.getEmotion(1));
    }*/
}
