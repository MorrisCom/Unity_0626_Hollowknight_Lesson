using UnityEngine;
using UnityEngine.SceneManagement; // �ޥ� �����޲z API
public class SceneController : MonoBehaviour
{
    // Unity �L�k���W�}������j��]
    // 1.�}����������L�C,����@��
    // 2.���O�P�ɮצW�٤��P
    // ���s On Click �]�w�I���ƥ󬰦�����H�έn�I�s����k

    // Unity ���s�p��P�}�����q
    // 1. ���}����k
    // 2. �ݭn���骫�󱾦��}��

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        //������A���J����
        //����I�s(��k�W��,���)    ��k�����n�Φr��覡��J
        //�@��:���ݫ��w�ɶ���A�I�s����k
        Invoke("DelayLoadGameScene", 2);
    }
    // ���ݤ@�q�ɶ���A�����k
    // Invoke ����I�s
    /// <summary>
    /// ������J����
    /// </summary>
    private void DelayLoadGameScene()
    {
        // �����޲z. ���J����("�����W��");   �o�O���J���w������
        SceneManager.LoadScene("�C������");
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame",2);
    }

    /// <summary>
    /// �������}�C��
    /// </summary>
    private void DelayQuitGame()
    {
        Application.Quit();   // ���ε{��.���}(); - ���}�C��
        print("���}�C��");     // Quit �b�s�边�����|����
    }



}
