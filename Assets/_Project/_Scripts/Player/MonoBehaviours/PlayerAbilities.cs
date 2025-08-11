using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;
    public AbilityBase ActiveAbility { get; private set; }
    public bool IsInvisible =>
        ActiveAbility != null && ActiveAbility.AbilityType == AbilityType.Invisibility && ActiveAbility.IsActive;


    public void PerformAbility(AbilityType type)
    {
        ActiveAbility = _abilities.FirstOrDefault(x => x.AbilityType == type)?.ActivateAbility(gameObject);
    }

    public void DeactivateAbility(AbilityType type)
    {
        ActiveAbility = _abilities.FirstOrDefault(x => x.AbilityType == type)?.DeactivateAbility(gameObject);
    }

}
