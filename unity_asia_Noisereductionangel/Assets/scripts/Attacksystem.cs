using System.Collections;
using UnityEngine;

public class Attacksystem : MonoBehaviour
{
    [Header("�ʵe�Ѽ�:����")]
    public string parameterAttacket = "�p��_����";

    public GameObject Bullet;

    // �]�w�ʵe���
    private Animator ani;

    [Header("�ˬd�����X�f�P��V")]
    [Range(0, 1)]
    public float checkbulltout = 0.1f;
    public Vector3 checkbulltoffest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position +
            transform.TransformDirection(checkbulltoffest);

            Instantiate(Bullet, pos, gameObject.transform.rotation);

            ani.SetTrigger(parameterAttacket);

        }
    }

    private void Start()
    {
        // �ʵe��� = ���o���� <�ʵe���>();
        ani = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        // �M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // �M�wø�s�ϧΤΦ�m
        // transform.position �����󪺥@�ɮy��
        // transform.TransformDirection �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkbulltoffest), checkbulltout);
    }
}
