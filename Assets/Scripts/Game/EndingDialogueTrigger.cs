using System;
using UnityEngine;

public class EndingDialogueTrigger : MonoBehaviour
{

    // Variables
    private int _dialogueIndex = 1;

    // Components
    [SerializeField] private Dialogue _dialogue;

    // Manager and Others
    private DialogueManager _dialogueManager;
    private Stats _bossStats;
    private Teleporter _teleporter;

    private void Start() {
        _bossStats = GameObject.Find("Boss").GetComponentInChildren<Stats>();
        _bossStats.OnEntityDeath += TriggerDialogue;
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _dialogueManager.OnDialogueEnd += EndGame;
        _teleporter = FindObjectOfType<Teleporter>();
    }

    private void TriggerDialogue(object sender, EventArgs e){
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
    }

    private void EndGame(object sender, EventArgs e){
        if (_dialogueIndex == 0){
            _teleporter.TriggerTeleport();
        }
        else{
            _dialogueIndex--;
        }
    }

}