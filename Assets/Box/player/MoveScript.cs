using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

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

    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = defaultDrag;
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
            downpower = -1f;
        }
        else
        {
            downpower = 0f;
        }

        WindPower();

        // player�����ɉ�����Ȃ��悤��
        /*  if (horizontalInput < 0)
          {
              horizontalInput = 0;
          }*/
        // ���͂���ړ��x�N�g�����쐬
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        Vector3 newPosition = new Vector3((movement.x + windPowerX) * moveSpeedX, (windPower + downpower) * moveSpeedY - playerGravity, 0f);



        rb.velocity = newPosition;




        if (downpower < 0)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, downRotateZ);
        }
        else if (windPower > 0)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, upRotateZ);
        }
        else
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, neutralRotateZ);
        }



    }

    private void WindPower()
    {
        if (isCollision)
        {
            windPower = 0.8f;
            windPowerX = 0.3f;
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
                if (windPowerX < 0)
                {
                    windPowerX = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // �擾�����^�O���g���ĉ�������̏������s��
        if (collidedObjectTag == "Goal")
        {
            Debug.Log("�S�[��");
        }
    }

    void RotateUp()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        float newRotation = currentRotation.z + upRotateZ * Time.deltaTime;

        transform.rotation = Quaternion.Euler(currentRotation.x, newRotation, currentRotation.z);
    }

    void RotateDown()
    {

    }

}
