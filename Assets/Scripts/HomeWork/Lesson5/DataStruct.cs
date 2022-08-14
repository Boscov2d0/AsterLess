using System;

[Serializable]
public struct UnitData
{
    public string type;
    public string health;

    public UnitData(string _type, string _health)
    {
        type = _type;
        health = _health;
    }
}

[Serializable]
public struct UnitsData
{
    public UnitData unit;
}
[Serializable]
public struct UnitsArray
{
    public UnitsData[] objects;
}