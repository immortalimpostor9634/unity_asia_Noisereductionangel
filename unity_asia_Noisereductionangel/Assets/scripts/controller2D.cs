using UnityEngine;

/// <summary>
/// ��� : �p��
/// </summary>
public class controller2D : MonoBehaviour
{
    #region ��� : ���}

    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;

    [Header("���D����"), Range(0, 1000)]
    public float jumped = 300;

    #endregion

    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �T�w��s�ƥ� (�B�z���z�欰)
    /// </summary>
    private void FixedUpdate()
    {
        move();
    }

    #region ��k
    /// <summary>
    /// 1.���a�O�_������V��
    /// 2.���󲾰ʦ欰(API)
    /// </summary>
    private void move()
    {
        float hori = Input.GetAxis("Horizontal");
        print(" ���a���k���:" + hori);
    }
    #endregion
}
