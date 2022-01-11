using System.Collections;
using UnityEngine;

public class Attacksystem : MonoBehaviour
{
    [Header("動畫參數:攻擊")]
    public string parameterAttacket = "小白_攻擊";

    public GameObject Bullet;

    // 設定動畫欄位
    private Animator ani;

    [Header("檢查攻擊出口與轉向")]
    [Range(0, 1)]
    public float checkbulltout = 0.1f;
    public Vector3 checkbulltoffest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position +
            transform.TransformDirection(checkbulltoffest);

            Instantiate(Bullet, pos, gameObject.transform.rotation);

            ani.SetTrigger(parameterAttacket);

        }
    }

    private void Start()
    {
        // 動畫欄位 = 取得元件 <動畫控制器>();
        ani = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        // 決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 決定繪製圖形及位置
        // transform.position 此物件的世界座標
        // transform.TransformDirection 根據變形元件的區域座標轉換為世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkbulltoffest), checkbulltout);
    }
}
