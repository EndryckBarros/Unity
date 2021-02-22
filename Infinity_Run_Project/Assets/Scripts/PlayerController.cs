using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnPlayerHitted;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    public Transform startPlayerPosition;

    private bool canJump;
    private bool isEnable;

    public float jumpFactor = 5f;
    public float forwardFactor = 0.2f;
    private float forwardForce = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        canJump = true;
        isEnable = false;
    }

    public void SetActive()
    {
        isEnable = true;
        canJump = true;
        animator.Play("Player_Run");
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        gameObject.transform.localPosition = startPlayerPosition.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (!isEnable) return;
        if (canJump)
        {
            canJump = false;
            
            if(transform.position.x < 0)
            {
                forwardForce = forwardFactor;
            }
            else
            {
                forwardForce = 0f;
            }

            playerRigidbody.velocity = new Vector2(forwardForce, jumpFactor);
            animator.Play("Player_Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnable) return;
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.Play("Player_Hurt");
            isEnable = false;
            OnPlayerHitted.Invoke();
        }
        else
        {
            animator.Play("Player_Run");
        }

        canJump = true;
    }
}
