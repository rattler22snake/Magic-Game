using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class VoiceCommand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        actions.Add("forward", Forward);
        actions.Add("backward", Back);
        actions.Add("up", Up);
        actions.Add("down", Down);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) 
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward() 
    {
        transform.Translate(1, 0, 0);
    }

    private void Back() 
    {
        transform.Translate(-1, 0, 0);
    }

    private void Up() 
    {
        transform.Translate(0, 1, 0);
    }

    private void Down() 
    {
        transform.Translate(0, -1, 0);
    }


}
