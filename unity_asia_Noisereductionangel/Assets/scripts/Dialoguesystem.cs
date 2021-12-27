using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 對話系統
/// 將需要輸出的文字用打字效果呈現
/// </summary>
public class Dialoguesystem : MonoBehaviour
{

    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;

    [Header("畫布對話系統")]
    public GameObject GoDialogue;

    [Header("對話內容")]
    public Text textContent;

    [Header("對話完成圖示")]
    public GameObject GoTip;

    [Header("對話按鍵")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        // StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    /// <param name="contents"></param>
    /// <returns></returns>
    private IEnumerator TypeEffect(string[] contents )
    {
        // string test1 = "測試1測試1測試1測試1";
        // string test2 = "測試2測試2測試2測試2";

        // string[] test = { test1, test2 };

        GoDialogue.SetActive(true);    // 顯示對話物件

        for (int j = 0; j < contents.Length; j++)    // 遍尋所有對話
        {

            textContent.text = " ";     // 清除上次對話內容
            GoTip.SetActive(false);    // 隱藏對話完成圖示

            for (int i = 0; i < contents[j].Length; i++)  // 遍尋對話裡每一個字
            {
                textContent.text += contents[j][i];      // 疊加對話內容文字介面
                yield return new WaitForSeconds(interval);
            }

            GoTip.SetActive(true);    // 顯示對話完成圖示

            while (!Input.GetKeyDown(keyDialogue))    // 沒有按下按鍵時持續進行
            {
                yield return null;   // 等待一個 null 的時間
            }
        }

        GoTip.SetActive(false);    // 隱藏對話完成圖示
        GoDialogue.SetActive(false);    // 隱藏對話介面

    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <param name = "contents"> 要顯示打字效果的對話內容 </param>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// 結束對話
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();     // 停止協程
    }
}
