using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private List<Sprite> _itemSlotImagePlaceholder;
    private Dictionary<string, float> _statsAditions = new Dictionary<string, float>();
    public event EventHandler OnAddEquip;
    public event EventHandler OnRemoveEquip;

    public Dictionary<string, float> GetStatsAditions() => _statsAditions;
    public void PassItem(Item _item, Image itemSlotImage)
    {
        _statsAditions.Clear();
        foreach (var pair in _item.additions) _statsAditions.Add(pair.Key, pair.Value);
        itemSlotImage.sprite = _item.GetItemSprite();
        itemSlotImage.color = new Color(1, 1, 1, 1);

        OnAddEquip?.Invoke(this, EventArgs.Empty);
    }

    public void Remove(Item _item, Image itemSlotImage)
    {
        _statsAditions.Clear();
        foreach (var pair in _item.additions) _statsAditions.Add(pair.Key, pair.Value);
        itemSlotImage.sprite = _itemSlotImagePlaceholder[(int)_item.GetEquipItemType()];
        itemSlotImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);

        OnRemoveEquip?.Invoke(this, EventArgs.Empty);

    }

}
