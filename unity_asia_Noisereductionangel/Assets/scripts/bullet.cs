using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    #region �ƥ�

    private void Update()
    {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)   //�W��col��Ĳ�o�ƥ�
    {
        if (col.tag == "enemy" || col.tag == "bullt")
        {
            Destroy(col.gameObject);   //�����I��������
            Destroy(gameObject);   //�������󥻨�
        }
    }

    #endregion
}
