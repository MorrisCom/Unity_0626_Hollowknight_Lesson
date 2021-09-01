using UnityEngine;

/// <summary>
/// 攝影機追蹤目標
/// </summary>
public class CameraControl : MonoBehaviour
{
    #region 欄位
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 10;
    [Header("要追蹤的物件名稱")]
    public string nametraget;
    [Header("左右限制")]
    public Vector2 limithorizontal;

    /// <summary>
    /// 要追蹤的目標
    /// </summary>
    private Transform target;
    private GameObject spr;

    #endregion

    #region 事件

    private void Start()
    {
        target = GameObject.Find(nametraget).transform;
    }

    //較慢更新:在update之後執行 (update執行1禎 lateupdate會執行慢一禎) 建議用於攝影機
    private void LateUpdate()
    {
        track();
    }
    #endregion


    #region 方法

    private void track()
    {
        Vector3 poscamera = transform.position; // A點 :攝影機座標
        Vector3 postarget = target.position;    // B點 :目標物座標
        //攝影機的結果座標=取得A點攝影機與B點目標物的座標
        Vector3 posResult = Vector3.Lerp(poscamera, postarget, 0.5f);
        //攝影機Z軸放回預設 -10 避免看不到目標物
        posResult.z = -10;

        //使用夾住api 限制攝影機 的左右範圍
        posResult.x = Mathf.Clamp(posResult.x, limithorizontal.x, limithorizontal.y);

        // 此物件的座標 指定為 運算後的座標
        transform.position = posResult;

    }
    #endregion

}
