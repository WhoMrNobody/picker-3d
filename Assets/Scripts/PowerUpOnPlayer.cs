using UnityEngine;

public class PowerUpOnPlayer : MonoBehaviour
{
    BoxCollider boxCollider_;

    void Awake(){

        boxCollider_= GetComponent<BoxCollider>();

    }
    void Update()
    {
        transform.Rotate(0f, 230f * Time.deltaTime, 0f);
    }

    void OnCollisionStay(Collision collision) {

        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("The player hit by the powerUps ups upssss");
            boxCollider_.isTrigger=true;
        }
        
    }

}
