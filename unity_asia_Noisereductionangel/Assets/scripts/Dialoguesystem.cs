using UnityEngine;
using System.Collections;

/// <summary>
/// ��ܨt��
/// �N�ݭn��X����r�Υ��r�ĪG�e�{
/// </summary>
public class Dialoguesystem : MonoBehaviour
{

    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect()
    {
        string test = "���մ��մ��մ��մ���";

        for (int i = 0; i < test.Length; i++)
        {
            print(test[i]);
            yield return new WaitForSeconds(interval);       }
    }
}
