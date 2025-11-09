using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 12f;

    [SerializeField]
    private float _jumpForce = 14f;

    private float _movementX;
    private Rigidbody2D _playerBody;
    private SpriteRenderer _sr;
    private Animator _anim;
    private static string WALK_ANIMATION = "Walk";
    private static string IDLE = "Idle";

    private bool _isGrounded;
    private static string GROUND_TAG = "Ground";

    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _jumpKey;

    private float _idleTimer = 0f;
    private float _idleDelay = 30f;
    private bool _isIdle = false;
    private bool _idlePlaying = false;
    private float _idleAnimationDuration = 0.5f;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }
    
    public virtual void Initialize(PlayerData data)
    {
        _playerBody.gravityScale = 4.5f;

        _leftKey = data.GetLeftKey();
        _rightKey = data.GetRightKey();
        _jumpKey = data.GetJumpKey();
    }

    public void Update()
    {
        Move();
        AnimateWalk();
        Jump();
        HandleIdle();
    }

    public void Move()
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

        Vector2 vel = _playerBody.linearVelocity;
        vel.x = _movementX * _moveForce;
        _playerBody.linearVelocity = vel;

    }

    public virtual void AnimateWalk()
    {
        
        if (_movementX > 0)
        {
            _sr.flipX = true;
            this.GetAnimator().SetBool(WALK_ANIMATION, true); 
        } else if (_movementX < 0) 
        {
            _sr.flipX = false;
            this.GetAnimator().SetBool(WALK_ANIMATION, true); 
        } else
        {
            this.GetAnimator().SetBool(WALK_ANIMATION, false);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            _isGrounded = false;
            Vector2 vel = _playerBody.linearVelocity;
            vel.y = _jumpForce;
            _playerBody.linearVelocity = vel;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }
    }

    private void HandleIdle()
    {
        if (_movementX != 0f || Input.GetKey(_jumpKey))
        {
            _idleTimer = 0f;
            _idlePlaying = false;
            return;
        }

        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _idleDelay && !_idlePlaying)
        {
            _idlePlaying = true;
            PlayIdleAnimation();
            StartCoroutine(StopIdleAfterAnimation());
        }
    }

    private IEnumerator StopIdleAfterAnimation()
    {
        yield return new WaitForSeconds(_idleAnimationDuration);
        _idlePlaying = false;
        _idleTimer = 0f;
    }

    public virtual void PlayIdleAnimation() { }

    public virtual Animator GetAnimator()
    {
        return this._anim;
    }

    public float GetMoveForce()
    {
        return this._moveForce;
    }

    public void SetMoveForce(float newForce)
    {
        if (newForce > 0f && newForce <= 25f)
            _moveForce = newForce;
        else
            throw new Exception("Invalid move force value.");
    }

    public float GetJumpForce()
    {
        return this._jumpForce;
    }

    public void SetJumpForce(float newForce)
    {
        if (newForce > 0f && newForce <= 20f)
            _jumpForce = newForce;
        else
            throw new Exception("Invalid jump force value.");
    }
}