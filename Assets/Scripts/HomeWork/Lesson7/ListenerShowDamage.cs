using UnityEngine;
using UnityEngine.UI;
public class ListenerShowDamage
{
    private Text _info;

    public ListenerShowDamage() 
    {
        _info = Resources.Load<Text>("UI/Info");
    }

    public void Add(Asteroid value)
    {
        value.ShowName += ValueOnOnHitChange;
    }
    public void Remove(Asteroid value)
    {
        value.ShowName -= ValueOnOnHitChange;
    }
    private void ValueOnOnHitChange(string name)
    {
        _info.text = name;
    }
}