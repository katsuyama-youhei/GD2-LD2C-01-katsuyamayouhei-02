using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{

    private GameObject player;
    private MoveScript playerMove;

    public AudioClip sound1;
    AudioSource audioSource;

    private bool isFade;
    double FadeDeltaTime = 0;
    public double FadeOutSeconds = 0.4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove=player.GetComponent<MoveScript>();

        audioSource = GetComponent<AudioSource>();
        isFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                isFade = false;
            }
            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.isCollision = true;

            audioSource.PlayOneShot(sound1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.isCollision = false;
            isFade = true;

        }
    }

}
