using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagType : MonoBehaviour {
    public GameObject emo_button;
    public  GameObject atten_button;

    public void getOption()
    {
        if(GameObject.Find("Dropdown").GetComponent<Dropdown>().value == 1)
        {
            emo_button.SetActive(false);
            atten_button.SetActive(true);
        }
        else
        {
            atten_button.SetActive(false);
            emo_button.SetActive(true);
        }
    }
}
