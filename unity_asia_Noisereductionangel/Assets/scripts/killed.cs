using UnityEngine;

public class killed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)   //名為col的觸發事件
    {
        if (col.tag == "enemy" || col.tag == "bullt")
        {
            Destroy(col.gameObject);   //消滅碰撞的物件
            Destroy(gameObject);   //消滅物件本身
        }
    }
}
