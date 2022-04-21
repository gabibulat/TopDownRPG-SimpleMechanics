using System.Collections.Generic;
using UnityEngine;


public class SpawnItems : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items;
    [SerializeField] private List<GameObject> _placesToSpawn;

    private void Awake() => Spawn();

    public void Spawn()
    {
        int i = 0;
        for (int j = 0; j < _placesToSpawn.Count; j++)
        {
            if (_placesToSpawn[j].transform.childCount == 0)
            {
                var gameobj = Instantiate(_items[i]);
                gameobj.transform.parent = _placesToSpawn[j].transform;
                gameobj.transform.position = _placesToSpawn[j].transform.position;
            }
            i++;
        }
    }
}
