using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] private float _health;
    [SerializeField] private float _rawDmg;    
    [SerializeField] private float _spd;
    [SerializeField] private float _range;

    public void AddHealth(float value){
        _health += value;
        if (_health <= 0){
            Destroy(gameObject);
        }
    }

    public float Range{
        get { return _range; }
    }

    public float RawDmg{
        get { return _rawDmg; }
    }

    public float Spd{
        get { return _spd; }
    }

}