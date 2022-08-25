using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue _dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
    }

}