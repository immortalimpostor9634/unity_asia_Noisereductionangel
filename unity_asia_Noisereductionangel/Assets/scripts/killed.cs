using UnityEngine;

public class killed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)   //�W��col��Ĳ�o�ƥ�
    {
        if (col.tag == "enemy" || col.tag == "bullt")
        {
            Destroy(col.gameObject);   //�����I��������
            Destroy(gameObject);   //�������󥻨�
        }
    }
}
