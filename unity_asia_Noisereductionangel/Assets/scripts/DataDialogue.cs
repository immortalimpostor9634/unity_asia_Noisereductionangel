using UnityEngine;

[CreateAssetMenu(menuName = "�ۭq�ﶵ/��ܸ��")]
/// <summary>
/// ��ܸ��
/// </summary>
// ScriptableObject �}���ƪ��� : �N�{������x�s�� project ��������
public class DataDialogue : ScriptableObject
{
    [Header("��ܤ��e"),TextArea(3,5)]
    public string[] dialogue;
}
