using UnityEngine;

/// <summary>
/// �����ؼжi�J��ܰ�
/// ��ܹ�ܨt��
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [Header("��ܸ��")]
    public DataDialogue dataDialogue;

    [Header("��ܨt��")]
    public Dialoguesystem dialoguesystem;

    [Header("Ĳ�o��ܪ���H")]
    public string target = "�p��";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.name == target)
        {
            // print("���F��i�JĲ�o�ϰ�F!");
            // print(collision.name);

            dialoguesystem.StartDialogue(dataDialogue.dialogue);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialoguesystem.StopDialogue();
        }

    }
}
