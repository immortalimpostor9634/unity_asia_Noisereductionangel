using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenecontroler : MonoBehaviour
{

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Quit()
    {
        Application.Quit();    // �������ε{��
        print("�����C��");
    }

}
