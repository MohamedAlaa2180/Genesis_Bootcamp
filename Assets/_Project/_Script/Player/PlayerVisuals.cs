using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _invisibleMaterial;

    [SerializeField] private Renderer _renderer;

    private bool _isInitialized = false;
    public bool IsInitialized => _isInitialized;

    public void Init()
    {
        _isInitialized = true;
    }

    #region Event Channels

    [Header("Listen to Event Channels")]
    [SerializeField] private AbilityEventChannelSO OnAbilityActivated;

    [SerializeField] private AbilityEventChannelSO OnAbilityDeactivated;

    #endregion Event Channels

    private async void OnEnable()
    {
        await UniTask.WaitUntil(() => _isInitialized);

        OnAbilityActivated.OnEventRaised += HandleAbilityActivated;
        OnAbilityDeactivated.OnEventRaised += HandleAbilityDeActivated; // Assuming you want to reset visuals on deactivation
    }

    private void OnDisable()
    {
        OnAbilityActivated.OnEventRaised -= HandleAbilityActivated;
        OnAbilityDeactivated.OnEventRaised -= HandleAbilityDeActivated; // Assuming you want to reset visuals on deactivation
    }

    private void HandleAbilityActivated(IAbility ability)
    {
        switch (ability.Type)
        {
            case AbilityType.Invisible:
                SetInvisibleVisuals();
                break;

            case AbilityType.SpeedBoost:
                // Handle SpeedBoost visuals
                break;

            case AbilityType.Shield:
                // Handle Shield visuals
                break;

            case AbilityType.Heal:
                // Handle Heal visuals
                break;
        }
    }

    private void HandleAbilityDeActivated(IAbility ability)
    {
        switch (ability.Type)
        {
            case AbilityType.Invisible:
                ResetVisuals();
                break;

            case AbilityType.SpeedBoost:
                // Handle SpeedBoost visuals
                break;

            case AbilityType.Shield:
                // Handle Shield visuals
                break;

            case AbilityType.Heal:
                // Handle Heal visuals
                break;
        }
    }

    private void SetInvisibleVisuals()
    {
        if (_renderer != null && _invisibleMaterial != null)
        {
            _renderer.material = _invisibleMaterial;
        }
        else
        {
            Debug.LogWarning("Renderer or Invisible Material is not set.");
        }
    }

    private void ResetVisuals()
    {
        if (_renderer != null && _defaultMaterial != null)
        {
            _renderer.material = _defaultMaterial;
        }
        else
        {
            Debug.LogWarning("Renderer or Default Material is not set.");
        }
    }
}