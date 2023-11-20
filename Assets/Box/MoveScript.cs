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
        // 入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // 下入力が入っていれば下降力を加算
        if (verticalInput < 0)
        {
            downpower = -0.8f;
        }
        else
        {
            downpower = 0f;
        }
        // 入力から移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, windPower+ gravity+ downpower, 0f);



        // プレイヤーの座標を更新
        transform.position += movement * moveSpeed * Time.deltaTime;

    }

}
