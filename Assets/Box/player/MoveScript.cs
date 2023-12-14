using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class MoveScript : MonoBehaviour
{
    public float moveSpeedX;

    public float moveSpeedY;

    private float windPower = 0;

    private float windPowerX = 0;

    private float downpower = 0;

    private float defaultDrag = 0.0f;

    Rigidbody rb;

    public bool isCollision = false;

    public float playerGravity;

    public float neutralRotateZ;

    public float upRotateZ;

    public float downRotateZ;

    public bool isGoal = false;

    private float horizontalInput = 0;
    private float verticalInput = 0;

    public bool isAlive = true;


    private  GameObject nullPrefab;
    private GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = defaultDrag;

        nullPrefab = GameObject.FindGameObjectWithTag("IsAlive");
        gameManager = nullPrefab.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!isGoal)
        {
            // 入力を取得
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = 0f;
            verticalInput = 0f;
        }



        // 下入力が入っていれば下降力を加算
        if (verticalInput < 0)
        {
            downpower = -1f;
        }
        else
        {
            downpower = 0f;
        }

        WindPower();

        // playerが後ろに下がれないように
         if (horizontalInput < 0)
          {
              horizontalInput = 0;
          }
        // 入力から移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        Vector3 newPosition = new Vector3((movement.x + windPowerX) * moveSpeedX, (windPower + downpower) * moveSpeedY - playerGravity, 0f);



        rb.velocity = newPosition;




        if (verticalInput < 0)
        {
            transform.DORotate(new Vector3(0, 0, downRotateZ), 1, RotateMode.Fast);

        }
        else if (isCollision)
        {
            transform.DORotate(new Vector3(0, 0, upRotateZ), 1, RotateMode.Fast);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, neutralRotateZ), 1, RotateMode.Fast);
        }



    }

    private void WindPower()
    {
        if (isCollision)
        {
            windPower = 0.8f;
            windPowerX = -0.2f;
        }
        else
        {
            if (windPower > 0)
            {
                windPower -= 2.0f * Time.deltaTime;
                windPowerX -= 2.0f * Time.deltaTime;

                if (windPower < 0)
                {
                    windPower = 0;
                }
            }

            windPowerX = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // 取得したタグを使って何かしらの処理を行う
        if (collidedObjectTag == "Goal")
        {
            Debug.Log("ゴール");
            // isLife = false;
        }
    }

}
