using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("���ʳt��")][Range(0,1000)]
    public float speed = 10.5f;
    [Header("���D����")] [Range(0, 3000)]
    public int jumpheight = 100;
    [Header("��q")] [Range(0, 200)]
    public float HP = 100;
    [Header("�a�O�W")][Tooltip("�O�_�b�a�O�W")]
    public bool isground=false;

    AudioSource aud;
    Rigidbody2D Rig;
    Animator ani;

    private void Start()
    {
       
    }
}

