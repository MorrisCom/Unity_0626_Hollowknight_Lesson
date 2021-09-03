using UnityEngine;

/// <summary>
///  敵人基底類別
///  功能 : 隨機走動、等待、追蹤玩家、受傷與死亡
///  狀態式 : 列舉 enum 判斷式 switch  (基礎語法)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region  欄位
    [Header("基本能力"), Range(50, 5000)]
    public float HP=50;
    [Tooltip("攻擊力"), Range(50, 1000)]
    public float Attack=100;
    [Tooltip("速度"), Range(0, 500)]
    public float speed = 150f;
    /// <summary>
    /// 隨機等待的時間
    /// </summary>
    public Vector2 v2randomIdle = new Vector2(1, 5);
    /// <summary>
    /// 隨機走路的時間
    /// </summary>
    public Vector2 v2randomWalk = new Vector2(3, 6);

    #endregion

    //將私人欄位顯示在屬性面板上
    [SerializeField]
    private EnemyState state;

    #region 私人
    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;

    /// <summary>
    /// 等待時間 : 隨機
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// 等待計時器
    /// </summary>
    private float timerIdle;
    /// <summary>
    /// 走路時間 :隨機
    /// </summary>
    private float timewalk;
    /// <summary>
    /// 走路計時器
    /// </summary>
    private float timerwalk;

    #endregion

    #region  事件

    private void Start()
    {

        #region  取得元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        #endregion

        #region 設定初始值
        timeIdle = Random.Range(v2randomIdle.x, v2randomIdle.y);
        #endregion
    }

    private void Update()
    {
        Checkstate();
    }

    private void FixedUpdate()
    {
        Walkinfixedupdate();
    }
    #endregion

    #region  方法
    /// <summary>
    /// 檢查狀態
    /// </summary>
    private void Checkstate()
    {
        switch (state)
        // switch裡面的值是前面存放的欄位
        //參數裡面輸入存放的欄位列舉後直接按兩下enter就可以直接幫你把存放的列舉直接寫出來(智能完成的功能)
        {
            case EnemyState.idle:
                Idle();
                break;
            case EnemyState.walk:
                Walk();
                break;
            case EnemyState.track:
                break;
            case EnemyState.attack:
                break;
            case EnemyState.dead:
                break;
            // 這裡預設如果不需要可以直接刪掉
            default:  
                break;
        }

        
    }
    /// <summary>
    /// 等待  隨機秒數後進入到走路模式
    /// 判定後切換至走路模式
    /// </summary>
    private void Idle()
    {
        if (timerIdle<timeIdle)                                       // 如果 計時器 <等待的時間
        {
            timerIdle += Time.deltaTime;                              // 計時器累加
            ani.SetBool("走路開關", false);
        }
        else                                                           // 否則
        {
            state = EnemyState.walk;                                   //切換狀態
            timewalk = Random.Range(v2randomWalk.x, v2randomWalk.y);    
            timerIdle = 0;                                             //計時器歸零
        }
    }

    /// <summary>
    /// 隨機走路
    /// </summary>
    private void Walk()
    {
        if (timerwalk<timewalk)
        {
            timerwalk += Time.deltaTime;
            ani.SetBool("走路開關", true);

        }
        else
        {
            rig.velocity = Vector2.zero;
            RandomDirection();
            state = EnemyState.idle;
            timeIdle = Random.Range(v2randomIdle.x, v2randomIdle.y);
            timerwalk = 0;
        }
    }

    /// <summary>
    /// 將物理行為單獨處理並在 Fixedupdate 呼叫
    /// </summary>
    private void Walkinfixedupdate()
    {
        // 如果 目前狀態 是移動 就 剛體.加速度 = 右邊 * 速度 * 1/50 + 上方 * 地心引力
        if (state == EnemyState.walk) rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;
    }
    /// <summary>
    /// 隨機方向 : 面向右邊或左邊
    /// 值為1時 , 左邊: 0, 180, 0
    /// 值為0時 , 右邊: 0,0 ,0
    /// </summary>
    private void RandomDirection()
    {
        //隨機範圍(最大．最小)－整數時不包含最大值(0．２)－隨機取得0或1
        int random = Random.Range(0, 2);

        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    #endregion 
}

//定義列舉
// 1.使用關鍵字 enum 定義列舉以及包含的選項,可以再列別外定義
// 2.需要有一個欄位定義為此列舉類型
// 語法 : 修飾詞 enum 列舉名稱 {選項1,選項2,....,選項N}
public enum EnemyState
{
    idle,walk,track,attack,dead
}
