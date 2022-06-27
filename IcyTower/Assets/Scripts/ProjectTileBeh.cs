using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileBeh : MonoBehaviour
{
    public float Speed = 4.5f;
 
    void Update()
    {
        transform.position += transform.right* Time.deltaTime*Speed; 
        
    }
    private void OnCollisionEnter2D(Collision2D col){
      Destroy(gameObject);
    }
}
