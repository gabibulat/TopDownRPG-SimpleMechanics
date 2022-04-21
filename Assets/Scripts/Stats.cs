using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private Dictionary<string, Text> _statsText=new Dictionary<string, Text>();

    public void AddStat(Dictionary<string, int> _stats)
    {
        for(int i=0;i< _stats.Count; i++)
        {
            var gameobj = new GameObject(_stats.Keys.ElementAt(i));
            gameobj.transform.parent = gameObject.transform;
            var text = gameobj.AddComponent<Text>();
            text.text = _stats.Keys.ElementAt(i) + ": " + _stats.Values.ElementAt(i).ToString();
            _statsText.Add(_stats.Keys.ElementAt(i), text);
            text.fontSize = 15;
            text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }      
    }

    public void UpdateStats(string _name, int _value) {
        _statsText[_name].text = _name+ ": " + _value.ToString();
    }
}
