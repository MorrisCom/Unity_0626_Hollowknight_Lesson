using UnityEngine;

//�{�ѹB��l
//1.�ƾǹB��l
public class LearnOpeator : MonoBehaviour
{
    
    int a = 10;
    int b = 3;
    int c = 7;
    public int hp = 100;

    public float scoreA = 99;
    public float scoreB = 1;

    public int health = 50;
    public int key = 1;
    public int chess = 5;
    public int diamond = 0;

    void Start()
    {
        #region �ƾǹB��l
        print(a + b); //13
       print(a - b); //7
       print(a * b); //30 
       print(a / b); //3
       print(a % b); //1

        c = c + 1; // = ���w�Ÿ� :�k����B�⧹�A������
        c++;       //�W���o�@�檺²�g  ��̬O�@�˪��⦡
        //print("c�B�⧹�᪺���G:" + c);
        //--c;
        //--c;
        //--c;
        //print("c�B�⧹�᪺���G:" + c);

        //���w�B�� - �A�Υ[����l
        //�Ҥl ����-13
        
        hp = hp - 13;  //87
        hp -= 13;      //74

        //�Ҥl �ɦ�+20
        hp += 20;      //94
        hp /= 2;       //47
        #endregion

        #region ����B��l
        // > < >= <= == !=
        //�ϥΤ���B��l�����G ���O���L��
        // ������T���G��true �_�h��false
        print("99����1=" + (scoreA == scoreB));
        print("99������1=" + (scoreA !=scoreB));
        #endregion

        #region �޿�B��l
        print("�޿�B��l");
        // ����ⵧ���L�Ȫ����
        print("�åB");
        // �åB &&
        // �u�n���@�ӥ��L��false ���G�K�|�ܦ�false
        print(true && true);       //ture
        print(true && false);      //false             
        print(false && true);      //false 
        print(false && false);     //false

        print("�Ϊ�");
        //�Ϊ� ||
        // �u�n���@�ӥ��L��true ���G�K�|�ܦ�true
        print(true || true);        //true
        print(true || false);       //true
        print(false || true);       //true
        print(false || false);      //false

        //�L������= ��q�j��0 �ӥB�_�ͭn�j��1
        print("�O�_���L��:" + (health > 0 && key == 1));
        //�L������= �c�l�W�L���� �Ϊ̮����ӥH�W���p��
        print("�O�_���L��:" + (chess >= 5 || diamond >= 2));

        //�ۤ�!
        print(!true);
        print(!false);

        #endregion
    }

}
