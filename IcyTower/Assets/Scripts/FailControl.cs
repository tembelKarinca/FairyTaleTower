using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailControl : MonoBehaviour
{      public GameObject scene;
    GameController sceneControl;
    void Start()
    {
         sceneControl = scene.GetComponent<GameController>();
    }

   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player")
        {
            sceneControl.FailPnl.SetActive(true);
        }
       
       
    }
}
