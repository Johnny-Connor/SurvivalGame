using UnityEngine;

public class ColliderAdjuster : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2d;

    private void Awake() {
        _boxCollider2d = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        void AdjustCollider(){
            if (!_spriteRenderer.flipX){
                _boxCollider2d.offset = new Vector2 (-0.042f, _boxCollider2d.offset.y);
            }
            else{
                _boxCollider2d.offset = new Vector2 (0.042f, _boxCollider2d.offset.y);
            }
        }

        AdjustCollider();

    }

}