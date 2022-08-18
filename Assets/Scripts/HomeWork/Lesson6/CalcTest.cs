using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CalcTest : MonoBehaviour
{
    string _s = "(54 + 2 * 3) * (3 - 1)";
    List<List<string>> result = new List<List<string>>();
    private void Start()
    {
        string rs = _s.Replace(" ", "");
        //result = 
            Bracket(rs);
        List<string> toOp = new List<string>();
        /*
        for (int i = 0; i < result[0].Length; i++) 
        {
            string ss = result[0];
            toOp[i] = "sd";// ss[i];
        }
        OpenBreket(result);
        */
    }

    private void Bracket(string s)
    {
        string[] result = s.Split('(', ')');
        List<string> ll = new List<string>(result);
        ll.RemoveAt(0);
        ll.RemoveAt(ll.Count - 1);

        List<List<string>> byteList = new List<List<string>>();

        foreach (var i in ll)
        {
            Debug.Log(i[0]);
        }


        //string rs = l.Replace(" ", "");


        /*
        for (int i = 0; i < result.Length; i++) 
        {
            byteList.Add(ll);
        }
        
        for (int i = 0; i < byteList.Count; i++)
        {
            for (int j = 0; j < ll.Count; j++) 
            {
                byteList[i].Add(ll[j]);
            }
        }
        
        foreach (var item in byteList) 
        {
            Debug.Log("item " + item);

            foreach (var r in item) 
            {
                Debug.Log("r " + r);
            }
            
        }
        */
        //byteList.RemoveAt(0);
        //byteList.RemoveAt(byteList.Count - 1);
        //string rs = result.Replace(" ", "");

        //return byteList;
    }
    private void OpenBreket2(string str)
    {
        //string[] result = str.Split('*', '/', '+', '-');

        List<int> indexes = new List<int>();
        for (int i = 0; i < str.Length; i++) 
        {
            if (str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-') 
            {
                indexes.Add(i);
            }
        }

        List<string> operations = new List<string>();
        for (int i = 0; i < indexes.Count; i++) 
        {
            operations.Add(str[indexes[i]].ToString());
        }
        foreach (var sub in operations)
        {
            Debug.Log($"Operations: {sub}");
        }
    }
    private static bool FindMultiplySymbol(char obj)
    {
        return obj == '*';
    }
    private static bool FindDevideSymbol(char obj)
    {
        return obj == '/';
    }

    private void Clean(List<string> strin, int index, float value)
    {
        Debug.Log(value);
        string number = value.ToString();
        strin.RemoveAt(index - 1);
        strin.RemoveAt(index + 1);
        strin[index] = number;

        //List<string> s = new List<string>(strin);
        
        //char[] sss = number.ToCharArray();
        //var r3 = strin.Remove(index - 1);
        //r3 = strin.Remove(index + 1);
        //r3[index] = number;
        //r3 += number.ToString();
        OpenBreket(strin);
        return;
    }
    private void OpenBreket(List<string> str)
    {

        //char[] strin = str.ToCharArray();
        bool _findOperation = false;
        int _multiplySymbolPosition = 0;
        int _devideSymbolPosition = 0;
        float _value = 0;
        int _indexOfSymbol = 0;

        foreach (var item in str) 
        {
            if (item.Contains('*'))
            {
                //Predicate<char> predicate = FindMultiplySymbol;
                _multiplySymbolPosition = item.IndexOf('*');
                //Debug.Log(" _multiplySymbolPosition " + _multiplySymbolPosition);
                //_multiplySymbolPosition = Array.FindIndex<char>(strin, 0, predicate);
                _findOperation = true;
            }
            if (item.Contains('/'))
            {
                //Predicate<char> predicate = FindDevideSymbol;
                _multiplySymbolPosition = item.IndexOf('/');
                //_devideSymbolPosition = Array.FindIndex<char>(strin, 0, predicate);
                _findOperation = true;
            }
        }

        if (_multiplySymbolPosition != 0 && _devideSymbolPosition != 0)
        {
            if (_multiplySymbolPosition > _devideSymbolPosition)
            {
                _value = Devided(float.Parse(str[_devideSymbolPosition - 1]), float.Parse(str[_devideSymbolPosition + 1]));
                _indexOfSymbol = _devideSymbolPosition;
                Clean(str, _indexOfSymbol, _value);
                return;
            }
            else
            {
                _value = Multiply(float.Parse(str[_multiplySymbolPosition - 1]), float.Parse(str[_multiplySymbolPosition + 1]));
                _indexOfSymbol = _multiplySymbolPosition;
                Clean(str, _indexOfSymbol, _value);
                return;
            }
        }
        if (_multiplySymbolPosition == 0 && _devideSymbolPosition != 0)
        {
            _value = Devided(float.Parse(str[_devideSymbolPosition - 1]), float.Parse(str[_devideSymbolPosition + 1]));
            _indexOfSymbol = _devideSymbolPosition;
            Clean(str, _indexOfSymbol, _value);
            return;
        }
        else if (_multiplySymbolPosition != 0 && _devideSymbolPosition == 0)
        {
            _value = Multiply(float.Parse(str[_multiplySymbolPosition - 1]), float.Parse(str[_multiplySymbolPosition + 1]));
            _indexOfSymbol = _multiplySymbolPosition;
            Clean(str, _indexOfSymbol, _value);
            return;
        }
        
        if (str.Count > 1)
        {
            if (str[1] == "+")
            {
                _value = Plus(float.Parse(str[0]), float.Parse(str[2]));
                _indexOfSymbol = 1;
                _findOperation = true;
                Clean(str, _indexOfSymbol, _value);
                return;
            }
            if (str[1] == "-")
            {
                _value = Minus(float.Parse(str[0]), float.Parse(str[2]));
                _indexOfSymbol = 1;
                _findOperation = true;
                Clean(str, _indexOfSymbol, _value);
                return;
            }
        }
        if (!_findOperation)
        {
            return;
        }
    }

    private float Minus(float a, float b)
    {
        return a - b;
    }
    private float Plus(float a, float b)
    {
        return a + b;
    }
    private float Multiply(float a, float b)
    {
        return a * b;
    }
    private float Devided(float a, float b)
    {
        return a / b;
    }
}
