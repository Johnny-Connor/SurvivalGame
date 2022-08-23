using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

	[SerializeField] private float m_JumpForce = 400f;	// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;	// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;	// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
	private float _groundedRadius = .25f; // A circlecast to the groundcheck position.
	private bool m_Grounded; // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	private Vector3 m_Velocity = Vector3.zero;
	public event EventHandler OnLandEvent;
	public event EventHandler OnFlip;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground.
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, _groundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent?.Invoke(this, EventArgs.Empty);
			}
		}
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// Only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && _spriteRenderer.flipX)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && !_spriteRenderer.flipX)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	private void Flip()
	{
		// Switch the way the player is facing.
		_spriteRenderer.flipX = !_spriteRenderer.flipX;
		OnFlip?.Invoke(this, EventArgs.Empty);
	}

}