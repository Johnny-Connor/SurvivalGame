using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    // Components
    private Animator _animator;

    // Other GameObjects
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private CreditsButton _creditsButton;
    [SerializeField] private BackButton[] _backButtons;

    private void Awake() {

        void Subscriptions(){
            _settingsButton.OnSettingsButtonClick += SettingsScreenTrigger;
            _creditsButton.OnCreditsButtonClick += CreditsButtonTrigger;
            for (int i = 0; i < _backButtons.Length; i++){
                _backButtons[i].OnBackButtonClick += BackButtonTrigger;
            }
        }

        _animator = GetComponent<Animator>();
        Subscriptions();

    }

    private void SettingsScreenTrigger(object sender, EventArgs e){
        _animator.SetTrigger("Settings");
    }

    private void CreditsButtonTrigger(object sender, EventArgs e){
        _animator.SetTrigger("Credits");
    }

    private void BackButtonTrigger(object sender, EventArgs e){
        _animator.SetTrigger("Title");
    }

}
