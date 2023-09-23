using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject cam;
    public GameObject newPos;
    private Animator anim;
    private bool Change = false;

   
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player") && !Change)
        {
            NoFlag();
            Change = true;
            cam.transform.position = newPos.transform.position;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void NoFlag()
    {
        anim.SetTrigger("Flag");
        Invoke(nameof(HaveFlag), 1f);
    }

    private void HaveFlag()
    {
        anim.SetTrigger("Idle");
    }
}
