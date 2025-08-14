using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlayerVisualHandler : MonoBehaviour
{
    Renderer playerRenderer;
    [SerializeField] PlayerMaterialSettings materialSettings;

    void Awake() => playerRenderer = GetComponent<Renderer>();

    public void SetVisible(bool isVisible) => playerRenderer.material = isVisible ? materialSettings.OriginalMaterial : materialSettings.InvisibleMaterial;
}