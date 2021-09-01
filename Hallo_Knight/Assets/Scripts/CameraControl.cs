using UnityEngine;

/// <summary>
/// ��v���l�ܥؼ�
/// </summary>
public class CameraControl : MonoBehaviour
{
    #region ���
    [Header("�l�ܳt��"), Range(0, 100)]
    public float speed = 10;
    [Header("�n�l�ܪ�����W��")]
    public string nametraget;
    [Header("���k����")]
    public Vector2 limithorizontal;

    /// <summary>
    /// �n�l�ܪ��ؼ�
    /// </summary>
    private Transform target;
    private GameObject spr;

    #endregion

    #region �ƥ�

    private void Start()
    {
        target = GameObject.Find(nametraget).transform;
    }

    //���C��s:�bupdate������� (update����1�� lateupdate�|����C�@��) ��ĳ�Ω���v��
    private void LateUpdate()
    {
        track();
    }
    #endregion


    #region ��k

    private void track()
    {
        Vector3 poscamera = transform.position; // A�I :��v���y��
        Vector3 postarget = target.position;    // B�I :�ؼЪ��y��
        //��v�������G�y��=���oA�I��v���PB�I�ؼЪ����y��
        Vector3 posResult = Vector3.Lerp(poscamera, postarget, 0.5f);
        //��v��Z�b��^�w�] -10 �קK�ݤ���ؼЪ�
        posResult.z = -10;

        //�ϥΧ���api ������v�� �����k�d��
        posResult.x = Mathf.Clamp(posResult.x, limithorizontal.x, limithorizontal.y);

        // �����󪺮y�� ���w�� �B��᪺�y��
        transform.position = posResult;

    }
    #endregion

}
