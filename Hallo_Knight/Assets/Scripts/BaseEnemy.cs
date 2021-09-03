using UnityEngine;

/// <summary>
///  �ĤH�����O
///  �\�� : �H�����ʡB���ݡB�l�ܪ��a�B���˻P���`
///  ���A�� : �C�| enum �P�_�� switch  (��¦�y�k)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region  ���
    [Header("�򥻯�O"), Range(50, 5000)]
    public float HP=50;
    [Tooltip("�����O"), Range(50, 1000)]
    public float Attack=100;
    [Tooltip("�t��"), Range(0, 500)]
    public float speed = 150f;
    /// <summary>
    /// �H�����ݪ��ɶ�
    /// </summary>
    public Vector2 v2randomIdle = new Vector2(1, 5);
    /// <summary>
    /// �H���������ɶ�
    /// </summary>
    public Vector2 v2randomWalk = new Vector2(3, 6);

    #endregion

    //�N�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    private EnemyState state;

    #region �p�H
    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;

    /// <summary>
    /// ���ݮɶ� : �H��
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// ���ݭp�ɾ�
    /// </summary>
    private float timerIdle;
    /// <summary>
    /// �����ɶ� :�H��
    /// </summary>
    private float timewalk;
    /// <summary>
    /// �����p�ɾ�
    /// </summary>
    private float timerwalk;

    #endregion

    #region  �ƥ�

    private void Start()
    {

        #region  ���o����
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        #endregion

        #region �]�w��l��
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

    #region  ��k
    /// <summary>
    /// �ˬd���A
    /// </summary>
    private void Checkstate()
    {
        switch (state)
        // switch�̭����ȬO�e���s�����
        //�ѼƸ̭���J�s�����C�|�᪽������Uenter�N�i�H�������A��s�񪺦C�|�����g�X��(���৹�����\��)
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
            // �o�̹w�]�p�G���ݭn�i�H�����R��
            default:  
                break;
        }

        
    }
    /// <summary>
    /// ����  �H����ƫ�i�J�쨫���Ҧ�
    /// �P�w������ܨ����Ҧ�
    /// </summary>
    private void Idle()
    {
        if (timerIdle<timeIdle)                                       // �p�G �p�ɾ� <���ݪ��ɶ�
        {
            timerIdle += Time.deltaTime;                              // �p�ɾ��֥[
            ani.SetBool("�����}��", false);
        }
        else                                                           // �_�h
        {
            state = EnemyState.walk;                                   //�������A
            timewalk = Random.Range(v2randomWalk.x, v2randomWalk.y);    
            timerIdle = 0;                                             //�p�ɾ��k�s
        }
    }

    /// <summary>
    /// �H������
    /// </summary>
    private void Walk()
    {
        if (timerwalk<timewalk)
        {
            timerwalk += Time.deltaTime;
            ani.SetBool("�����}��", true);

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
    /// �N���z�欰��W�B�z�æb Fixedupdate �I�s
    /// </summary>
    private void Walkinfixedupdate()
    {
        // �p�G �ثe���A �O���� �N ����.�[�t�� = �k�� * �t�� * 1/50 + �W�� * �a�ߤޤO
        if (state == EnemyState.walk) rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;
    }
    /// <summary>
    /// �H����V : ���V�k��Υ���
    /// �Ȭ�1�� , ����: 0, 180, 0
    /// �Ȭ�0�� , �k��: 0,0 ,0
    /// </summary>
    private void RandomDirection()
    {
        //�H���d��(�̤j�D�̤p)�о�Ʈɤ��]�t�̤j��(0�D��)���H�����o0��1
        int random = Random.Range(0, 2);

        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    #endregion 
}

//�w�q�C�|
// 1.�ϥ�����r enum �w�q�C�|�H�Υ]�t���ﶵ,�i�H�A�C�O�~�w�q
// 2.�ݭn���@�����w�q�����C�|����
// �y�k : �׹��� enum �C�|�W�� {�ﶵ1,�ﶵ2,....,�ﶵN}
public enum EnemyState
{
    idle,walk,track,attack,dead
}
