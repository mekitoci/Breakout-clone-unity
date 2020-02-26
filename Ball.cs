@Ball

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Text ScoreText;
     
    int score;

    Rigidbody2D ballRigidbody2D;

    CircleCollider2D ballCircleCollider2D;


    [Header("水平速度")]
    public float speedX;
    [Header("垂直速度")]
    public float speedY;

    [Header("實際水平速度")]
    public float velocityX;
    [Header("實際垂直速度")]
    public float velocityY;


    


    void Start()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        ballCircleCollider2D = GetComponent<CircleCollider2D>( );
        Invoke("ballStart", 3);
        ScoreText.text = "目前分數:"; 
    }

    // Update is called once per frame
    void Update()
    {
        velocityX = ballRigidbody2D.velocity.x;
        velocityY = ballRigidbody2D.velocity.y;

        if (Input.GetKey(KeyCode.Space))
        {
            ballStart(); 
        }
    }
    void ballStart ()
    {
        if (isStop())
        {
            ballCircleCollider2D.enabled = true;
            transform.SetParent(null);
            ballRigidbody2D.velocity = new Vector2(speedX, speedY);  //velocity 速度
        } 
          
    }

    bool isStop()
    {
        return ballRigidbody2D.velocity == Vector2.zero;
    }
    void OnCollisionEnter2D (Collision2D other) 
    {
        lockSpeed();
        if (other.gameObject.CompareTag("磚塊"))
        {
            GameManager.brickCount--;
            Debug.Log("目前磚塊數量：" + GameManager.brickCount);
            GameManager.checkLevelClearOrNot();
            other.gameObject.SetActive(false);
            score += 10;
            ScoreText.text = "目前分數：" + score;
     
        }
    }

    void lockSpeed() 
    {
        Vector2 lockSpeed = new Vector2(resetSpeedX( ), resetSpeedY());
        ballRigidbody2D.velocity = lockSpeed;
    }

    float resetSpeedX () //鎖定速度
    {
        float currentSpeedX = ballRigidbody2D.velocity.x;
        if ( currentSpeedX <0 )
        {
            return -speedX; // speedX是自己設定的
        }
        else
        {
            return speedX;
        }
    }

    float resetSpeedY()
    {
        float currentSpeedY = ballRigidbody2D.velocity.y;
        if (currentSpeedY < 0)
        {
            return -speedY; 
        }
        else
        {
            return speedY;
        }
    }
}