using UnityEngine;   //引用unity 引擎 引用的APUd

public class Car : MonoBehaviour
{
    #region 註解
    //單行註解: 添加說明、翻譯、紀錄等等.....會被程式忽略
    // KID 2021.07.17(禮拜六)開發汽車腳本

    /*  多行註解
     *  多行註解
     *  多行註解
     *  多行註解
     *  多行註解
     */

    //欄位 :儲存簡單的資料
    //語法 :
    //修飾詞 資料類型 欄位 指定符號 預設值 結尾
    //指定符號 =
    //修飾詞:
    //1. 私人 private  預設-不顯示
    //2. 公開 public       -顯示

    // Unity內建的四大常用類型
    //整數    int
    //浮點數  float
    //字串    string
    //布林值  bool

    //第17行的範例
    //定義欄位 
    // Unity 會以屬性 Inspector 面板為主
    #endregion
    #region 認識欄位與四大常用類型
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "BMW";
    public bool windowSKY = true;

    //欄位屬性:輔助欄位添加功能
    // 語法 : [屬性名稱("屬性值")
    // 標題 : [Header("字串")]
    [Header("輪胎數量")]
    public int wheelcount = 4;
    //提示:[Tooltip("字串")]
    [Tooltip("這個是設定汽車的高度")]
    public float height = 1.5f;
    //範圍:[Range(最小範圍,最大範圍)]-僅限數值類型int、float無法使用以外的類型
    [Range(2, 10)]
    public int doorcount = 4;
    #endregion
    #region 其他類型
    //定義一個RED紅色它的顏色會紅色  前面是顏色名稱 後面是指定的顏色
    // 資料類型 為這個類型命名=類型資料;
    public Color red = Color.red;
    public Color yellow = Color.yellow;
    /*指定新的顏色需要輸入顏色三號碼 但是範圍只有0到1 沒辦法輸入255
     * 以百分比計算 0.1F 就是原本的255/10=25.5 四捨五入變26
     * 如果想要在加透明度需要再加一個空格變成第四格
    */
    public Color colorcustom1 = new Color(0.5f, 0.1F, 1);
    public Color colorcustom2 = new Color(1, 1, 1, 0.5f);

    //座標 2-4維 vctor2 - 4

    //預設值是0
    public Vector2 v2;

    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;

    //內建上跟右加個負號就可以變成左跟上
    public Vector2 right = Vector2.right;
    public Vector2 left = -Vector2.right;

    public Vector2 up = Vector2.up;
    //客製化座標
    public Vector2 vectorcustom = new Vector2(-55.5f, 100);

    //三維座標
    public Vector3 v3;
    //四維座標
    public Vector4 v4;

    // 按鍵類型
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; //0是左鍵 1是右鍵 2是滾輪

    //遊戲物件與元件
    public GameObject goCamera; //遊戲元件包含場景上的以及傳案內的預置物
    //元件僅限於存放屬性面板上有此元件的物件
    public Transform traCar;
    public SpriteRenderer sprPicture;
    #endregion
    #region 事件
    //開始程式後僅執行一次，使用於遊戲初始化的設定
    //沒寫進方法裡面的是預設值 之後在start方法裡面按下播放後
    //會取得start裡面的資料
    private void Start()
    {
        
        //用來輸出任何資料類型,大部分用來除錯
        print("hello~world~:D");

        //練習取得欄位 Get
        print(brand);
        //練習設定欄位 Set
        windowSKY = false;
        cc = 3000;
        weight = 9.9f;
    }
    private void Update()
    {
        print("嗨 我在update中"); //這個方法裡面每秒執行60次
    }
    #endregion


}
