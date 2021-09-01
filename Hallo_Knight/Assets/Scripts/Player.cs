using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")] [Range(0, 500)]
    public float speed = 300f;
    [Header("跳躍高度")] [Range(0, 5000)]
    public int jumpheight = 300;
    [Header("血量")] [Range(0, 200)]
    public float HP = 100;
    [Header("地板上")] [Tooltip("是否在地板上")]
    public bool isground = false;
    [Header("檢查地板區域:位移與半徑")]
    public Vector3 groundoffset;
    [Range(0, 2)]
    public float groundradius = 0.5f;
    [Header("重力"),Range(0.01F, 1)]
    public float gravity = 0.15f;
    /// <summary>
    /// 玩家水平輸入值
    /// </summary>
    private float hvalue;

    // 私人欄位不顯示
    // 開啟屬性面板裡面...下面的debug模式 可以看到私人的欄位
    AudioSource aud;
    Rigidbody2D Rig;
    Animator ani;
    SpriteRenderer spr;


    [Header("攻擊冷卻"), Range(0, 5)]
    public float CD = 2;

    /// <summary>
    /// 攻擊計時器
    /// </summary>
    private float timer;

    /// <summary>
    /// 是否攻擊
    /// </summary>
    private bool isattack;

    #endregion




    #region  方法

    #region 事件
    private void Start()
    {
        // Getcomponent<>() 泛行方法 、可以指定任何類型
        // 作用 :取得此物件的2D剛體元件
        Rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // 一秒鐘大約執行60次 不固定
    private void Update()
    {
        PlayerInputHorizontal();
        TurnDirection();
        Jump();
        Attack();
    }

    // 固定更新事件
    // 一秒鐘固定執行50次,官方建議物理API都放在這裡面執行
    private void FixedUpdate()
    {
        Move(hvalue);
    }

    #endregion

    /// <summary>
    /// 取得玩家輸入水平軸向值:A、D、左、右
    /// </summary>
    private void PlayerInputHorizontal()
    {
        // 水平值=輸入.取得軸向(軸向名稱)
        // 作用:取得玩家按下水平案鍵的值，案右為1，案左為-1,沒案為0
        hvalue = Input.GetAxis("Horizontal");
    }
    //給角色施加一個往下的力量來模仿重力,呈現往下掉的感覺
    

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">水平的移動數值</param>
    private void Move(float horizontal)
    {
        /**  第一種移動方法
        //區域變數:在方法內的欄位,有區域性,僅限此方法內有效
        //簡寫: transform 此物件的Transfrom 元件 
        //(只需要簡寫便可使用此物件 否則需要額外再寫一行 trasnform=XXX )
        // posMove : 角色當前座標 + 玩家輸入的水平值
        // 剛體.移動區域(要前往的座標)
        // Time.fixedDeltaTime 指 1/50秒  修正秒速讓速度降低 (沒有這行人物直接不見)
        //因為這行方法在Fixedupdate上執行一秒50次  沒有寫fixedDeltaTime會多執行50次
        // 剛剛取得的RIG元件.要移動的這個方法(到所要的方法座標)
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0)*speed * Time.fixedDeltaTime;
        Rig.MovePosition(posMove);
        **/
        /** 第二種移動方法 : 使用專案內的重力 - 較緩慢 */
        Rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, Rig.velocity.y);
        // 控制走路開關: horzontal 不等於 0 時 開啟走路動畫 等於0時取消
        ani.SetBool("走路開關", horizontal != 0);

    }

    private void TurnDirection()
    {
        // 如果玩家案D就將角度設為0
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }

        // 如果玩家案A就將角度設為0,180,0
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // vector2 可以用三維座標帶入 會自動把Z軸忽略
        // << 位移運算子
        // 指定圖層語法: 1 << 圖層編號
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundoffset, groundradius, 1 << 6);

        // 如果 碰到物件存在 就代表在地面上 否則就不再地面上
        // 判斷式如果只有一個結束符號 ; 可以省略大括號 {}
        if (hit) isground = true;
        else isground = false;

        // 設定動畫參數 與 是否在地板上相反
        ani.SetBool("跳躍開關", !isground);
       

        // 如果 玩家按下空白鍵 角色就往上跳
        if (isground && Input.GetKeyDown(KeyCode.Space)) 
        {
            Rig.AddForce (new Vector2(0,jumpheight));
        }
    }


    

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        // 如果 不是攻擊中 並且  按下左鍵 才可以攻擊 啟動觸發參數
        if (!isattack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isattack = true;
            ani.SetTrigger("攻擊觸發");
            

        }

        // 如果按下左鍵就開始累加計時器
        if (isattack)
        {
            if (timer<CD)
            {
                timer += Time.deltaTime;
                print("攻擊後累加時間:" + timer);
            }
            else
            {
                timer = 0;
                isattack = false;
                
            }
        }
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    public void Hurt(float damage)  
    //因為受傷時的數值是跟血量一起運算的,所以參數一起寫成浮點數比較方便之後的運算
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Death()
    {

    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="propName">道具名稱</param>
    private void Eatprop(string propName)
    {

    }

   
    // 繪製圖示事件 : 輔助開發者用,僅會顯示在編輯器 Unity內
    // 僅僅是一個圖示 但是能方便我們認出他在哪裡
    private void OnDrawGizmos()
    {
        //先決定顏色在繪製圖示
        Gizmos.color = new Color(1, 0, 0, 0.3f);   //半透明紅色
        Gizmos.DrawSphere(transform.position+groundoffset, groundradius);  //繪製球體(中心點,半徑)
        
    }

    #endregion
}

