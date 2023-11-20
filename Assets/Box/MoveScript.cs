using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float moveSpeed = 8.0f;
    private float jumpForce = 8.0f;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
      
    
        // ���͂���ړ��x�N�g�����쐬

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        
        

        // �v���C���[�̍��W���X�V
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
