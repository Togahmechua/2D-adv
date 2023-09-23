using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumRound : MonoBehaviour
{
   public float moveSpeed;

   private void Update()
   {
        transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
   }
}
