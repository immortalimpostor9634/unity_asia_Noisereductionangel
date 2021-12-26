using UnityEngine;

[CreateAssetMenu(menuName = "自訂選項/對話資料")]
/// <summary>
/// 對話資料
/// </summary>
// ScriptableObject 腳本化物件 : 將程式資料儲存至 project 內的物件
public class DataDialogue : ScriptableObject
{
    [Header("對話內容"),TextArea(3,5)]
    public string[] dialogue;
}
