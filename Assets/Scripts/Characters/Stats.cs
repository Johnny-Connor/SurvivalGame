using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] private float _health;
    [SerializeField] private float _dmg;    
    [SerializeField] private float _spd;
    [SerializeField] private float _range;

    public void AddHealth(float value){
        _health += value;
        if (_health <= 0){
            Destroy(transform.parent.gameObject);
        }
    }

    public float Health{
        get { return _health; }
        set { _health = value; }
    }

    public float Dmg{
        get { return _dmg; }
    }

    public float Spd{
        get { return _spd; }
    }

    public float Range{
        get { return _range; }
    }

}