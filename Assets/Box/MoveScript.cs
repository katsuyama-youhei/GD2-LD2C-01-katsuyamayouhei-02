using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveSpeed;

    public float windPower = 0;

    private float downpower = 0;

    private float defaultDrag = 5.0f;

    Rigidbody rb;

    public bool isCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = defaultDrag;
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
            downpower = -1f;
        }
        else
        {
            downpower = 0f;
        }
        // 入力から移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        Vector3 newPosition = new Vector3(movement.x * moveSpeed, (windPower + downpower) * moveSpeed, 0f);

        // プレイヤーの座標を更新
        transform.position += newPosition * Time.deltaTime;

        WindPower();

    }

    private void OnTriggerEnter(Collider other)
    {
      //  isCollision = true;
       
        //Debug.Log("true");

    }

    private void OnTriggerExit(Collider other)
    {
      //  isCollision = false;
       // Debug.Log("false");

    }

    private void WindPower()
    {
        if (isCollision)
        {
            windPower = 0.8f;
        }
        else
        {
            if (windPower > 0)
            {
                windPower -= 2.0f * Time.deltaTime;
                if (windPower < 0)
                {
                    windPower = 0;
                }
            }
        }
    }

}
