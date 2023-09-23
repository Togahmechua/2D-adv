using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject ChangeCamAnother;
    public Camera camera1;
    public Camera camera2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ChangeCamAnother.SetActive(false);
            Invoke(nameof(Change), 5f);
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }

    private void Change()
    {
        ChangeCamAnother.SetActive(true);
    }
}