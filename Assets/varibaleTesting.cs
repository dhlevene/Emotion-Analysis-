using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varibaleTesting : MonoBehaviour {

    public PlayerEmotions emotions;
    public bool paused = false;
    public GameObject obj;

    public void buttonPress()
    {
        if (obj.activeSelf)
            obj.SetActive(false);
        else
            obj.SetActive(true); 

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
