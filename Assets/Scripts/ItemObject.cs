using UnityEngine;
using System.Collections.Generic;
using System;
public class ItemObject : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        item.SetCurrentDurability(item.GetMaxDurability());
        if (item._additionNames.Count == item._additionValues.Count && item.GetItemType()==Item.ItemTypes.Equipable)
        {
            for (int i = 0; i < item._additionNames.Count; i++)
            {
                if (item._additionValues[i].Contains("%")) {
                    item._additionValues[i]=item._additionValues[i].Replace("%", string.Empty);
                    item._additionValues[i] = (float.Parse(item._additionValues[i]) *0.01).ToString();
                }
                item.additions.Add(item._additionNames[i], float.Parse(item._additionValues[i]));
            }
        }
    }
}
