using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Invisible")]
public class Invisible : AbilityBase
{
    private bool _isOnCoolDown;
    private bool _isActive;
    private float _cooldownTimer;

    [SerializeField] private float _cooldown;
    [SerializeField] private float _duration;
    [SerializeField] private AbilityType _abilityType;

    public override float Cooldown => _cooldown;
    public override float CooldownTimer { get { return _cooldownTimer; } set { _cooldownTimer = value; } }
    public override float Duration => _duration;
    public override bool IsOnCooldown => _isOnCoolDown;
    public override bool IsActive => _isActive;
    public override AbilityType AbilityType => _abilityType;    

    public override AbilityBase ActivateAbility(GameObject go)
    {
        if (_isActive) {
            return DeactivateAbility(go); 
        }
        go.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.25f);
        go.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
        _isActive = true;
        return this;
    }

    public override AbilityBase DeactivateAbility(GameObject go)
    {
        go.GetComponent<Renderer>().material.SetFloat("_Alpha", 1);
        go.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.On;
        _isActive = false;
        return null;
    }

    public override void ResetCooldown()
    {
        _cooldownTimer = _cooldown;
        _isOnCoolDown = false;
    }

    public override void StartCooldown()
    {
        _isOnCoolDown = true;
    }
}

