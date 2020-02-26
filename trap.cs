@trap
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("被撞到時候的位移")]
    public Vector3 offset;

    public int life;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tags.球.ToString()))
        {
            life--;
            gameObject.transform.position += offset;
        }
        if (life <= 0 && !GameManager.LevelClear)
        {
            GameManager.ReloadThisScene();  
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}