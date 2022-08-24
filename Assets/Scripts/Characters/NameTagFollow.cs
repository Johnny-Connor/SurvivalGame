using UnityEngine;

public class NameTagFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;

    void Update()
    {
        transform.position = _target.transform.position;
    }

}