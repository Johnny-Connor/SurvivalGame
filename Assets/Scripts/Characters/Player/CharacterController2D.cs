using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

	// Movement
	[SerializeField] private float m_JumpForce = 400f;	// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement.
	[SerializeField] private bool m_AirControl = true;	// Whether or not a player can steer while jumping.
	[SerializeField] private LayerMask m_WhatIsGround;	// A mask determining what is ground to the character.
	[SerializeField] private float _extraJumpDetectionHeight = .01f; // 
	private bool _isGrounded; // Whether or not the player is grounded.
	private Vector3 m_Velocity = Vector3.zero;

	// Components
	private BoxCollider2D _boxCollider2d;
	private Rigidbody2D m_Rigidbody2d;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_boxCollider2d = GetComponent<BoxCollider2D>();
		m_Rigidbody2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = _isGrounded;
		_isGrounded = false;
		RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, _extraJumpDetectionHeight, m_WhatIsGround);
		if (raycastHit.collider != null){
			_isGrounded = true;
		}
	}

	public void Move(float move, bool jump)
	{
		// Only control the player if grounded or airControl is turned on
		if (_isGrounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2d.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2d.velocity = Vector3.SmoothDamp(m_Rigidbody2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && transform.localScale.x == -1)
			{
				FaceRight(true);
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && transform.localScale.x == 1)
			{
				FaceRight(false);
			}
		}
		// If the player should jump...
		if (_isGrounded && jump)
		{
			// Add a vertical force to the player.
			_isGrounded = false;
			m_Rigidbody2d.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	private void FaceRight(bool option)
	{
		if (option){
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		}
		else{
			transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
		}
	}

}