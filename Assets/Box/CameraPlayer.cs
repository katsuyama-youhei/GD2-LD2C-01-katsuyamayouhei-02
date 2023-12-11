using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public GameObject player;
    private MoveScript moveScript;
    // Start is called before the first frame update
    void Start()
    {
        moveScript=player.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveScript.isGoal)
        {
            transform.position = new Vector3(player.transform.position.x - 3.0f, player.transform.position.y + 5.57f, player.transform.position.z - 12f);
        }

    }
}
