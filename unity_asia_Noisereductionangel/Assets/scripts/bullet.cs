using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    #region 事件

    private void Update()
    {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
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
