using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    DialogueSystem dialogue;
    public string[] testString = new string[]
    {
        "The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues.:Anouncer",
        "The 20 meter pacer test will begin in 30 seconds.",
        "Line up at the start.",
        "The running speed starts slowly but gets faster each minute after you hear this signal bodeboop.",
        "A sing lap should be completed every time you hear this sound.",
        "ding Remember to run in a straight line and run as long as possible.",
        "The second time you fail to complete a lap before the sound, your test is over.",
        "The test will begin on the word start. On your mark. Get ready!… Start. ding﻿"
    };


    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }


    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space is pressed");
            if(!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {

                if (index >= testString.Length)
                {
                    return;
                }
                Say(testString[index]);
                index++;
            }
        }
    }


    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, speaker);
    }
}
