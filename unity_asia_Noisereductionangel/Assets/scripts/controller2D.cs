using UnityEngine;

/// <summary>
/// 控制器 : 小白
/// </summary>
public class controller2D : MonoBehaviour
{
    #region 欄位 : 公開

    [Header("移動速度"), Range(0, 50)]
    public float speed = 3.5f;

    [Header("跳躍高度"), Range(0, 1000)]
    public float jumped = 300;

    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkgroundradius = 0.1f;
    public Vector3 checkgroundoffest;


    #endregion

    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    /// <summary>
    /// 繪製圖示
    /// 在unity中繪製輔助用的圖示
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
    /// 固定更新事件 (處理物理行為)
    /// </summary>
    private void FixedUpdate()
    {
        move();
    }

    private void Update()
    {
        flip();
    }

    #region 方法
    /// <summary>
    /// 1.玩家是否有按方向鍵
    /// 2.物件移動行為(API)
    /// </summary>
    private void move()
    {
        float hori = Input.GetAxis("Horizontal");
        print(" 玩家左右鍵值:" + hori);

        // 剛體元件.加速度 = 新二維向量( 區域變數名稱*移動速度,0)
        rig.velocity = new Vector2(hori * speed, rig.velocity.y);
    }

    /// <summary>
    /// 翻面
    /// 當 hori < 0 (角色往左移動) ，角度 Y = 180
    /// 當 hori > 0 (角色往右移動) ，角度 Y = 0
    /// </summary>
    private void flip()
    {
        float hori = Input.GetAxis("Horizontal");

        // 當 hori < 0 (角色往左移動) ，角度 Y = 180
        if ( hori < 0 )
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        // 當 hori > 0 (角色往右移動) ，角度 Y = 0
        if (hori > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    #endregion
}
