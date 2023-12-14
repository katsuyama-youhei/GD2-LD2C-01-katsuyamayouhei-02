using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextCameraScript : MonoBehaviour
{
    public Camera mainCamera;

    public float moveDistance = 1.0f; // �㉺�ړ��̋���
    public float duration = 2.0f; // �A�j���[�V�����̎���
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
        // �J������ forward �x�N�g�����擾���A����������悤�ɉ�]��ݒ�
       // transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);

        //transform.LookAt(mainCamera.transform);
    }

    void AnimateSprite()
    {
        // �X�v���C�g�̌��݂̈ʒu
        Vector3 startPos = transform.position;

        // �㉺�̖ڕW�ʒu��ݒ�
        Vector3 endPos = startPos + new Vector3(0, moveDistance, 0);

        // �㉺�̃A�j���[�V���������s
        transform.DOMove(endPos, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
