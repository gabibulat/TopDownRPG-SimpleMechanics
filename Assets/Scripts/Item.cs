using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Item 
{
    public enum ItemTypes
    {
        None = 0,
        PermanentUsage,
        Equipable,
        Stackable,
        NonStackable

    }
    public enum EquipItemTypes
    {
        None = 0,
        Head,
        Legs,
        Weapon,
        Shield,
        Body,
        RingR,
        RingL
    }

    [SerializeField] protected ItemTypes _itemType;
    [SerializeField] protected string _itemName;
    [SerializeField] protected Sprite _itemSprite;
    protected int _amount = 1;

    [Space]
    [Header("Consumable item")]
    [SerializeField] protected bool _isConsumable;
    [SerializeField] protected string _statAffected;
    [Header("AffectedValues: value, hold duration, over time, per time")]
    [SerializeField] protected bool _isPersentage;
    [SerializeField] protected List<float> _affectedValues;

    [Space]
    [Header("Stackable items")]
    [SerializeField] protected int _stackLimit;
    protected int _stackID;

    [Space]
    [Header("Equipable items")]
    [SerializeField] protected EquipItemTypes _equipItemType;
    [SerializeField] protected int _maxDurability;
    protected int _currentDurability;
    protected Vector2 _playerPosition;
    [SerializeField] public List<string> _additionNames;
    [SerializeField] public List<string> _additionValues;

    public Dictionary<String, float> additions= new Dictionary<String, float>();

    public ItemTypes GetItemType() => _itemType;
    public string GetItemName() => _itemName;
    public Sprite GetItemSprite() => _itemSprite;
    public bool GetIsConsumable() => _isConsumable;
    public int GetStackLimit() => _stackLimit;
    public EquipItemTypes GetEquipItemType() => _equipItemType;
    public int GetStackID() => _stackID;
    public void SetStackID(int id) => _stackID = id;
    public object Clone() => this.MemberwiseClone();
    public int GetMaxDurability() => _maxDurability;
    public int GetCurrentDurability() => _currentDurability;
    public void SetCurrentDurability(int cd) => _currentDurability=cd;
    public int GetItemAmount() => _amount;
    public void SetItemAmount(int amount) => _amount = amount;
    public Vector2 GetStartPlayerPosition() => _playerPosition;
    public void SetStartPlayerPosition(Vector2 p) => _playerPosition=p;
    public string GetStatAffected() => _statAffected;
    public List<float> GetListAffectedValues() => _affectedValues;
    public bool GetPersentage() => _isPersentage;

}
