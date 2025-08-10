using UnityEngine;

public abstract class Ability : IAbility
{
    protected Ability(AbilityKey abilityKey)
    {
        Key = abilityKey;
    }

    public virtual AbilityType Type { get; }

    public AbilityKey Key { get; }

    public bool IsActive { get; protected set; }

    public abstract void Activate();

    public abstract void Deactivate();
}