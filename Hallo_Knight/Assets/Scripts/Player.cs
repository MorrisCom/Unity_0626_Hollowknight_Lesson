using UnityEngine;

public class Player : MonoBehaviour
{
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

    private void Start()
    {
       
    }
}

