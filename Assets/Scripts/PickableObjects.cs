using UnityEngine;

[CreateAssetMenu(fileName ="New Pickable Object", menuName ="Create New Pickable Object")]
public class PickableObjects : ScriptableObject
{
    public Mesh itemMesh;
    public Material itemMeshMaterial;
    public float itemMass;
    public Vector3 itemScale;

    
}
