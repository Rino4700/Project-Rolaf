using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Rolaf : MonoBehaviour
{
    public float velocity = 20;
    public LayerMask Ground;
    public float rayDistance = 1.5f;
    private Rigidbody2D rb;
    private Animator animator;
    SpriteRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        IsGrounded();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.Play("WalkAnimation");
            rend.flipX = true;
            transform.Translate(new Vector3(-velocity * Time.deltaTime, 0, 0));
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.Play("WalkAnimation");
            rend.flipX = false;
            transform.Translate(new Vector3(velocity * Time.deltaTime, 0, 0));
        }
        else
        {
            animator.Play("IdleAnimation");
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(new Vector2(0, 2000));
        }
        
    }

        bool IsGrounded()
        {
            RaycastHit2D resultado = Physics2D.Raycast(transform.position,
                Vector2.down, rayDistance, Ground.value);

            if (resultado)
            {
                Debug.Log(resultado.collider.gameObject.name);
                if (resultado.collider.gameObject.CompareTag("suelo"))
                {
                    return true;
                }
            }

            return false;
        }

}
