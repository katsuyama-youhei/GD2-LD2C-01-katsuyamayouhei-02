using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTitleMoveScript : MonoBehaviour
{

    Rigidbody rb;

    private float defaultDrag = 0.0f;

    private float windPower = 0;

    private float windPowerX = 0;

    private float downpower = 0;

    public bool isCollision = false;

    public float moveSpeedX;

    public float moveSpeedY;

    public float playerGravity;

    public float neutralRotateZ;

    public float upRotateZ;

    public bool isRainCollision = false;

    private Vector3 defaultScale;

    private float lifeTimer;
    private float leftLifeTime;

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = defaultDrag;

    

         transform = GetComponent<Transform>();

        defaultScale = transform.localScale;

        lifeTimer = 0.8f;
        leftLifeTime = lifeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        WindPower();

        // ì¸óÕÇ©ÇÁà⁄ìÆÉxÉNÉgÉãÇçÏê¨
        Vector3 movement = new Vector3(1f, 0f, 0f);

        Vector3 newPosition = new Vector3((movement.x + windPowerX) * moveSpeedX, (windPower + downpower) * moveSpeedY - playerGravity, 0f);

        rb.velocity = newPosition;


        if (isCollision)
        {
            transform.DORotate(new Vector3(0, 0, upRotateZ), 1, RotateMode.Fast);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, neutralRotateZ), 1, RotateMode.Fast);
        }

        if (isRainCollision)
        {
            leftLifeTime -= Time.deltaTime;

            transform.localScale = Vector3.Lerp
           (
           new Vector3(0, 0, 0),
           defaultScale,
           leftLifeTime / lifeTimer
           );
        }

        if(leftLifeTime < 0f) { 
            isRainCollision = false;
            Vector3 localPosition = new Vector3( 2.5f, 3.24f, 0f );
            transform.position = localPosition;
            transform.localScale = defaultScale;
            leftLifeTime = lifeTimer;
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
}
