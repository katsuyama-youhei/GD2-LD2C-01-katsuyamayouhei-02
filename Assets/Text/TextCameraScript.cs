using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextCameraScript : MonoBehaviour
{
    public Camera mainCamera;

    public float moveDistance = 1.0f; // 上下移動の距離
    public float duration = 2.0f; // アニメーションの時間
    // Start is called before the first frame update
    void Start()
    {
        Transform transform=GetComponent<Transform>();

        Transform cameraTransform = mainCamera.GetComponent<Transform>();

        transform.localPosition=new Vector3(cameraTransform.localPosition.x+10.61f, cameraTransform.localPosition.y - 4.6708f, cameraTransform.localPosition.z+2f);

        transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);

        AnimateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        // カメラの forward ベクトルを取得し、それを向くように回転を設定
       // transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);

        //transform.LookAt(mainCamera.transform);
    }

    void AnimateSprite()
    {
        // スプライトの現在の位置
        Vector3 startPos = transform.position;

        // 上下の目標位置を設定
        Vector3 endPos = startPos + new Vector3(0, moveDistance, 0);

        // 上下のアニメーションを実行
        transform.DOMove(endPos, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
