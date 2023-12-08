using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    private GameObject nullPrefab;
    private GameManagerScript gameManager;

    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        nullPrefab = GameObject.FindGameObjectWithTag("IsAlive");
        gameManager = nullPrefab.GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.isAlive) {
           /* if (Input.GetKeyDown(KeyCode.Space))
            {
                Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            }*/
           //　指定したタグを持つオブジェクトをすべて取得
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PaperDust");

            // 配列が空かどうかを確認して処理を行う
            if (objectsWithTag.Length == 0)
            {
                Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            }
        }
       
    }

   
}
