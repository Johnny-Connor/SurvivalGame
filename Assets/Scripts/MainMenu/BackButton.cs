using System;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public EventHandler OnBackButtonClick;

    public void SendBackEvent(){
        OnBackButtonClick?.Invoke(this, EventArgs.Empty);
    }

}