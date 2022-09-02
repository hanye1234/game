using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{


    Animator animator;

    public bool isGrounded;
    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 7;
    float velocity=0;

    public float combo=1;

    public HeartController heartcontroller;
    public GameController gameController;
    

    //초기 값 설정
    void Awake() {
        animator=GetComponent<Animator>();
        animator.SetBool("isjump",false);
    }

    void Start()
    {
        isGrounded=true;
        jumpForce=20;
        gravity = -9.81f;
        gravityScale = 6;
        velocity=0;
        combo=1;
    }

    void Update()
    {

        ////////             점프 하는 코드              //////
        // y값 참조해서 0.8보다 작거나 같고, 아래로 떨어지고 있으면 땅에 있음을 true로 한다
        if(transform.position.y<=-0.8 && velocity<=0){
            isGrounded=true;
        }
        //아니면 false
        else
        {
            isGrounded=false;
        }

        // 속도에 중력가속도와 scale(임의)와 시간을 곱한 값을 더해서 점점 가속도가 붙게 한다
        velocity += gravity * gravityScale * Time.deltaTime;
        
        // 땅에 붙어 있고 속도가 0보다 작으면 점프 종료. 속도를 0으로
        if (isGrounded && velocity < 0)
        {   
            animator.SetBool("isjump",false);
            velocity = 0;
        }

        // 스페이스바 입력이 되었을 때 속도를 jumpForce로 한다
        if ((Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(0)) && !animator.GetBool("isjump"))
        {
            animator.SetBool("isjump",true);
            velocity = jumpForce;
        }

        // 속도*시간만큼 움직인다
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        ///////                 점프 끝             /////////


        if(combo<100){
            combo=combo+Time.deltaTime;
        }
        else{
            combo=100;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("obstacle"))
        {

            int currentHP=heartcontroller.HPminus();
            gameController.SetGameSpeed(1);
            combo=1;

            animator.SetBool("isCrash",true);
            other.gameObject.SetActive(false);
            
            if(currentHP==0)
            {
                gameController.Gameover();
            }
            

            Invoke("OffCrash",1.5f);
        }

        if(other.CompareTag("HPitem"))
        {
            heartcontroller.HPplus();
            other.gameObject.SetActive(false);
        }
        
    }

    void OffCrash()
    {
        gameController.ResetGameSpeed();
        animator.SetBool("isCrash",false);
    }

}
