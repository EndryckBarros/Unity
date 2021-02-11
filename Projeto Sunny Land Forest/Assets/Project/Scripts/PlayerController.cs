using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;

    public Transform groudCheck;
    public bool isGroud;
    public bool facingRight = true;

    public float speed;
    public float touchRun = 0.0f;

    // PULO
    public bool jump = false;
    public int numberJump = 0;
    public int maximumJump = 2;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        facingRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGroud = Physics2D.Linecast(transform.position, groudCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnimator.SetBool("IsGrounded", isGroud);

        touchRun = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        SetMovements();
    }

    void MovePlayer(float movimentoHorizontal)
    {
        playerRigidbody.velocity = new Vector2(movimentoHorizontal * speed, playerRigidbody.velocity.y);

        /*if(movimentoHorizontal < 0 && facingRight || movimentoHorizontal > 0 && !facingRight)
        {
            Flip();
        } // Alterar a variavel de Escala manualmente */

        if(movimentoHorizontal > 0) // Utilizar a opcao de flip da imagem no render do personagem no eixo X
        {
            playerSpriteRenderer.flipX = false;
        }
        if (movimentoHorizontal < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(touchRun);

        if (jump)
        {
            JumpPlayer();
        }
    }

    void Flip() // Alterar a variavel de Escala manualmente
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        (theScale.x) *= -1;

        transform.localScale = new Vector3(theScale.x, transform.localScale.y, transform.localScale.z);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void SetMovements()
    {
        playerAnimator.SetBool("Walk", playerRigidbody.velocity.x != 0 && isGroud);
        playerAnimator.SetBool("Jump", !isGroud);
        playerAnimator.SetFloat("EixoY", playerRigidbody.velocity.y);
    }

    private void JumpPlayer()
    {
        if (isGroud)
        {
            numberJump = 0;
        }

        if (isGroud || numberJump < maximumJump)
        {
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
            isGroud = false;
            numberJump++;
        }
        jump = false;
    }
}
