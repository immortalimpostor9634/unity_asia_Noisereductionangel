using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region 欄位

    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;

    [Header("移動速度")]
    public float speed = 1.5f;

    [Header("目標圖層")]
    public LayerMask layerTarget;

    [Header("面相目標物件")]
    public Transform target;

    [Header("攻擊距離"), Range(0, 5)]
    public float AttackDistance = 1.3f;

    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float AttackCD = 2.8f;

    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    [Header("攻擊力"), Range(0, 100)]
    public float attack = 35;


    private Rigidbody2D rig;

    private float angle = 0;

    private float timerAttack;

    #endregion

    #region 事件

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);

        // 繪製立方體(中心,尺寸)
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

    #region 方法

    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D 物理.覆蓋盒形(中心,尺寸,角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position +
            transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);

        if (hit) Move();
    }


    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (target.position.x > transform.position.x)
        {
            // 右邊 angle = 180
        }

        else if (target.position.x < transform.position.x)
        {
            // 左邊 angle = 0
        }

        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));

        // 距離 = 三維向量.距離(A點,B點)
        float distance = Vector3.Distance(target.position, transform.position);
        // print("與目標的距離:" + distance);

        if (distance <= AttackDistance)    // 如果 距離 小於等於 攻擊距離
        {
            rig.velocity = Vector3.zero;   // 停止移動
        }

    }

    /// <summary>
    /// 攻擊
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
            print("攻擊到物件:" + hit.name);

            hit.GetComponent<Huntsystem>().Hunt(attack);
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //名為col的觸發事件
    {
        if (col.tag == "enemy" || col.tag == "bullt")
        {
            Destroy(col.gameObject);   //消滅碰撞的物件
            Destroy(gameObject);   //消滅物件本身
        }
    }

    #endregion
}
