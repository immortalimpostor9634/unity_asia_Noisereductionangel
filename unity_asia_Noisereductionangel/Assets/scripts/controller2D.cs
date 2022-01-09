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
    public float jump = 300;

    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkgroundradius = 0.1f;
    public Vector3 checkgroundoffest;

    [Header("跳躍按鍵與可跳圖層")]
    public KeyCode keyjump = KeyCode.RightAlt;
    public LayerMask canjumplayer;

    [Header("動畫參數:跳躍與攻擊")]
    public string parameterJump = "小白_跳躍";
    public string parameterAttacket = "小白_攻擊";
    public string parameterDie = "小白_死亡";

    #endregion

    #region 欄位 : 私人

    // 設定動畫欄位
    private Animator ani;

    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    // 將私人欄位顯示在面板上
    [SerializeField]
    ///<summary>
    /// 是否在地板上
    /// </summary>
    private bool isGrounded;

    #endregion

    #region 事件

    /// <summary>
    /// 繪製圖示
    /// 在unity中繪製輔助用的圖示
    /// </summary>
    private void OnDrawGizmos()
    {
        // 決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 決定繪製圖形及位置
        // transform.position 此物件的世界座標
        // transform.TransformDirection 根據變形元件的區域座標轉換為世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkgroundoffest) , checkgroundradius);
    }

    // 開始事件
    private void Start()
    {
        // 剛體欄位 = 取得元件 <2D剛體>();
        rig = GetComponent<Rigidbody2D>();

        // 動畫欄位 = 取得元件 <動畫控制器>();
        ani = GetComponent<Animator>();
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
        checkground();
        Jump();
    }

    #endregion

    #region 方法

    /// <summary>
    /// 1.玩家是否有按方向鍵
    /// 2.物件移動行為(API)
    /// </summary>
    private void move()
    {
        float hori = Input.GetAxis("Horizontal");
        // print(" 玩家左右鍵值:" + hori);

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

    ///<summary>
    /// 檢查是否在地板
    /// </summary>
    private void checkground()
    {
        // 碰撞資訊 = 2D物理.覆蓋圓形(中心點，半徑，圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkgroundoffest), checkgroundradius, canjumplayer);

        // print("碰到的物件名稱:" + hit.name);
        isGrounded = hit;

        // 當 小白不在地上 時 勾選 小白_跳躍 的參數
        ani.SetBool(parameterJump,!isGrounded);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // 如果 角色在地板上 且 按下指定按鍵
        if (isGrounded && Input.GetKeyDown(keyjump))
        {
            rig.AddForce(new Vector2(0, jump));
        }
    }
    #endregion
}
