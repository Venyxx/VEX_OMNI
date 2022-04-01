using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UITweening : MonoBehaviour { 
[SerializeField] private Transform _StartButton;
[SerializeField] private float _cyclelength = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector2(0, 2), _cyclelength).SetEase(Ease.InBounce);
        //transform.DOScale(_StartButton, new Vector3(2, _cyclelength));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
