using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region ���

    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;

    [Header("���ʳt��")]
    public float speed = 1.5f;

    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    [Header("���ۥؼЪ���")]
    public Transform target;

    [Header("�����Z��"), Range(0, 5)]
    public float AttackDistance = 1.3f;

    [Header("�����N�o�ɶ�"), Range(0, 10)]
    public float AttackCD = 2.8f;

    [Header("�ˬd�����ϰ�j�p�P�첾")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    [Header("�����O"), Range(0, 100)]
    public float attack = 35;


    private Rigidbody2D rig;

    private float angle = 0;

    private float timerAttack;

    #endregion

    #region �ƥ�

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        // ���w�ϥܪ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);

        // ø�s�ߤ���(����,�ؤo)
        Gizmos.DrawCube(transform.position +
            transform.TransformDirection (v3TrackOffset), v3TrackSize);

        Gizmos.color = new Color(0, 1, 0, 0.3f);

        Gizmos.DrawCube(transform.position +
            transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }

    private void Update()
    {
        CheckTargetInArea();
    }

    #endregion

    #region ��k

    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D ���z.�л\����(����,�ؤo,����)
        Collider2D hit = Physics2D.OverlapBox(transform.position +
            transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);

        if (hit) Move();
    }


    /// <summary>
    /// ����
    /// </summary>
    private void Move()
    {
        if (target.position.x > transform.position.x)
        {
            // �k�� angle = 180
        }

        else if (target.position.x < transform.position.x)
        {
            // ���� angle = 0
        }

        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));

        // �Z�� = �T���V�q.�Z��(A�I,B�I)
        float distance = Vector3.Distance(target.position, transform.position);
        // print("�P�ؼЪ��Z��:" + distance);

        if (distance <= AttackDistance)    // �p�G �Z�� �p�󵥩� �����Z��
        {
            rig.velocity = Vector3.zero;   // �����
        }

    }

    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {
        if (timerAttack < AttackCD)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            timerAttack = 0;

            Collider2D hit = Physics2D.OverlapBox(transform.position + 
                transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, layerTarget);
            print("�����쪫��:" + hit.name);

            hit.GetComponent<Huntsystem>().Hunt(attack);
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //�W��col��Ĳ�o�ƥ�
    {
        if (col.tag == "enemy" || col.tag == "bullt")
        {
            Destroy(col.gameObject);   //�����I��������
            Destroy(gameObject);   //�������󥻨�
        }
    }

    #endregion
}
