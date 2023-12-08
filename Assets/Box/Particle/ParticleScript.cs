using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleScript : MonoBehaviour
{

    public static Particle particle;
    private float lifeTimer;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;
    public float maxVelocity;
    private float randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = 1f;
        leftLifeTime = lifeTimer;

        Vector3 newScale = new Vector3(
          Random.Range(0.5f, 1f),
          Random.Range(0.2f, 1f),
          Random.Range(0.2f, 1f)
          );

        Transform transform = GetComponent<Transform>();

        transform.localScale = newScale;

        defaultScale = transform.localScale;

        velocity = new Vector3
            (
            Random.Range(-maxVelocity, maxVelocity+3f),
            Random.Range(-maxVelocity, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity)
            );

        randomPosition = Random.Range(0.4f, 0.8f);

      
    }

    // Update is called once per frame
    void Update()
    {
        leftLifeTime -= Time.deltaTime;

        if( leftLifeTime < randomPosition) {
            if (velocity.y > 0)
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
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
