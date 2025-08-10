using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerInputsHandler _playerInputsHandler;

    private Dictionary<AbilityKey, IAbility> _abilities = new Dictionary<AbilityKey, IAbility>();

    private bool _isInitialized = false;

    public bool IsInitialized => _isInitialized;

    #region Events

    public event Action<IAbility> OnAbilityActivated;

    public event Action<IAbility> OnAbilityDeActivated;

    #endregion Events

    public void Init(PlayerInputsHandler playerInputsHandler)
    {
        _playerInputsHandler = playerInputsHandler;
        AddAbilities();
        _isInitialized = true;
    }

    private async void OnEnable()
    {
        await UniTask.WaitUntil(() => _isInitialized);
        if (_playerInputsHandler != null)
        {
            _playerInputsHandler.OnAbilityButonTriggered += ActivateAbility;
        }
    }

    private void OnDisable()
    {
        if (_playerInputsHandler != null)
        {
            _playerInputsHandler.OnAbilityButonTriggered -= ActivateAbility;
        }
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
            OnAbilityActivated.Invoke(_abilities[abilityKey]);
        }
        else
        {
            _abilities[abilityKey].Deactivate();
            OnAbilityDeActivated.Invoke(_abilities[abilityKey]);
        }
    }
}