using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public GameObject Speak_Frame;
    public TextElement text;
    
    void Start()
    {
        //text = this.transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    public void Speak(string message, int time)
    {
        Speak_Frame.SetActive(true);

        //text.text = message;
        //text_.text = message;

        StartCoroutine(Wait(time));
    }

    IEnumerator Wait(int time) { yield return new WaitForSeconds(time); Speak_Frame.SetActive(false); }
}
