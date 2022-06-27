using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject hp;
    private Vector3 scaleChange;
      public GameObject scene;
    GameController sceneControl;

    void Start()
    {
         scaleChange = new Vector3(0.1f, 0,0.1f);
         sceneControl = scene.GetComponent<GameController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag =="deadfish")
        {
             hp.transform.localScale -= scaleChange;
            
        }
         if (other.tag=="Player")
        {
            sceneControl.FailPnl.SetActive(true);
        }
    }
}
