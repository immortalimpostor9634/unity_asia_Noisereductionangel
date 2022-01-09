using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// ���˨t��
/// </summary>
public class Huntsystem : MonoBehaviour
{
    #region ���

    [Header("���")]
    public Image imgHPbar;

    [Header("��q")]
    public float HP =100;

    [Header("�ʵe�Ѽ�")]
    public string parameterDead = "�p��_���`";

    [Header("���`�ƥ�")]
    public UnityEvent onDead;


    private float HPmax;

    private Animator ani;

    #endregion

    #region �ƥ�

    // ����ƥ� : �b Start ���e����@��
    private void Awake()
    {
        ani = GetComponent<Animator>();
        HPmax = HP;
    }

    #endregion

    #region ��k

    /// <summary>
    /// ����
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
