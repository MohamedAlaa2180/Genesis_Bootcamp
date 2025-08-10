public interface IAbility
{
    public AbilityType Type { get; }
    public AbilityKey Key { get; }
    public bool IsActive { get; }

    public void Activate();

    public void Deactivate();
}

public enum AbilityType
{
    None,
    Invisible,
    SpeedBoost,
    Shield,
    Heal
}

public enum AbilityKey
{
    None,
    Q,
    W,
    E
}