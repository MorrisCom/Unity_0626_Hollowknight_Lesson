using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")][Range(0,1000)]
    public float speed = 10.5f;
    [Header("跳躍高度")] [Range(0, 3000)]
    public int jumpheight = 100;
    [Header("血量")] [Range(0, 200)]
    public float HP = 100;
    [Header("地板上")][Tooltip("是否在地板上")]
    public bool isground=false;

    AudioSource aud;
    Rigidbody2D Rig;
    Animator ani;
    #endregion

    #region 事件
    #endregion

    #region  方法
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">水平的移動數值</param>
    private void Move(float horizontal)
    {

    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

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
    
    
    #endregion
}

