using System.Collections.Generic;
using UnityEngine;

public class DictionaryTest : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private DictionaryScriptableObject _dictionaryData;

    private Dictionary<int, string> _dictionary = new Dictionary<int, string>();

    [Header("Dictionary key")]
    private List<int> _key = new List<int>();
    [Header("Dictionary value")]
    private List<string> _value = new List<string>();

    public bool ModifyValues;

    public void OnAfterDeserialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        if (ModifyValues == false) 
        {
            _key.Clear();
            _value.Clear();
            for (int i = 0; i < Mathf.Min(_dictionaryData.Key.Count, _dictionaryData.Value.Count); i++) 
            {
                _key.Add(_dictionaryData.Key[i]);
                _value.Add(_dictionaryData.Value[i]);
            }
        }
    }

    public void DeserializeDictioanry()
    {
        _dictionary = new Dictionary<int, string>();
        _dictionaryData.Key.Clear();
        _dictionaryData.Value.Clear();
        for (int i = 0; i < Mathf.Min(_key.Count, _value.Count); i++)
        {
            _dictionaryData.Key.Add(_key[i]);
            _dictionaryData.Value.Add(_value[i]);
            _dictionary.Add(_key[i], _value[i]);
        }
        ModifyValues = false;
    }
}