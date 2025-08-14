using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMaterialSettings", menuName = "SOs/Player/Material Settings")]

public class PlayerMaterialSettings : ScriptableObject
{
    [Header("Material Settings")]
    [SerializeField] Material originalMaterial;
    [SerializeField] Material invisibleMaterial;

    public Material OriginalMaterial => originalMaterial;
    public Material InvisibleMaterial => invisibleMaterial;
}