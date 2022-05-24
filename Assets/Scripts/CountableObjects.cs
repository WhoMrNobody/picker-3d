using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountableObjects : MonoBehaviour
{
    public PickableObjects pickableObjects;
    public Mesh mesh;
    public float mass;

    bool isCounted;
    new Rigidbody rigidbody;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Material material;

    void Awake() {

        this.gameObject.transform.localScale=pickableObjects.itemScale;
        rigidbody = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        mesh=pickableObjects.itemMesh;
        mass=pickableObjects.itemMass;
        material=pickableObjects.itemMeshMaterial;
        
    }
    void Start()
    {
        isCounted=false;
        meshRenderer.material=material;
        rigidbody.mass=pickableObjects.itemMass;
        meshFilter.mesh=mesh;
        
    }

    void OnCollisonEnter(Collision collision) {

        if(collision.gameObject.CompareTag("passage")){
            Debug.Log(gameObject.name+ " " + isCounted);
            AlreadyCounted(); 
        }
        
    }

    public bool Counted(){

        return isCounted;

    }

    public void AlreadyCounted(){

        isCounted=true;
    }
}
