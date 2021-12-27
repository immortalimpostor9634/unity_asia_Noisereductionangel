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

    private Rigidbody2D rig;

    private float angle = 0;

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
        Gizmos.DrawCube(transform.position + transform.TransformDirection (v3TrackOffset), v3TrackSize);

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
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);

        if (hit) Move();
    }

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

        rig.velocity = new Vector2(-speed, rig.velocity.y);

    }

    #endregion
}
