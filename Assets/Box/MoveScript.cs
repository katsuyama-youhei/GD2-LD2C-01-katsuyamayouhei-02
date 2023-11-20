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
        // 入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
      
    
        // 入力から移動ベクトルを作成

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        
        

        // プレイヤーの座標を更新
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
