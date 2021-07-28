using UnityEngine;

/// <summary>
/// 認識API第一種用法: Static 靜態
/// </summary>
public class APIStatic : MonoBehaviour
{
    // API文件分成兩大類型
    // 1. 靜態:   有關鍵字 Static
    // 2. 非靜態: 無關鍵字 Static

    // 1.屬性  可以想成欄位
    // 2.方法 

    float number = 9.999f;
    Vector3 a = new Vector3(1, 1, 1);
    Vector3 b = new Vector3(22, 22, 22);

    private void Start()
    {
        // 靜態屬性
        // 1. 取得
        // ※ 語法 : 類別.靜態屬性
        print("隨機值:" + Random.value);  //預設為0到1
        print("無限大:" + Mathf.Infinity);
        print("終極密碼1到100:" + Random.Range(1, 100));

        // 2. 設定 
        // 語法:類別.靜態屬性 指定 值;
        Cursor.visible = false;

        // Random.value = 7.7f; //-唯獨屬性無法修改 READ Only
        Screen.fullScreen = true;

        // 3.呼叫
        // 語法: 類別.靜態方法(對應引數);
        float r = Random.Range(6.6f, 8.9f);
        print("隨機值6.6-8.9:" + r);

        #region  練習靜態屬性、方法
        // 靜態屬性取得
        print("攝影機數量:"+ Camera.allCamerasCount);
        print("2D重力:" + Physics2D.gravity);
        print("數學圓周率:" + Mathf.PI);

        // 靜態屬性設定
        Physics2D.gravity = new Vector2(0,-20);
        print("設定後的重力大小:"+Physics2D.gravity);
        float timepass=  Time.timeScale =0.5f;
        print("時間調整的速度:"+timepass);

        // 呼叫靜態方法
        
        number=Mathf.Floor(number);
        print("去掉小數點後的整數:" + number);

        print("a到b的距離:" + Vector3.Distance(a, b));
        

        //Application.OpenURL(" https://unity.com/");
        #endregion
    }

    public float hp = 60;
    private void Update()
    {
        // 將想要的值鎖定在一個範圍,常使用於遊戲的血量與魔力,非常好用!
         hp=Mathf.Clamp(hp, 0, 200);    //(值,最小,最大值)
        print("HP血量:" + hp);

        #region  練習靜態屬性、方法

        print("是否輸入任何鍵:" + Input.anyKey);
        //print("遊戲經過時間:" + Time.time);
        bool space = Input.GetKeyDown(KeyCode.Space);
        print("有沒有按下空白鍵:" + space);
        #endregion
    }
}