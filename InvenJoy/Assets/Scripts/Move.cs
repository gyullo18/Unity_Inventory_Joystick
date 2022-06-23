using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
     public float moveSpeed = 5f;

    private PlayerInput playerInput;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponentInChildren<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        Anim();
    }

    private void PlayerMove()
    {
        Vector2 move = playerRigidbody.velocity;
        move.x = playerInput.move * moveSpeed;
        playerRigidbody.velocity = move;
    }

    private void Anim()
    {
        switch (playerInput.move)
        {
            case 0:
                playerAnimator.SetBool("IsRun", false);
                break;
            case 1:
                playerRenderer.flipX = false;
                playerAnimator.SetBool("IsRun", true);
                break;
            case -1:
                playerRenderer.flipX = true;
                playerAnimator.SetBool("IsRun", true);
                break;
        }
    }
}
