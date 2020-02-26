@time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    int time_int = 3;

    public Text time_UI;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("timer", 1, 1);
        Invoke("disappear", (float)3.2);
        //一秒後，每秒重複呼叫timer函式。(開始倒數計時)。
        //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。

    }

    void disappear ()
    {
        this.gameObject.SetActive(false);
    }

 

    void timer ()
    {
        time_int -= 1;
        time_UI.text = time_int + "";
        if (time_int == 0)
        {
            time_UI.text = "Go";
            CancelInvoke("timer");        }
    }

}