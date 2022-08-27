using UnityEngine;
using UnityEngine.UI;

public class ResetScrollBar : MonoBehaviour
{

    [SerializeField] private Scrollbar _scrollbar;

    public void ResetScroll(){
        _scrollbar.value = 1;
    }

}