using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BalloonScript : MonoBehaviour
{

    public static Particle particle;
    private float lifeTimer;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;
    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // �p�[�e�B�N���̕\������
        lifeTimer = 1f;
        leftLifeTime = lifeTimer;
        float newScale = Random.Range(0.5f, 1f);
        // �����Ńp�[�e�B�N���̃X�P�[����ύX
       /* Vector3 newScale = new Vector3(
          Random.Range(0.5f, 1f),
          Random.Range(0.2f, 1f),
          Random.Range(0.2f, 1f)
          );*/

        Transform transform = GetComponent<Transform>();

        transform.localScale = new Vector3(newScale,newScale,newScale);

        defaultScale = transform.localScale;

        // �p�[�e�B�N���̔��ł��������𗐐���
        velocity = new Vector3
            (
            Random.Range(-maxVelocity, maxVelocity + 3f),
            Random.Range(0.1f, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity)
            );

    }

    // Update is called once per frame
    void Update()
    {
        leftLifeTime -= Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
        transform.localScale = Vector3.Lerp
            (
            new Vector3(0, 0, 0),
            defaultScale,
            leftLifeTime / lifeTimer
            );
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
