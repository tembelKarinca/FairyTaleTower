using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVLE_PART = 20F;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField]  GameObject player;
    [SerializeField]  Transform map;
    
    

    private Vector3 lastEndPosition;

     private void Awake() {
        lastEndPosition =levelPart_Start.Find("EndPoint").position;

        // int startingSpawnLevelParts = 2;
        // for(int i = 0; i<startingSpawnLevelParts; i++){
        //     SpawnLevelPart();
        // }
    }
    

    void Update()
    {
        if(Vector3.Distance(player.transform.position,lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVLE_PART){
            SpawnLevelPart();
        }
        
    }
    private void SpawnLevelPart(){
        Transform chosenLevelPart = levelPartList[Random.Range(0,levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart,lastEndPosition);
        lastEndPosition =lastLevelPartTransform.Find("EndPoint").position;
          lastLevelPartTransform.parent = map.transform;
       

    }
   private  Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart,spawnPosition,Quaternion.identity);
        return LevelPartTransform;
    }
}
