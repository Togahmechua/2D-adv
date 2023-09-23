using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public Behaviour CherriesCanvas;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CherriesCanvas.enabled = !CherriesCanvas.enabled;
        }
    }
}
