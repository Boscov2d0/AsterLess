internal interface IAbility
{
    string Name { get; }
    int Damage { get; }
    AbilityType AbilityType { get; }
}