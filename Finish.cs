using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private ItemCollector itemCollector;
    [SerializeField] private AudioSource finish;
    private bool levelCompeleted = false;

    private void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(itemCollector.totalCherries == itemCollector.cherriesCollected)
        {
            if (collision.gameObject.name == "Player" && levelCompeleted == false)
            {
            finish.Play();
            Invoke(nameof(NewLevel), 1);
            levelCompeleted = true;
            }
        }
        else 
        {
           return ;
        }
    }

    private void NewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
