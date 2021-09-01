using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��")] [Range(0, 500)]
    public float speed = 300f;
    [Header("���D����")] [Range(0, 5000)]
    public int jumpheight = 300;
    [Header("��q")] [Range(0, 200)]
    public float HP = 100;
    [Header("�a�O�W")] [Tooltip("�O�_�b�a�O�W")]
    public bool isground = false;
    [Header("�ˬd�a�O�ϰ�:�첾�P�b�|")]
    public Vector3 groundoffset;
    [Range(0, 2)]
    public float groundradius = 0.5f;
    [Header("���O"),Range(0.01F, 1)]
    public float gravity = 0.15f;
    /// <summary>
    /// ���a������J��
    /// </summary>
    private float hvalue;

    // �p�H��줣���
    // �}���ݩʭ��O�̭�...�U����debug�Ҧ� �i�H�ݨ�p�H�����
    AudioSource aud;
    Rigidbody2D Rig;
    Animator ani;
    SpriteRenderer spr;


    [Header("�����N�o"), Range(0, 5)]
    public float CD = 2;

    /// <summary>
    /// �����p�ɾ�
    /// </summary>
    private float timer;

    /// <summary>
    /// �O�_����
    /// </summary>
    private bool isattack;

    #endregion




    #region  ��k

    #region �ƥ�
    private void Start()
    {
        // Getcomponent<>() �x���k �B�i�H���w��������
        // �@�� :���o������2D���餸��
        Rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // �@�����j������60�� ���T�w
    private void Update()
    {
        PlayerInputHorizontal();
        TurnDirection();
        Jump();
        Attack();
    }

    // �T�w��s�ƥ�
    // �@�����T�w����50��,�x���ĳ���zAPI����b�o�̭�����
    private void FixedUpdate()
    {
        Move(hvalue);
    }

    #endregion

    /// <summary>
    /// ���o���a��J�����b�V��:A�BD�B���B�k
    /// </summary>
    private void PlayerInputHorizontal()
    {
        // ������=��J.���o�b�V(�b�V�W��)
        // �@��:���o���a���U�������䪺�ȡA�ץk��1�A�ץ���-1,�S�׬�0
        hvalue = Input.GetAxis("Horizontal");
    }
    //������I�[�@�ө��U���O�q�Ӽҥ魫�O,�e�{���U�����Pı
    

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���������ʼƭ�</param>
    private void Move(float horizontal)
    {
        /**  �Ĥ@�ز��ʤ�k
        //�ϰ��ܼ�:�b��k�������,���ϰ��,�ȭ�����k������
        //²�g: transform ������Transfrom ���� 
        //(�u�ݭn²�g�K�i�ϥΦ����� �_�h�ݭn�B�~�A�g�@�� trasnform=XXX )
        // posMove : �����e�y�� + ���a��J��������
        // ����.���ʰϰ�(�n�e�����y��)
        // Time.fixedDeltaTime �� 1/50��  �ץ���t���t�׭��C (�S���o��H����������)
        //�]���o���k�bFixedupdate�W����@��50��  �S���gfixedDeltaTime�|�h����50��
        // �����o��RIG����.�n���ʪ��o�Ӥ�k(��ҭn����k�y��)
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0)*speed * Time.fixedDeltaTime;
        Rig.MovePosition(posMove);
        **/
        /** �ĤG�ز��ʤ�k : �ϥαM�פ������O - ���w�C */
        Rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, Rig.velocity.y);
        // ������}��: horzontal ������ 0 �� �}�Ҩ����ʵe ����0�ɨ���
        ani.SetBool("�����}��", horizontal != 0);

    }

    private void TurnDirection()
    {
        // �p�G���a��D�N�N���׳]��0
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }

        // �p�G���a��A�N�N���׳]��0,180,0
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        // vector2 �i�H�ΤT���y�бa�J �|�۰ʧ�Z�b����
        // << �첾�B��l
        // ���w�ϼh�y�k: 1 << �ϼh�s��
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundoffset, groundradius, 1 << 6);

        // �p�G �I�쪫��s�b �N�N��b�a���W �_�h�N���A�a���W
        // �P�_���p�G�u���@�ӵ����Ÿ� ; �i�H�ٲ��j�A�� {}
        if (hit) isground = true;
        else isground = false;

        // �]�w�ʵe�Ѽ� �P �O�_�b�a�O�W�ۤ�
        ani.SetBool("���D�}��", !isground);
       

        // �p�G ���a���U�ť��� ����N���W��
        if (isground && Input.GetKeyDown(KeyCode.Space)) 
        {
            Rig.AddForce (new Vector2(0,jumpheight));
        }
    }


    

    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {
        // �p�G ���O������ �åB  ���U���� �~�i�H���� �Ұ�Ĳ�o�Ѽ�
        if (!isattack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isattack = true;
            ani.SetTrigger("����Ĳ�o");
            

        }

        // �p�G���U����N�}�l�֥[�p�ɾ�
        if (isattack)
        {
            if (timer<CD)
            {
                timer += Time.deltaTime;
                print("������֥[�ɶ�:" + timer);
            }
            else
            {
                timer = 0;
                isattack = false;
                
            }
        }
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

   
    // ø�s�ϥܨƥ� : ���U�}�o�̥�,�ȷ|��ܦb�s�边 Unity��
    // �ȶȬO�@�ӹϥ� ���O���K�ڭ̻{�X�L�b����
    private void OnDrawGizmos()
    {
        //���M�w�C��bø�s�ϥ�
        Gizmos.color = new Color(1, 0, 0, 0.3f);   //�b�z������
        Gizmos.DrawSphere(transform.position+groundoffset, groundradius);  //ø�s�y��(�����I,�b�|)
        
    }

    #endregion
}

