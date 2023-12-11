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

    public GameObject particlePrehub;

    // Start is called before the first frame update
    void Start()
    {
        // パーティクルの表示時間
        lifeTimer = Random.Range(0.8f,1.4f);
        leftLifeTime = lifeTimer;
        float newScale = Random.Range(0.8f, 1.5f);
        // 乱数でパーティクルのスケールを変更
       /* Vector3 newScale = new Vector3(
          Random.Range(0.5f, 1f),
          Random.Range(0.2f, 1f),
          Random.Range(0.2f, 1f)
          );*/

        Transform transform = GetComponent<Transform>();

        transform.localScale = new Vector3(newScale,newScale,newScale);

        defaultScale = transform.localScale;

        // パーティクルの飛んでいく方向を乱数で
        velocity = new Vector3
            (
            Random.Range(-maxVelocity, maxVelocity),
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
        if (leftLifeTime <= 0) {
            for (int i = 0; i < 5; i++)
            {
                float newPosition = Random.Range(-1f, 1f);
                Vector3 pos = new Vector3(transform.position.x + newPosition,transform.position.y, transform.position.z);

                Vector3 newRotate = new Vector3(
           Random.Range(0.0f, 30.0f),
           Random.Range(0.0f, 30.0f),
           Random.Range(0.0f, 30.0f)
           );

                Quaternion initialRotation = Quaternion.Euler(newRotate.x+30f, newRotate.y, newRotate.z);

                Instantiate(particlePrehub, pos, initialRotation);
            }
            Destroy(gameObject);
        }
    }
}
