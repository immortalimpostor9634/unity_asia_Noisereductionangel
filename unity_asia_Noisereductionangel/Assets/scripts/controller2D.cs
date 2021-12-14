using UnityEngine;

/// <summary>
/// ��� : �p��
/// </summary>
public class controller2D : MonoBehaviour
{
    #region ��� : ���}

    [Header("���ʳt��"), Range(0, 50)]
    public float speed = 3.5f;

    [Header("���D����"), Range(0, 1000)]
    public float jumped = 300;

    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkgroundradius = 0.1f;
    public Vector3 checkgroundoffest;


    #endregion

    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    /// <summary>
    /// ø�s�ϥ�
    /// �bunity��ø�s���U�Ϊ��ϥ�
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, checkgroundradius);
    }

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

    private void Update()
    {
        flip();
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

        // ���餸��.�[�t�� = �s�G���V�q( �ϰ��ܼƦW��*���ʳt��,0)
        rig.velocity = new Vector2(hori * speed, rig.velocity.y);
    }

    /// <summary>
    /// ½��
    /// �� hori < 0 (���⩹������) �A���� Y = 180
    /// �� hori > 0 (���⩹�k����) �A���� Y = 0
    /// </summary>
    private void flip()
    {
        float hori = Input.GetAxis("Horizontal");

        // �� hori < 0 (���⩹������) �A���� Y = 180
        if ( hori < 0 )
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        // �� hori > 0 (���⩹�k����) �A���� Y = 0
        if (hori > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    #endregion
}
