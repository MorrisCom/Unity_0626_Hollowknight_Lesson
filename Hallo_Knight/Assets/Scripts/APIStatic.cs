using UnityEngine;

/// <summary>
/// �{��API�Ĥ@�إΪk: Static �R�A
/// </summary>
public class APIStatic : MonoBehaviour
{
    // API��������j����
    // 1. �R�A:   ������r Static
    // 2. �D�R�A: �L����r Static

    // 1.�ݩ�  �i�H�Q�����
    // 2.��k 

    float number = 9.999f;
    Vector3 a = new Vector3(1, 1, 1);
    Vector3 b = new Vector3(22, 22, 22);

    private void Start()
    {
        // �R�A�ݩ�
        // 1. ���o
        // �� �y�k : ���O.�R�A�ݩ�
        print("�H����:" + Random.value);  //�w�]��0��1
        print("�L���j:" + Mathf.Infinity);
        print("�׷��K�X1��100:" + Random.Range(1, 100));

        // 2. �]�w 
        // �y�k:���O.�R�A�ݩ� ���w ��;
        Cursor.visible = false;

        // Random.value = 7.7f; //-�߿W�ݩʵL�k�ק� READ Only
        Screen.fullScreen = true;

        // 3.�I�s
        // �y�k: ���O.�R�A��k(�����޼�);
        float r = Random.Range(6.6f, 8.9f);
        print("�H����6.6-8.9:" + r);

        #region  �m���R�A�ݩʡB��k
        // �R�A�ݩʨ��o
        print("��v���ƶq:"+ Camera.allCamerasCount);
        print("2D���O:" + Physics2D.gravity);
        print("�ƾǶ�P�v:" + Mathf.PI);

        // �R�A�ݩʳ]�w
        Physics2D.gravity = new Vector2(0,-20);
        print("�]�w�᪺���O�j�p:"+Physics2D.gravity);
        float timepass=  Time.timeScale =0.5f;
        print("�ɶ��վ㪺�t��:"+timepass);

        // �I�s�R�A��k
        
        number=Mathf.Floor(number);
        print("�h���p���I�᪺���:" + number);

        print("a��b���Z��:" + Vector3.Distance(a, b));
        

        //Application.OpenURL(" https://unity.com/");
        #endregion
    }

    public float hp = 60;
    private void Update()
    {
        // �N�Q�n������w�b�@�ӽd��,�`�ϥΩ�C������q�P�]�O,�D�`�n��!
         hp=Mathf.Clamp(hp, 0, 200);    //(��,�̤p,�̤j��)
        print("HP��q:" + hp);

        #region  �m���R�A�ݩʡB��k

        print("�O�_��J������:" + Input.anyKey);
        //print("�C���g�L�ɶ�:" + Time.time);
        bool space = Input.GetKeyDown(KeyCode.Space);
        print("���S�����U�ť���:" + space);
        #endregion
    }
}