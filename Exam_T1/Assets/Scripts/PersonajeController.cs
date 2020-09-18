using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public float jumpForce = 30f;
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;
    public GameObject Kunai;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private Transform _transform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", ANIMATION_QUIETO);

        if (Input.GetKey(KeyCode.RightArrow))  
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            animator.SetInteger("Estado", ANIMATION_CORRER);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            animator.SetInteger("Estado", ANIMATION_CORRER);
            sr.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Instantiate(Kunai, _transform.position, Quaternion.identity);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemigo")
        {

            Debug.Log("Ninja choco con algo");

        }
    }
}
