using UnityEngine;

/// <summary>
/// 控制器 : 小白
/// </summary>
public class controller2D : MonoBehaviour
{
    #region 欄位 : 公開

    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;

    [Header("跳躍高度"), Range(0, 1000)]
    public float jumped = 300;

    #endregion

    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

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

    #region 方法
    /// <summary>
    /// 1.玩家是否有按方向鍵
    /// 2.物件移動行為(API)
    /// </summary>
    private void move()
    {
        float hori = Input.GetAxis("Horizontal");
        print(" 玩家左右鍵值:" + hori);
    }
    #endregion
}
