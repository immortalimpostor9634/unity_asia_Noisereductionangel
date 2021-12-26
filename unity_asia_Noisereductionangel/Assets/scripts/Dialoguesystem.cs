using UnityEngine;
using System.Collections;

/// <summary>
/// 對話系統
/// 將需要輸出的文字用打字效果呈現
/// </summary>
public class Dialoguesystem : MonoBehaviour
{

    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect()
    {
        string test = "測試測試測試測試測試";

        for (int i = 0; i < test.Length; i++)
        {
            print(test[i]);
            yield return new WaitForSeconds(interval);       }
    }
}
