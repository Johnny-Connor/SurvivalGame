using System;
using UnityEngine;

public class NpcPhase : MonoBehaviour
{

    private Stats _stats;

    private void Awake() {
        _stats = GetComponent<Stats>();
        _stats.OnEntityDeath += Destroy;
    }

    private void Destroy(object sender, EventArgs e){
        Destroy(transform.parent.gameObject);
    }

}