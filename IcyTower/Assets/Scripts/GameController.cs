using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    PlayerMovement playerControl;
    public GameObject player;
    public GameObject Bosslevel;
    public GameObject baseLevel;
    public GameObject Boss;
    public GameObject Maps;
    Boss boss;
    private Vector3 scaleChange;

    public GameObject FailPnl;
    public GameObject MainMenu;
    void Start()
    {
        playerControl=player.GetComponent<PlayerMovement>();
        boss = Boss.GetComponent<Boss>();
        scaleChange = new Vector3(0.1f, 0,0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerControl.score%50 == 0 && playerControl.score != 0)
        {
             baseLevel.SetActive(false);
            Bosslevel.SetActive(true);
           Maps.SetActive(false);
           
        }
        if (Bosslevel.activeSelf)
        {
           if (boss.hp.transform.localScale.x < scaleChange.x)
           {
            baseLevel.SetActive(true); 
            Maps.SetActive(true);
            boss.hp.transform.localScale = new Vector3(1f,0.2f,1f);
            Bosslevel.SetActive(false);
           playerControl.score +=10;
           } 
        }
       
        
    }
      public void Restart(){
        SceneManager.LoadScene(0);
        FailPnl.SetActive(false);
    }
    public void StartGame(){
        MainMenu.SetActive(false);
    }
}
