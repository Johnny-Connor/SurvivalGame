using System;
using UnityEngine;

public class PlayerColliderAdjuster : MonoBehaviour
{

    private CharacterController2D _controller;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2d;

    private void Awake() {
        _boxCollider2d = GetComponent<BoxCollider2D>();
        _controller = GetComponent<CharacterController2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _controller.OnFlip += AdjustCollider;
    }

    private void AdjustCollider(object sender, EventArgs e){
        if (!_spriteRenderer.flipX){
            _boxCollider2d.offset = new Vector2 (-0.042f, -0.083f);
        }
        else{
            _boxCollider2d.offset = new Vector2 (0.042f, -0.083f);
        }
    }

}