using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    // Variables
    private Queue<string> _sentences;

    // Components
    private PlayerMovements _playerMovements;
    private Animator _animator;

    // UI
    private TMP_Text _sentencesText;

    // Events
    public EventHandler OnDialogueStart;
    public EventHandler OnDialogueEnd;

    private void Awake()
    {
        _sentences = new Queue<string>();
    }

    private void Start() {
        _playerMovements = GameObject.Find("Player").GetComponentInChildren<PlayerMovements>();
        _animator = GameObject.Find("DialogueBox").GetComponent<Animator>();
        _sentencesText = GameObject.Find("Dialogue_Text").GetComponent<TMP_Text>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && !_playerMovements.IsMovementEnabled){
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue){

        _animator.SetBool("isOpen", true);

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
            _animator.SetBool("isOpen", false);
        }

        if (_sentences.Count == 0){
            EndDialogue();
            return; 
        }

        string sentence = _sentences.Dequeue();
        _sentencesText.text = sentence;

    }

}