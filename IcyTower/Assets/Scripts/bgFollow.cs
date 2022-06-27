using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgFollow : MonoBehaviour
{
     private const float PLAYER_DISTANCE_SPAWN_LEVLE_PART = 0.5F;
      public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 velocity = Vector3.zero;
    public GameObject bg;
    PlayerMovement player;

    public float smoothTime = 0.3F;
    // Update is called once per frame
     private void Start() {
        player = targetObject.GetComponent<PlayerMovement>();
    }
    void LateUpdate()
    {
        targetedPosition =targetObject.transform.position ;
        
         if(player.score%50==0 && player.score != 0){
        
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
        if (Vector3.Distance(targetObject.transform.position,transform.position) < PLAYER_DISTANCE_SPAWN_LEVLE_PART)
        {
            player.score +=5;
        }
        }
       
        
        
     
    }
}
