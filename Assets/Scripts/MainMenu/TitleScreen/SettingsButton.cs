using System;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    public EventHandler OnSettingsButtonClick;

    public void SendSettingsEvent(){
        OnSettingsButtonClick?.Invoke(this, EventArgs.Empty);
    }

}
