using UnityEngine;

public class InvisibleAbility : Ability
{

    public InvisibleAbility(AbilityKey abilityKey) : base(abilityKey)
    {
    }

    public override AbilityType Type => AbilityType.Invisible;

    public override void Activate()
    {
        Debug.Log("Invisible Ability Activated");
        IsActive = true;
    }

    public override void Deactivate()
    {
        IsActive = false;
        Debug.Log("Invisible Ability Deactivated");
    }
}