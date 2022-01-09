using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// 受傷系統
/// </summary>
public class Huntsystem : MonoBehaviour
{
    #region 欄位

    [Header("血條")]
    public Image imgHPbar;

    [Header("血量")]
    public float HP =100;

    [Header("動畫參數")]
    public string parameterDead = "小白_死亡";

    [Header("死亡事件")]
    public UnityEvent onDead;


    private float HPmax;

    private Animator ani;

    #endregion

    #region 事件

    // 喚醒事件 : 在 Start 之前執行一次
    private void Awake()
    {
        ani = GetComponent<Animator>();
        HPmax = HP;
    }

    #endregion

    #region 方法

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hunt(float damage)
    {
        HP += damage;
        imgHPbar.fillAmount = HP / HPmax;
        if (HP <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }

    #endregion
}
