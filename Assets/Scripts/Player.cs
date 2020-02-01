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


    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move*_playerSpeed, _rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            Debug.Log("JUMP");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }


    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if(_resetJump == false)
            {
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
