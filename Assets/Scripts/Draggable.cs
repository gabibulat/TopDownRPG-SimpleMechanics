using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] public Image _draggableImage;
    [SerializeField] private TMP_Text _draggableAmount;
    [SerializeField] private GameObject _uiInventory;
    [SerializeField] private GameObject _uiEqupment;
    private ItemSlotEquipment _itemSlotEquipment;
    private ItemSlot _itemSlot;
    private bool isDragged = false;

    public Item GetDraggableItem() => _item;
    public ItemSlotEquipment GetItemSlotEquipment() => _itemSlotEquipment;
    public void SetItemSlotEquipment(ItemSlotEquipment slot) => _itemSlotEquipment = slot;
    public ItemSlot GetItemSlot() => _itemSlot;
    public void SetItemSlot(ItemSlot slot) => _itemSlot = slot;

    public void BeginDrag(Item item)
    {
        isDragged = true;
        _item = item;
        _draggableImage.sprite = _item.GetItemSprite();
        _draggableImage.enabled = true;
        if (_item.GetItemType() == Item.ItemTypes.Stackable)
        {
            _draggableAmount.text = _item.GetItemAmount().ToString();
            _draggableAmount.enabled = true;
        }
    }
    public void EndDrag()
    {
        isDragged = false;
        if (_itemSlot != null)
        {
            _itemSlot.GetItemSlotImage().enabled = true;
            _itemSlot.GetItemAmount().enabled = true;
            _itemSlot = new ItemSlot();
        }
        if (_itemSlotEquipment != null)
        {
            _itemSlotEquipment.GetItemSlotImage().enabled = true;
            _itemSlotEquipment = new ItemSlotEquipment();
        }
        _item = new Item();
        _draggableImage.enabled = false;
        _draggableAmount.enabled = false;
    }

    void Update()
    {
        if (!_uiInventory.activeInHierarchy && !_uiEqupment.activeInHierarchy) EndDrag();

        if (isDragged)
        {
            if (Touchscreen.current == null) _draggableImage.transform.position = Mouse.current.position.ReadValue();
            else _draggableImage.transform.position = Touchscreen.current.position.ReadValue();
        }
    }
}
