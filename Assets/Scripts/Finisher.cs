using UnityEngine;
using DG.Tweening;

public class Finisher : MonoBehaviour
{

    int pickCount;

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("pick")){

            other.gameObject.GetComponent<CountableObjects>().AlreadyCounted();

            if(other.gameObject.GetComponent<CountableObjects>().Counted()){
                this.pickCount++;
                ScoreManager.instantiate.AddPoint();
                other.gameObject.GetComponent<SphereCollider>().enabled=false;
                    other.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InElastic).OnComplete(()=>{

                        other.gameObject.GetComponent<CountableObjects>().Counted();
                        Destroy(other.gameObject, 0.2f);

                    });

            }

        }
        
    }
}
