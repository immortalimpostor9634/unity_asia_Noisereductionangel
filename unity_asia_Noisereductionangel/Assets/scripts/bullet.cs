using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    #region �ƥ�

    private void Update()
    {
        gameObject.transform.position += new Vector3(0.1f, 0, 0);
    }

    #endregion
}
