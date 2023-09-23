using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collect;
    public int totalCherries;
    public int cherriesCollected = 0;
    public Text CherriesText;

    private void Start()
    {
        GameObject[] cherries = GameObject.FindGameObjectsWithTag("Cherry");
        totalCherries = cherries.Length;
        CherriesText.text = "Cherries: " + cherriesCollected+ "/" + totalCherries; 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            cherriesCollected++;
            CherriesText.text = "Cherries: " + cherriesCollected+ "/" + totalCherries; 
        }
    }
}
