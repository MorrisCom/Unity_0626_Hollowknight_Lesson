using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���
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
    #endregion

    #region �ƥ�
    #endregion

    #region  ��k
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���������ʼƭ�</param>
    private void Move(float horizontal)
    {

    }

    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�y�����ˮ`</param>
    public void Hurt(float damage)  
    //�]�����ˮɪ��ƭȬO���q�@�_�B�⪺,�ҥH�ѼƤ@�_�g���B�I�Ƥ����K���᪺�B��
    {

    }
    /// <summary>
    /// ���`
    /// </summary>
    private void Death()
    {

    }

    /// <summary>
    /// �Y�D��
    /// </summary>
    /// <param name="propName">�D��W��</param>
    private void Eatprop(string propName)
    {

    }
    
    
    #endregion
}

