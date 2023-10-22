using System.Collections;
using System.Collections.Generic;
using UnityEngine

public class Pendulum : MonoBehaviour//Con lac don
{
   private Rigidbody2D rb;
   public float moveSpeed;
   public float leftAngle;
   public float rightAngle;

   bool movingClockwise;

   private void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        movingClockwise = true;
   }

   private void Update()
   {
        rb.angularVelocity = moveSpeed;
        Move();
   }

   public void ChangeMoveDir()
   {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
   }

   public void Move()
   {
        ChangeMoveDir();
        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }
        else
        {
            rb.angularVelocity = -1*moveSpeed;
        }
   }
}
