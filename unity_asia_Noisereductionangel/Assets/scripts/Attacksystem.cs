using System.Collections;
using UnityEngine;

public class Attacksystem : MonoBehaviour
{
    [Header("動畫參數:攻擊")]
    public string parameterAttacket = "小白_攻擊";

    public GameObject Bullet;

    // 設定動畫欄位
    private Animator ani;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0.3f, -0.3f, 0);

            Instantiate(Bullet, pos, gameObject.transform.rotation);

            ani.SetTrigger(parameterAttacket);

        }
    }

    private void Start()
    {
        // 動畫欄位 = 取得元件 <動畫控制器>();
        ani = GetComponent<Animator>();
    }

}
