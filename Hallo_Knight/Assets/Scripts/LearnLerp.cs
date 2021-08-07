using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float a = 0, b = 10;
    public float result;

    public float c = 0, d = 100;

    public Vector2 v2a = Vector2.zero;
    public Vector2 v2b = Vector2.one * 100;
    private void Start()
    {
        //認識插值 Lerp:取得兩點間的值
        // 結果 = 數學.插值(A點,B點,百分比 0-1)
        result = Mathf.Lerp(a, b, 0.7f);

        

    }
    private void Update()
    {
        c = Mathf.Lerp(c, d, 0.5f * Time.deltaTime);
        v2a = Vector2.Lerp(v2a, v2b, 0.8f * Time.deltaTime);
    }
}
