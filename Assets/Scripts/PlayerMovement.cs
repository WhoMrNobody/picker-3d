using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PickerSpeed_;
    [SerializeField] float MoveSpeed_;
    [SerializeField] GameObject[] PowerUps_;

    Rigidbody rg;
    Vector3 direction;
    Touch touch;
    float movementVector;
    bool powerTaken=false;

    void Awake() {

        rg=GetComponent<Rigidbody>();
        
    }

    void Update(){

       if(GameController.gameControllerInstantiate.passage.isPlatformLifted_){ 

            this.rg.isKinematic=false; 
       }
            

    }

    void FixedUpdate()
    {  
        if(GameController.gameControllerInstantiate.isGameStarted==true){
            PickerMoveForward();
        }

        if(rg.velocity.z > PickerSpeed_){

            PickerMoveForward();

        }

        if(Input.touchCount>0){

            touch = Input.GetTouch(0);
            
            if(touch.phase==TouchPhase.Moved){

                GameController.gameControllerInstantiate.isGameStarted=true;
                GameController.gameControllerInstantiate.PlayText_.enabled=false;

                rg.isKinematic=false;
                

                foreach (Touch touch in Input.touches)
                {
                    movementVector = touch.deltaPosition.x * MoveSpeed_;
                }

                rg.AddForce(new Vector3(movementVector,0,0), ForceMode.Impulse);
                direction.x = MoveSpeed_;

            }

        }

        
    }

    void OnTriggerEnter(Collider coll) {

        if(coll.gameObject.CompareTag("passageGate")){

            rg.isKinematic=true;

            if(powerTaken==true){
                
                for (int i = 0; i <= PowerUps_.Length - 1; i++)
                {
                    PowerUps_[i].gameObject.SetActive(false);
                }
            }
            
        }

        if(coll.gameObject.CompareTag("Finish")){
            
            GameController.gameControllerInstantiate.isLevelCompleted=true;
            rg.isKinematic=true;
            for (int i = 0; i <= PowerUps_.Length - 1; i++)
            {
                PowerUps_[i].SetActive(false);
            }
            
        }

        if(coll.gameObject.CompareTag("powerUp")){

            for (int i = 0; i <= PowerUps_.Length - 1; i++)
            {
                PowerUps_[i].SetActive(true);
                powerTaken=true;
            }

        }

        if(coll.gameObject.CompareTag("TheLastFinish")){

            GameController.gameControllerInstantiate.GameFinished();

        }
        
    }

    public void PickerMoveForward(){

        rg.velocity= new Vector3(rg.velocity.x, rg.velocity.y, PickerSpeed_);
    }

    public void PickerMover(){

        rg.isKinematic=false;
        float rawXPos = transform.position.x + touch.deltaPosition.x * MoveSpeed_ ;
        transform.position = new Vector3(rawXPos, transform.position.y,  transform.position.z);
        direction.x = MoveSpeed_;

        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(transform.position.x, -15.80f, 19.50f);
        transform.position = currentPos;

        
    }
    
}
