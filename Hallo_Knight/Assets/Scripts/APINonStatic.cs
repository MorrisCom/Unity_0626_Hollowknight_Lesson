using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API��������j����
    // 1. �R�A:   ������r Static
    // 2. �D�R�A: �L����r Static

    // �ϥΫD�R�A�ݩ� 1. ���w�q���R�A��쪺���O���
    // �ϥΫD�R�A�ݩ� 3. ��쥲���n��J�n������T���� �����ର�ŭ�
    public Transform traA;
    public Camera cam;
    public Transform traB;
    public Light ligtA;

    public Camera camA;
    public SpriteRenderer Spr;
    public Transform traC;
    public Rigidbody2D rig;



    //�ϥΫD�ʺA��k�n���w�q�@����� �M��A�]�w ���ۦA��C���̭���A�n�쪺�����i�h�ŭȸ̭�

    void Start()
    {
        // 1. ���o�D�R�A�ݩ�

        // �ϥΫD�R�A�ݩ� 2.
        // �� �y�k: ���.�D�R�A�ݩ�
        print("���o�y��:" + traA.position);
        print("���o��v�����I���C��" + cam.backgroundColor);


        // 2.�]�w�D�R�A�ݩ�
        // �C��H255�����Q�����U�h��  �Ҧp0.1�N�O25 0.5�N�O128 
        // �p�G�ݭn�A�W�[�z���צA�[�@�ӪŮ���쬰�ĥ|��
        // �p�Gı�o���w�C��ӳ·Хi�H�令color32 �N�i�H�ϥέ쥻��255�T���
        cam.backgroundColor = new Color32(255, 128, 149, 30);
        traA.localScale = new Vector3(2, 2, 2);

        // 3.�I�s�D�R�A��k
        //�@�� �y�k:���(�����޼�);
        traB.Translate(1, 0, 0);
        ligtA.Reset();

        #region  �D�R�A��k�m��
        print("��v���`��:" + cam.depth);
        print("�Ϥ�1���C��" + Spr.color);

        cam.backgroundColor = Random.ColorHSV();
        Spr.flipY = true;
        #endregion

    }

    private void Update()
    {
        traC.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(5,0));
    }
}
