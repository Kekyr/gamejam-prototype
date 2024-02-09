using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private enum State { Idle, Running, Falling, Jumping };

    // injections
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private PauseUIController pauseUI;

    // settings
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private int maxJumps = 2;

    // state
    [SerializeField] private int jumps = 0;
    [SerializeField] private State state;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private bool onGround = false;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Assert.IsNotNull(sr);
        Assert.IsNotNull(rb);
        Assert.IsNotNull(anim);
        Assert.IsNotNull(jumpSound);
        Assert.IsNotNull(pauseUI);
    }

    // Update is called once per frame
    void Update()
    {
        HandlePause();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            onGround = true;
            jumps = 0;
        }
    }

    public void OnDeath()
    {
        anim.SetTrigger("dead");
        rb.bodyType = RigidbodyType2D.Static; 
        rb.velocity = Vector3.zero;
    }

    public void OnDeathAnimationEnded()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HandlePause()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            bool paused = GameMaster.Instance.Pause();
            if (paused)
            {
                pauseUI.Show();
            }
            else
            {
                pauseUI.Hide();
            }
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        /*Jump*/
        if (Input.GetButtonDown("Jump") && jumps < maxJumps)
        {
            jumpSound.Play();
            onGround = false;
            ++jumps;
            rb.velocity = Vector2.up * jumpForce;
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        state = State.Running;
        if (onGround)
        {
            state = horizontalInput == 0 ? State.Idle : State.Running;
        }
        if (rb.velocity.y > .1f)
        {
            state = State.Jumping;
        }
        if (rb.velocity.y < -.1f)
        {
            state = State.Falling;
        }

        anim.SetInteger("state", (int)state);

        if (horizontalInput != 0)
        {
            facingRight = horizontalInput > 0;
        }

        Flip();
    }

    private void Flip()
    {
        sr.flipX = !facingRight;
    }
}