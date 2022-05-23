using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUp : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0f, 230f * Time.deltaTime, 0f);
    }
    void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")){

            transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InExpo);
            
        }
        
    }



}
