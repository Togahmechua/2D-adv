using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class PlayerLife2 : MonoBehaviour
{
    [SerializeField] private AudioSource ded;
    private Rigidbody2D rb;
    private Animator anim;
   

    private Vector3 respawnPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        

        anim.SetTrigger("ded");
        ded.Play();
        Invoke(nameof(Spawn), 1f);
    }

    private void Spawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("Recive");
        transform.position = respawnPoint;
    }
}
