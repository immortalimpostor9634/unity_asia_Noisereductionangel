using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    #region ¨Æ¥ó

    private void Update()
    {
        gameObject.transform.position += transform.right * 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    #endregion
}
