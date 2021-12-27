using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ��ܨt��
/// �N�ݭn��X����r�Υ��r�ĪG�e�{
/// </summary>
public class Dialoguesystem : MonoBehaviour
{

    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;

    [Header("�e����ܨt��")]
    public GameObject GoDialogue;

    [Header("��ܤ��e")]
    public Text textContent;

    [Header("��ܧ����ϥ�")]
    public GameObject GoTip;

    [Header("��ܫ���")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        // StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// ���r�ĪG
    /// </summary>
    /// <param name="contents"></param>
    /// <returns></returns>
    private IEnumerator TypeEffect(string[] contents )
    {
        // string test1 = "����1����1����1����1";
        // string test2 = "����2����2����2����2";

        // string[] test = { test1, test2 };

        GoDialogue.SetActive(true);    // ��ܹ�ܪ���

        for (int j = 0; j < contents.Length; j++)    // �M�M�Ҧ����
        {

            textContent.text = " ";     // �M���W����ܤ��e
            GoTip.SetActive(false);    // ���ù�ܧ����ϥ�

            for (int i = 0; i < contents[j].Length; i++)  // �M�M��̨ܸC�@�Ӧr
            {
                textContent.text += contents[j][i];      // �|�[��ܤ��e��r����
                yield return new WaitForSeconds(interval);
            }

            GoTip.SetActive(true);    // ��ܹ�ܧ����ϥ�

            while (!Input.GetKeyDown(keyDialogue))    // �S�����U����ɫ���i��
            {
                yield return null;   // ���ݤ@�� null ���ɶ�
            }
        }

        GoTip.SetActive(false);    // ���ù�ܧ����ϥ�
        GoDialogue.SetActive(false);    // ���ù�ܤ���

    }

    /// <summary>
    /// �}�l���
    /// </summary>
    /// <param name = "contents"> �n��ܥ��r�ĪG����ܤ��e </param>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// �������
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();     // �����{
    }
}
