using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamageable
{
    public int playerDiamondAmount=0;

    private  Rigidbody2D _rigid;
    [SerializeField] float _jumpForce = 5f;
    private bool _grounded = false;
    private bool _resetJump = false;
    [SerializeField] float _playerSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimation playerAnimation;

    private SpriteRenderer swordAcrSprite;

    [SerializeField]public int Health { get; set; }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        swordAcrSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;


    }

    void Update()
    {
        if(Health > 0)
        {
            Movement();
            Attack();
        }

    }

    private void Attack()
    {
        //Input.GetMouseButtonDown(0) ||
        if ((CrossPlatformInputManager.GetButtonDown("A_Button")) && _grounded == true)
        {
            playerAnimation.PlayAttackAnimation();
        }
    }

    void Movement()
    {

        float move = CrossPlatformInputManager.GetAxis("Horizontal");// Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        FlipSpriteWithMove(move);
        PlayerJump();
        _rigid.velocity = new Vector2(move * _playerSpeed, _rigid.velocity.y);
        playerAnimation.Move(move);
    }

    private void PlayerJump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded())
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
            swordAcrSprite.flipX = false;
            swordAcrSprite.flipY = false;
            Vector3 newPos = swordAcrSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordAcrSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
            swordAcrSprite.flipY = true;
            Vector3 newPos = swordAcrSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordAcrSprite.transform.localPosition = newPos;
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

    public void Damage()
    {
        if (Health < 1) { return; }
        Health --;
        UIManager.UInstance.UpdateLives(Health);
        if (Health <=0)
        {
            playerAnimation.PlayPlayerDeath();
        }

    }

    public void AddGems(int amount)
    {
        playerDiamondAmount += amount;
        UIManager.UInstance.UpdateGemCount(playerDiamondAmount);
    }
}
