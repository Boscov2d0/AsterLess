using System.Collections;
using System.Collections.Generic;

internal interface IUnit
{
    IAbility this[int index] { get; }
    int MaxDamage { get; }
    IEnumerable<IAbility> GetAbility();
    IEnumerator GetEnumerator();
    IEnumerable<IAbility> GetAbility(AbilityType index);
}