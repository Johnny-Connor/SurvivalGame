using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private Queue<string> _sentences;
    private PlayerMovements _playerMovements;
    private bool _isDialogueOver;

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
        Debug.Log("Dialogue Start");
        _playerMovements.IsMovementEnabled = false;
        Debug.Log("Movement disabled");

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            _sentences.Enqueue(sentence);
        }

        // Display first sentence.
        DisplayNextSentence();

    }

    public void DisplayNextSentence(){

        void EndDialogue(){
            _playerMovements.IsMovementEnabled = true;
            Debug.Log("Dialogue Over");
        }

        if (_sentences.Count == 0){
            EndDialogue();
            return; 
        }

        string sentence = _sentences.Dequeue();
        Debug.Log(sentence);

    }

}