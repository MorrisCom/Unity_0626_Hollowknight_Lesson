using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API文件分成兩大類型
    // 1. 靜態:   有關鍵字 Static
    // 2. 非靜態: 無關鍵字 Static

    // 使用非靜態屬性 1. 先定義此靜態欄位的類別欄位
    // 使用非靜態屬性 3. 欄位必須要放入要取的資訊物件 ※不能為空值
    public Transform traA;
    public Camera cam;
    public Transform traB;
    public Light ligtA;

    public Camera camA;
    public SpriteRenderer Spr;
    public Transform traC;
    public Rigidbody2D rig;



    //使用非動態方法要先定義一個欄位 然後再設定 接著再到遊戲裡面把你要抓的物件放進去空值裡面

    void Start()
    {
        // 1. 取得非靜態屬性

        // 使用非靜態屬性 2.
        // ※ 語法: 欄位.非靜態屬性
        print("取得座標:" + traA.position);
        print("取得攝影機的背景顏色" + cam.backgroundColor);


        // 2.設定非靜態屬性
        // 顏色以255分為十等分下去除  例如0.1就是25 0.5就是128 
        // 如果需要再增加透明度再加一個空格欄位為第四格
        // 如果覺得指定顏色太麻煩可以改成color32 就可以使用原本的255三原色
        cam.backgroundColor = new Color32(255, 128, 149, 30);
        traA.localScale = new Vector3(2, 2, 2);

        // 3.呼叫非靜態方法
        //　※ 語法:欄位(對應引數);
        traB.Translate(1, 0, 0);
        ligtA.Reset();

        #region  非靜態方法練習
        print("攝影機深度:" + cam.depth);
        print("圖片1的顏色" + Spr.color);

        cam.backgroundColor = Random.ColorHSV();
        Spr.flipY = true;
        #endregion

    }

    private void Update()
    {
        traC.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(5,0));
    }
}
