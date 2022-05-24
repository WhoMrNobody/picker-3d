using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectPushing : MonoBehaviour
{
    [SerializeField] float ForceMagnitide_;
    
    Passage passage;
    
    void Awake() {

        passage = FindObjectOfType<Passage>();
        
    }
    void OnCollisionStay(Collision coll) {

         Rigidbody rigidbody = coll.collider.attachedRigidbody;
         

        if(rigidbody != null){

            
            Vector3 forceDirection = coll.gameObject.transform.position + transform.position;
            forceDirection.y=0;
            forceDirection.Normalize();

            rigidbody.velocity = forceDirection * ForceMagnitide_;
        
        }

    }
}
