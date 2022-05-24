using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Passage : MonoBehaviour
{
    [SerializeField] TMP_Text CounterText_;

    public bool isPlatformLifted_=false;
    public int achievePoint_;
    public bool isCounting_=false;
    int pickCount;


    void Update()
    {
        PassActivated();
    }

    void OnCollisionEnter(Collision pick) {

        if(pick.gameObject.CompareTag("pick")){
            
            pick.gameObject.GetComponent<CountableObjects>().AlreadyCounted();
            isCounting_=true;
            isCounting();

                if(pick.gameObject.GetComponent<CountableObjects>().Counted()){
                    this.pickCount++;
                    ScoreManager.instantiate.AddPoint();
                    CounterText_.text= pickCount.ToString();
                    pick.gameObject.GetComponent<Collider>().enabled=false;
                    pick.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InElastic).OnComplete(()=>{

                        pick.gameObject.GetComponent<CountableObjects>().Counted();
                        Destroy(pick.gameObject, 0.2f);

                    });
                }

        }
 
    }

    public bool MoveOn(){

        return isPlatformLifted_ = true;

    }

    public bool isCounting(){

        return isCounting_;
    }

    public int points(){

        return pickCount;
    }

    public void PassActivated(){

        if(pickCount>=achievePoint_){

            transform.DOMoveY(0, 0.1f).SetEase(Ease.Flash);
            isCounting_=false;
            isPlatformLifted_=true;
            Invoke(nameof(MoveOn), 2.5f);
        }

    }

}
