using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ConfettiScript : MonoBehaviour
{

    public static Particle particle;
    private float lifeTimer;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;
    public float maxVelocity;
   
    private float rotateX = 0;
    
    private float rotateY = 0;

    private float rotateZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        // �p�[�e�B�N���̕\������
        lifeTimer = 2f;
        leftLifeTime = lifeTimer;
        //float newScale = Random.Range(0.5f, 1f);
        // �����Ńp�[�e�B�N���̃X�P�[����ύX
        Vector3 newScale = new Vector3(
          Random.Range(0.5f, 1f),
          Random.Range(0.2f, 1f),
          Random.Range(0.2f, 1f)
          );

        Transform transform = GetComponent<Transform>();

        //transform.localScale = new Vector3(newScale, newScale, newScale);
        transform.localScale = newScale;

        defaultScale = transform.localScale;

        // �p�[�e�B�N���̔��ł��������𗐐���
        velocity = new Vector3
            (
            Random.Range(-maxVelocity, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity)
            );

        Vector3 newRotate = new Vector3(
            Random.Range(10.0f,30.0f),
            Random.Range(10.0f, 30.0f),
            Random.Range(10.0f, 30.0f)
            );

        rotateX = newRotate.x;
        rotateY= newRotate.y;
        rotateZ = newRotate.z;

    }

    // Update is called once per frame
    void Update()
    {
        leftLifeTime -= Time.deltaTime;

        if (lifeTimer < 1.8f)
        {
            if (velocity.y > 0f)
            {
                velocity.y *= -1;
            }
        }

        transform.position += velocity * Time.deltaTime;
        transform.localScale = Vector3.Lerp
            (
            new Vector3(0, 0, 0),
            defaultScale,
            leftLifeTime / lifeTimer
            );

        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
       transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);

         if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
