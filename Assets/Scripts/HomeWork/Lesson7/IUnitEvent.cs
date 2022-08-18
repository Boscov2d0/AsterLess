using System;

public interface IUnitEvent
{
    public event Action<int> Crash;
}