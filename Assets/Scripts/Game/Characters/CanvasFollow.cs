using UnityEngine;

public class CanvasFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;

    void Update()
    {
        transform.position = _target.transform.position;
    }

}