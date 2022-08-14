using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Data objects/Dictionary Storage Object")]
public class DictionaryScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<int> _key = new List<int>();
    [SerializeField]
    private List<string> _value = new List<string>();

    public List<int> Key { get => _key; set => _key = value; }
    public List<string> Value { get => _value; set => _value = value; }
}