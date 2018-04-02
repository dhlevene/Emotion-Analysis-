using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObjectToList : MonoBehaviour {

    private int index = 0;

    public Text timerText;

    public GameObject itemTemplate;

    public GameObject content;

    

    public void AddButtonClick()
    {
        var copy = Instantiate(itemTemplate);
        copy.transform.SetParent(content.transform, false);
        copy.GetComponentInChildren<Text>().text = timerText.text;

        int copyOfIndex = index;

        copy.GetComponent<Button>().onClick.AddListener(
            () =>
            {
                // to-do: anything that happens at the current index
                Debug.Log("Index number: " + copyOfIndex);
            }
            );
        index++;
    }
}
