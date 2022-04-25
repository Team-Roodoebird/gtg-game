using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //variable to have an easy reference to the dialogue system (assigned at awake)
    public static DialogueSystem instance;

    /**
     * The main panel containing all dialogue related elements on the UI
     **/
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public Text speakerNameText;
        public Text speechText;
    }

    public ELEMENTS elements;
    public GameObject speechPanel { get { return elements.speechPanel; } }
    public Text speakerNameText { get { return elements.speakerNameText; } }
    public Text speechText { get { return elements.speechText; } }

    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;

    Coroutine speaking = null;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    /**
     * Say something and show it on the speach box.
     **/
    public void Say(string speech, string speaker = "")
    {
        /*
         * Psuedocode:
         * 1. if we are currently talking, then stop talking
         * 2. start saying the new stuff
         */
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, false, speaker));
    }


    /**
     * Say something to be added to what is already on the speech box.
     **/
    public void SayAdd(string speech, string speaker = "")
    {
        StopSpeaking();
        speechText.text = targetSpeech;
        speaking = StartCoroutine(Speaking(speech, true, speaker));
    }


    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }


    string targetSpeech = "";
    IEnumerator Speaking(string speech, bool additive, string speaker = "")
    {
        /*
         * Psuedocode:
         * 1. make sure the speach panel is visible on screen
         * 2. if(not additive) -> clear out current text
         * 3. make sure current speaker name is visible
         * 4. while currently shown text != text we want to show
         *      print the next character and return
         * 5. wait for user input
         */

        speechPanel.SetActive(true);
        targetSpeech = speech;

        if (!additive)
            speechText.text = "";
        else
            targetSpeech = speechText.text + targetSpeech;

        speakerNameText.text = DetermineSpeaker(speaker);
        isWaitingForUserInput = false;

        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            //finish for this frame and come back to this line on the next frame
            yield return new WaitForEndOfFrame();
        }

        //text finished
        isWaitingForUserInput = true;
        while (isWaitingForUserInput)
        {
            yield return new WaitForEndOfFrame();
        }
        StopSpeaking();
    }


    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text; // default return is the current speaker

        if (s != speakerNameText.text && s != "")
            retVal = (s.ToLower().Contains("narator")) ? "" : s;

        return retVal;
    }
}
