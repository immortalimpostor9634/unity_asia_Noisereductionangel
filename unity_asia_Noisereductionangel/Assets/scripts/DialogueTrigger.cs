using UnityEngine;

/// <summary>
/// 偵測目標進入對話區
/// 顯示對話系統
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [Header("對話資料")]
    public DataDialogue dataDialogue;

    [Header("對話系統")]
    public Dialoguesystem dialoguesystem;

    [Header("觸發對話的對象")]
    public string target = "小白";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.name == target)
        {
            // print("有東西進入觸發區域了!");
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
