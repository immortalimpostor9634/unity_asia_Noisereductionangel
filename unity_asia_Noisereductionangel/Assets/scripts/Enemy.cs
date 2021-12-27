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

    private Rigidbody2D rig;

    private float angle = 0;

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
        Gizmos.DrawCube(transform.position + transform.TransformDirection (v3TrackOffset), v3TrackSize);

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
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);

        if (hit) Move();
    }

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

        rig.velocity = new Vector2(-speed, rig.velocity.y);

    }

    #endregion
}
