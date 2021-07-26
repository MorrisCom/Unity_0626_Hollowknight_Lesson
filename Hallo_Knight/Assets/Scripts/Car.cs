using UnityEngine;   //�ޥ�unity ���� �ޥΪ�APUd

public class Car : MonoBehaviour
{
    #region ����
    //������: �K�[�����B½Ķ�B��������.....�|�Q�{������
    // KID 2021.07.17(§����)�}�o�T���}��

    /*  �h�����
     *  �h�����
     *  �h�����
     *  �h�����
     *  �h�����
     */

    //��� :�x�s²�檺���
    //�y�k :
    //�׹��� ������� ��� ���w�Ÿ� �w�]�� ����
    //���w�Ÿ� =
    //�׹���:
    //1. �p�H private  �w�]-�����
    //2. ���} public       -���

    // Unity���ت��|�j�`������
    //���    int
    //�B�I��  float
    //�r��    string
    //���L��  bool

    //��17�檺�d��
    //�w�q��� 
    // Unity �|�H�ݩ� Inspector ���O���D
    #endregion

    #region �{�����P�|�j�`������
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "BMW";
    public bool windowSKY = true;

    //����ݩ�:���U���K�[�\��
    // �y�k : [�ݩʦW��("�ݩʭ�")
    // ���D : [Header("�r��")]
    [Header("���L�ƶq")]
    public int wheelcount = 4;
    //����:[Tooltip("�r��")]
    [Tooltip("�o�ӬO�]�w�T��������")]
    public float height = 1.5f;
    //�d��:[Range(�̤p�d��,�̤j�d��)]-�ȭ��ƭ�����int�Bfloat�L�k�ϥΥH�~������
    [Range(2, 10)]
    public int doorcount = 4;
    #endregion

    #region ��L����
    //�w�q�@��RED���⥦���C��|����  �e���O�C��W�� �᭱�O���w���C��
    // ������� ���o�������R�W=�������;
    public Color red = Color.red;
    public Color yellow = Color.yellow;
    /*���w�s���C��ݭn��J�C��T���X ���O�d��u��0��1 �S��k��J255
     * �H�ʤ���p�� 0.1F �N�O�쥻��255/10=25.5 �|�ˤ��J��26
     * �p�G�Q�n�b�[�z���׻ݭn�A�[�@�ӪŮ��ܦ��ĥ|��
    */
    public Color colorcustom1 = new Color(0.5f, 0.1F, 1);
    public Color colorcustom2 = new Color(1, 1, 1, 0.5f);

    //�y�� 2-4�� vctor2 - 4

    //�w�]�ȬO0
    public Vector2 v2;

    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;

    //���ؤW��k�[�ӭt���N�i�H�ܦ�����W
    public Vector2 right = Vector2.right;
    public Vector2 left = -Vector2.right;

    public Vector2 up = Vector2.up;
    //�Ȼs�Ʈy��
    public Vector2 vectorcustom = new Vector2(-55.5f, 100);

    //�T���y��
    public Vector3 v3;
    //�|���y��
    public Vector4 v4;

    // ��������
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; //0�O���� 1�O�k�� 2�O�u��

    //�C������P����
    public GameObject goCamera; //�C������]�t�����W���H�ζǮפ����w�m��
    //����ȭ���s���ݩʭ��O�W�������󪺪���
    public Transform traCar;
    public SpriteRenderer sprPicture;
    #endregion

    #region �ƥ�
    //�}�l�{����Ȱ���@���A�ϥΩ�C����l�ƪ��]�w
    //�S�g�i��k�̭����O�w�]�� ����bstart��k�̭����U�����
    //�|���ostart�̭������
    private void Start()
    {
        #region �m�����
        //�Ψӿ�X����������,�j�����ΨӰ���
        print("hello~world~:D");

        //�m�ߨ��o��� Get
        print(brand);
        //�m�߳]�w��� Set
        windowSKY = false;
        cc = 3000;
        weight = 9.9f;
        #endregion
        //�I�s��k�y�k: ��k�W��();
        Drive50();
        Drive100();
        Drive(139,"bangbangbang");         //�I�s�ɤp�A�������٬��޼�
        Drive(219, "������");              //�p�A���̭��ݭn��J�۹������޼�
        Drive(249);                       //�ѼƦ��F�w�]�ȥi�H���ε��޼� �L�|���H�w�]�Ȱ���
        Drive(300, effect: "�ǹ�");        // �ϥΦh�ӹw�]�ȰѼƮɥi�H�ϥ� �ѼƦW�� : ��  
        // �b�Q�n���L�������Ѽƥu���S�w�X�ӰѼƮɥi�ϥ� ���M�|���Ӷ��Ǫ����U�h

    }
    private void Update()
    {
        print("�� �ڦbupdate��"); //�o�Ӥ�k�̭��C�����60��
    }
    #endregion

    #region ��k (�\��B�禡)  Method
    //��k:��@���������欰:�T�����e�}�B�}�ҨT�������T�ü��񭵼�....
    // ���:�׹��� ���� �W�� ���w �w�]��;
    // ��k:�׹��� �Ǧ^���� �W�� (�Ѽ�) {�{���X�϶�}
    // ����: void - �L�Ǧ^
    // �w�q��k : ���|���楲���I�s�A�I�s����k�A�b�ƥ󤺩I�s����k
    // ���@�ʡB�X�R��

    private void Drive50 ()
    {
        print("�}����-�ɼ�:50");
    }
    private void Drive100()
    {
        print("�}����-�ɼ�:100");
    }

    //�Ѽƻy�k:�����W��  �u��g�b�p�A���̭��ϥ� �åB�u��b����k�ϥ�
    //�Ѽ�1,�Ѽ�2,�Ѽ�3,�Ѽ�4.....�Ѽ�N
    //(�z�פW�i�H�[�L���h���ѼơA���Ҽ{��ʯ�̦h�[��10�ӴN�n�A�ѼƤ����γr���Ϲj)
    //�Ѽƹw�]�� :���� �ѼƦW�� ���w �� (��񦡰Ѽ�)
    // �w�]�ȥu���b�̥k��

    /// <summary>
    /// �o�O�}������k�A�i�H�Ψӱ���l���t�סB���ĻP�S�ġC 
    /// </summary>
    /// <param name="speed">���l�����ʳt��</param>
    /// <param name="sound">�}���ɪ�����</param>
    /// <param name="effect">�}���ɪ��S��</param>
    private void Drive(int speed,string sound="������",string effect="�H��")
    {
        print("�}����-�ɼ�:"+speed);
        print("�}������:" + sound);
        print("�}�S�S��:" + effect);

    }

    #endregion

}
