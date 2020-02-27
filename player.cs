@player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("水平移動速度(不能為0)")]
        public float speedX;
        Rigidbody2D playerRigidbody2D;
        Rigidbody2D body;

    void Start()  {
        playerRigidbody2D = GetComponent<Rigidbody2D> ( );
        Invoke("playerStart", 3);
        Invoke("delay", 3); //Invoke(method,time(sec))
    }

    void delay ()
    {
        transform.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionX;
    }
 
    void Update()
    {
        moveLeftOrRight();   //偵測玩家按鍵 (向左/右)
    }
 

 
    

    float LeftOrRight ()
    {
        return Input.GetAxis("Horizontal"); // 玩家輸入水平按鍵 向左按到底 回傳-1 向右反之(+1)    
    }
    void moveLeftOrRight ()
    {
        playerRigidbody2D.velocity = LeftOrRight() * new Vector2(speedX, 0);//玩家的方向 乘以 速度(水平速度才有效)
    }
    
}