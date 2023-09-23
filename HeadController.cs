using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public Transform[] movePoints; // Các vị trí di chuyển lần lượt
    public float initialSpeed = 2f; // Tốc độ ban đầu
    public float acceleration = 0.1f; // Tốc độ tăng lên sau mỗi vị trí

    private int currentMovePointIndex = 0;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = initialSpeed;
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentMovePointIndex].position, currentSpeed * Time.deltaTime);
    }

    private IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(5f);
        Move();
    }


    private void Update()
{
    currentSpeed += acceleration;
    if (currentMovePointIndex < movePoints.Length)
    {
        if (Vector3.Distance(transform.position, movePoints[currentMovePointIndex].position) < 0.01f)
        {
            currentMovePointIndex++;
            currentSpeed = initialSpeed;
            StartCoroutine(MoveDelay());
        }
        else
        {
            Move();
        }

        if (currentMovePointIndex == movePoints.Length )
        {
            currentMovePointIndex = 0;
        }
    }
}
    
}

