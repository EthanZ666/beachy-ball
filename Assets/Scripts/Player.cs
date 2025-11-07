using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 15f;

    [SerializeField]
    private float _jumpForce = 15f;

    private float _movementX;
    private Rigidbody2D _playerBody;
    private SpriteRenderer _sr;
    private Animator _anim;
    private static string WALK_ANIMATION = "Walk";

    private bool _isGrounded;
    private static string GROUND_TAG = "Ground";

    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _jumpKey;
    
    public void Initialize(PlayerData data)
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        

        _sr = GetComponent<SpriteRenderer>();
        _playerBody.gravityScale = 4.5f;

        _leftKey = data.GetLeftKey();
        _rightKey = data.GetRightKey();
        _jumpKey = data.GetJumpKey();
    }

    public void Update()
    {
        Move();
        Animate();
        Jump();
    }

    private void Move()
    {
        _movementX = 0f;
        if (Input.GetKey(_leftKey))
        {
            _movementX = -1f;
        }
        
        if (Input.GetKey(_rightKey))
        {
            _movementX = 1f;
        } 

        transform.position += new Vector3(_movementX, 0f, 0f) * Time.deltaTime * _moveForce;
    }

    private void Animate()
    {
        if (_movementX > 0)
        {
            _sr.flipX = true;
            _anim.SetBool(WALK_ANIMATION, true);
        }
        else if (_movementX < 0)
        {
            _sr.flipX = false;
            _anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            _anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            _isGrounded = false;
            _playerBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }
    }
}