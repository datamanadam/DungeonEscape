using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private  Rigidbody2D _rigid;
    [SerializeField] float _jumpForce = 5f;
    private bool _grounded = false;
    private bool _resetJump = false;
    [SerializeField] float _playerSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimation playerAnimation;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {

        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        FlipSpriteWithMove(move);
        PlayerJump();
        _rigid.velocity = new Vector2(move * _playerSpeed, _rigid.velocity.y);
        playerAnimation.Move(move);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnimation.Jump(true);
        }
    }

    private void FlipSpriteWithMove(float move)
    {
        if (move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawLine(transform.position, Vector2.down );
        if (hitInfo.collider != null)
        {
            if(_resetJump == false)

            {
                playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;  
    }



}
