using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    // Variables
    [SerializeField] private Queue<string> _sentences;

    // Components
    private PlayerMovements _playerMovements;

    // Events
    public EventHandler OnDialogueStart;
    public EventHandler OnDialogueEnd;

    private void Awake()
    {
        _sentences = new Queue<string>();
    }

    private void Start() {
        _playerMovements = GameObject.Find("Player").GetComponentInChildren<PlayerMovements>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !_playerMovements.IsMovementEnabled){
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue){

        OnDialogueStart?.Invoke(this, EventArgs.Empty);

        // Clear previous sentences.
        _sentences.Clear();

        // Insert new sentences to queue.
        foreach (string sentence in dialogue.sentences){
            _sentences.Enqueue(sentence);
        }

        // Display first sentence.
        DisplayNextSentence();

    }

    public void DisplayNextSentence(){

        void EndDialogue(){
            OnDialogueEnd?.Invoke(this, EventArgs.Empty);
        }

        if (_sentences.Count == 0){
            EndDialogue();
            return; 
        }

        string sentence = _sentences.Dequeue();
        Debug.Log(sentence);

    }

}