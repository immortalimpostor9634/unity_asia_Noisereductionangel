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

    [Header("���D����P�i���ϼh")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canjumplayer;

    #endregion

    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    // �N�p�H�����ܦb���O�W
    [SerializeField]
    ///<summary>
    /// �O�_�b�a�O�W
    /// </summary>
    private bool isGrounded;
    

    /// <summary>
    /// ø�s�ϥ�
    /// �bunity��ø�s���U�Ϊ��ϥ�
    /// </summary>
    private void OnDrawGizmos()
    {
        // �M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // �M�wø�s�ϧΤΦ�m
        // transform.position �����󪺥@�ɮy��
        // transform.TransformDirection �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkgroundoffest) , checkgroundradius);
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
        checkground();
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

    ///<summary>
    /// �ˬd�O�_�b�a�O
    /// </summary>
    private void checkground()
    {
        // �I����T = 2D���z.�л\���(�����I�A�b�|�A�ϼh)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkgroundoffest), checkgroundradius, canjumplayer);

        //print("�I�쪺����W��:" + hit.name);
        isGrounded = hit;
    }
    #endregion
}
