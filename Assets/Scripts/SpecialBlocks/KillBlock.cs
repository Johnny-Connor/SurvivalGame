using UnityEngine;

public class KillBlock : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player") || col.gameObject.layer == LayerMask.NameToLayer("NPC")){
            col.gameObject.GetComponentInChildren<Stats>().Kill();
        }
    }

}