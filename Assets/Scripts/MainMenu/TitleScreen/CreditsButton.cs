using System;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{

    public EventHandler OnCreditsButtonClick;

    public void SendCreditsEvent(){
        OnCreditsButtonClick?.Invoke(this, EventArgs.Empty);
    }

}