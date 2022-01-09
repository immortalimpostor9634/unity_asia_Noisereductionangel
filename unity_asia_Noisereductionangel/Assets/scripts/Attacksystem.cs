using System.Collections;
using UnityEngine;

public class Attacksystem : MonoBehaviour
{
    [Header("�ʵe�Ѽ�:����")]
    public string parameterAttacket = "�p��_����";

    public GameObject Bullet;

    // �]�w�ʵe���
    private Animator ani;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0.3f, -0.3f, 0);

            Instantiate(Bullet, pos, gameObject.transform.rotation);

            ani.SetTrigger(parameterAttacket);

        }
    }

    private void Start()
    {
        // �ʵe��� = ���o���� <�ʵe���>();
        ani = GetComponent<Animator>();
    }

}
