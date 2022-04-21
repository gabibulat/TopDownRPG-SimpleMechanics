using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class ItemSlotEquipment : ItemSlot
{
    [SerializeField] private PlayerEquipment _playerEquipment;
    [SerializeField] private Player _player;
    [SerializeField] private Item.EquipItemTypes type;
    private int distance;

    public void Start() => _player.OnPlayerMove += PlayerMoved;
    public Item.EquipItemTypes GetEquipmentType() => type;

    private void PlayerMoved(object sender, EventArgs e)
    {
        if (Item.GetItemType() != Item.ItemTypes.None)
        {
            if (Item.GetCurrentDurability() > 0 && distance != Mathf.RoundToInt(Vector2.Distance(Item.GetStartPlayerPosition(), _player.transform.position)))
            {
                Item.SetCurrentDurability(Item.GetCurrentDurability() - Mathf.RoundToInt(Vector2.Distance(Item.GetStartPlayerPosition(), _player.transform.position)));
                distance = Mathf.RoundToInt(Vector2.Distance(Item.GetStartPlayerPosition(), _player.transform.position));
            }
            else if (Item.GetCurrentDurability() <= 0)
            {
                _playerEquipment.Remove(Item, _itemSlotImage);
                Item = new Item();
                _itemToolTip.HideTooltip();
            }
        }
    }

    public void Equip(Item item)
    {
        if (Item.GetItemType() != Item.ItemTypes.None)
        {
            _playerInventory.AddItemToInventory(Item);
            RemoveEquiped();
            _playerEquipment.Remove(Item, _itemSlotImage);
        }
        passItem(item);
        item.SetStartPlayerPosition(new Vector2(_player.transform.position.x, _player.transform.position.y));
        _playerEquipment.PassItem(item, _itemSlotImage);
        RemoveItemFromInventory(item);

        AnalyticsResult analyticsResult = Analytics.CustomEvent("Item Equiped", new Dictionary<string, object>{
                    { "ItemName", item.GetItemName() },
                    { "Item slot", type + " equipment slot"}
                });
        Debug.Log("AnalyticsResult of event 'Item Equiped': " + analyticsResult);
    }

    public void RemoveEquiped()
    {
        _playerEquipment.Remove(Item, _itemSlotImage);
        Item = new Item();
    }

    public override void OnLeftClick()
    {
        if (_draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None && Item.GetItemType() != Item.ItemTypes.None)
        {
            _draggable.BeginDrag(Item);
            _draggable.SetItemSlotEquipment(this);
            _itemSlotImage.enabled = false;
        }
        else
        {
            if (_draggable.GetDraggableItem().GetEquipItemType() != Item.EquipItemTypes.None && _draggable.GetDraggableItem().GetEquipItemType() == type)
            {
                Equip(_draggable.GetDraggableItem());
                _draggable.EndDrag();
            }
        }
    }

    public override void OnRightClick()
    {
        if (Item.GetEquipItemType() != Item.EquipItemTypes.None && _draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None)
        {
            _playerInventory.AddItemToInventory(Item);
            RemoveEquiped();
        }
    }
}
