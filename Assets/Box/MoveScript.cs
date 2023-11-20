using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float moveSpeed = 8.0f;

    public float windPower = 0;

    private float gravity=-0.2f;

    private float downpower = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // �����͂������Ă���Ή��~�͂����Z
        if (verticalInput < 0)
        {
            downpower = -0.8f;
        }
        else
        {
            downpower = 0f;
        }
        // ���͂���ړ��x�N�g�����쐬
        Vector3 movement = new Vector3(horizontalInput, windPower+ gravity+ downpower, 0f);



        // �v���C���[�̍��W���X�V
        transform.position += movement * moveSpeed * Time.deltaTime;

    }

}
