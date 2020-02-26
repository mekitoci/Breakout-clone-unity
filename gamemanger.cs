@gamemanger

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("可打破的磚塊初始數量")]
    public static int brickCount;

    static GameObject nextLevelBotton;

    public static void ReloadThisScene ()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
    public static bool LevelClear
    {
        get {
            if (brickCount <= 0)
            {
                return true;
            }
            return false;
        }
    }
    public static void checkLevelClearOrNot ()
    {
        if (LevelClear)
        {
            showNextLevelButton();
        }
    }

    public void GotoScene (string next)
    {
        SceneManager.LoadScene(next);
    }
    void Start()
    {
        nextLevelBotton = GameObject.FindGameObjectWithTag(tags.下一關按鈕.ToString());
        nextLevelBotton.SetActive(false);

        brickCount = GameObject.FindGameObjectsWithTag(tags.磚塊.ToString()).Length;
        Debug.Log("一開始有 " + brickCount + "個可打破的磚塊");
    }

    static void showNextLevelButton ()
    {
        nextLevelBotton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


enum tags
{
    磚塊,
    背景,
    球拍,
    球,
    下一關按鈕
}