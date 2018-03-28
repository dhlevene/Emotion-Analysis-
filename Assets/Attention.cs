using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attention : MonoBehaviour {

    public PlayerEmotions emotions;
    public Text textArea;
    private int temp = 0;
    // Use this for initialization

    public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        temp++;
        if(temp % 30 == 0)
        {
            populate();
        }
	}

    public void populate()
    {
        textArea.text = emotions.calculateAttention().ToString();
    }
}
