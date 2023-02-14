using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement_Rolaf : MonoBehaviour
{
    public float velocity = 20;
    public LayerMask Ground;
    public float rayDistance = 1.5f;
    private Rigidbody2D rb;
    private Animator animator;
    SpriteRenderer rend;
    public AudioClip JumpAudio;
    public AudioClip WalkAudio;
    [Range(0, 1)]
    public float volumemusic;
    public GameObject SoundRange;

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

            animator.SetBool("IsWalking", true); //Hago que cuando presione A, le diga al animator que "IsWalking" es true y que el sprite del jugador se gire.
            rend.flipX = true;
            transform.Translate(new Vector3(-velocity * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D)) 
        {

            animator.SetBool("IsWalking", true); //Hago que cuando presione D, le diga al animator que "IsWalking" es true y el sprite del jugador no se gire.
            rend.flipX = false;
            transform.Translate(new Vector3(velocity * Time.deltaTime, 0, 0));
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsGrounded", true);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            AudioManager.instance.PlayAudio(JumpAudio,volumemusic);
            animator.Play("JumpAnimation"); //Hago que cuando presione la tecla espacio, le diga al animator que "IsWalking" es true.
            rb.AddForce(new Vector2(0, 2000));
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("JumpAnimation");
        }
    }
    bool IsGrounded() //El raycast detectara si el objeto con el que colisiona, tiene el tag de "suelo" devolvera true.
    {
        RaycastHit2D resultado = Physics2D.Raycast(transform.position,Vector2.down, rayDistance, Ground.value);


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
    void OnDrawGizmosSelected() //Asigno al raycast un color y una direccion hacia donde apuntar.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
    void OnCollisionEnter2D(Collision2D collision) //Cuando el colider del objeto colisione con el del jugador la escena se resetea.
    {
        if (collision.gameObject.tag == "Deathzone")
        {
            GameManager.instance.Score = 100;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

