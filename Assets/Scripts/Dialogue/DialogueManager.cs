using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private Queue<string> _sentences;

    private void Awake()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue){
        Debug.Log("Starting conversation.");

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence(){
        if (_sentences.Count == 0){
            EndDialogue();
            return; 
        }

        string sentence = _sentences.Dequeue();
        Debug.Log(sentence);

    }

    private void EndDialogue(){
        Debug.Log("Dialogue Is Over");
    }

}