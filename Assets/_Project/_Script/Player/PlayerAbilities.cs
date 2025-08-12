using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private Dictionary<AbilityKey, IAbility> _abilities = new Dictionary<AbilityKey, IAbility>();

    private bool _isInitialized = false;

    public bool IsInitialized => _isInitialized;

    #region Event Channels

    [Header("Broadcast on Event Channels")]
    [SerializeField] private AbilityEventChannelSO OnAbilityActivated;

    [SerializeField] private AbilityEventChannelSO OnAbilityDeactivated;

    [Header("Listen to Event Channels")]
    [SerializeField] private AbilityKeyEventChannelSO OnAbilityKeyTriggered;

    #endregion Event Channels

    public void Init()
    {
        AddAbilities();
        _isInitialized = true;
    }

    private async void OnEnable()
    {
        await UniTask.WaitUntil(() => _isInitialized);
        OnAbilityKeyTriggered.OnEventRaised += ActivateAbility;
    }

    private void OnDisable()
    {
        OnAbilityKeyTriggered.OnEventRaised -= ActivateAbility;
    }

    private void AddAbilities()
    {
        _abilities.Add(AbilityKey.Q, new InvisibleAbility(AbilityKey.Q));
    }

    private void ActivateAbility(AbilityKey abilityKey)
    {
        var ability = _abilities[abilityKey];
        if (ability == null)
        {
            Debug.LogWarning($"Ability with key {abilityKey} does not exist.");
            return;
        }
        if (!ability.IsActive)
        {
            _abilities[abilityKey].Activate();
            OnAbilityActivated.RaiseEvent(_abilities[abilityKey]);
        }
        else
        {
            _abilities[abilityKey].Deactivate();
            OnAbilityDeactivated.RaiseEvent(_abilities[abilityKey]);
        }
    }
}