internal sealed class Ability : IAbility
{
    public string Name { get; }
    public int Damage { get; }
    public AbilityType AbilityType { get; }
    public Ability(string name, int damage, AbilityType abilityType)
    {
        Name = name;
        AbilityType = abilityType;
        Damage = damage;
    }
    public override string ToString()
    {
        return Name;
    }
}