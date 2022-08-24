using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Stats _characterStats;
    private Slider _slider;

    private void Awake() {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _characterStats.Health;
    }

    private void Update()
    {
        _slider.value = _characterStats.Health;
    }

}