using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    #region ¨Æ¥ó

    private void Update()
    {
        gameObject.transform.position += new Vector3(0.1f, 0, 0);
    }

    #endregion
}
