using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    private float bounce = 20f;
    private Animator animator;

    private void Start()
    {
        animator =  GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsTouching", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void Anim()
    {
        animator.SetBool("IsTouching", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Invoke(nameof(Anim), 0.2f);
    }

    
}
