using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceMoveScript : MonoBehaviour
{

    public float moveDistance = 1.0f; // �㉺�ړ��̋���
    public float duration = 2.0f; // �A�j���[�V�����̎���

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        AnimateSprite();
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

    // Update is called once per frame

}
