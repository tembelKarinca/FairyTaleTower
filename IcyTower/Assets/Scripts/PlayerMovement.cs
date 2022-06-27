using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb ;
    Vector3 velocity;
    public Animator animator;
    public TextMeshProUGUI playerScoreText;
    public Joystick joystick;
    public ProjectTileBeh ProjectilePrefab;
    public Transform LaunchOffset;
    public GameObject bossLevel;

    public GameObject scene;
    GameController sceneControl;
    
    public int score;

    float speedAmount = 4f ;
    float jumpAmount = 8f ;
    float horizontalMoveSpeed;
  
    void Start()
    {
         InvokeRepeating( "Fire",2.0f, 0.3f );
        rgb = GetComponent<Rigidbody2D>();
        score = 0;
        sceneControl = scene.GetComponent<GameController>();
    }

    void Update()
    {
        playerScoreText.text = "Score" + score.ToString();

         if (joystick.Horizontal > 0.2f)
        {
           
            horizontalMoveSpeed = 1;
        }
        else if (joystick.Horizontal <-0.2f)
        {
            horizontalMoveSpeed = -1;
        }
        else{
            horizontalMoveSpeed = 0;
        }

        velocity = new Vector3(horizontalMoveSpeed, 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
       


        if (joystick.Vertical >0.5f && !animator.GetBool("isJumping") )
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("isJumping",true);
        }
        
        if (horizontalMoveSpeed == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (horizontalMoveSpeed == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }



     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping",false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
          if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping",true);
        }
    }
    void Fire(){
        if(bossLevel.activeSelf){
                Instantiate(ProjectilePrefab,LaunchOffset.position,transform.rotation);
        }
        
            
        
    }
  
}
