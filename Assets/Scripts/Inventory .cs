using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler,IPointerClickHandler
{
    [SerializeField] public GameObject _itemSlotInventory;
    [SerializeField] public Transform _content;
    [SerializeField] private Draggable _draggable;
    [SerializeField] private RectTransform _rectTransform;
    private List<Item> _itemList;
    private event EventHandler OnItemListChanged;
    private Transform _itemImage;
    private bool isPickedUp = false;
    private InputController _inputController;
    private bool isPointer;
    private ItemSlot itemSlotClass;

    private void Awake()
    {
        _inputController = new InputController();
        _inputController.Enable();
        _inputController.UI.LongPress.canceled += _ => LongPressCancled();
    }

    public bool GetIsPickedUp() => isPickedUp;

    private void LongPressCancled()
    {
        if (isPointer) DropInInventory();
        isPointer = false;
    }

    private void DropInInventory() {
        if (_draggable.GetDraggableItem().GetItemType() != Item.ItemTypes.None)
        {
            if (!_itemList.Contains(_draggable.GetDraggableItem()))
            {
                AddItemToInventory(_draggable.GetDraggableItem());
                _draggable.GetItemSlotEquipment().RemoveEquiped();
                _draggable.GetItemSlotEquipment().GetItemSlotImage().enabled = true;
                _draggable.EndDrag();
            }
            else _draggable.EndDrag();
        }
    }

    public void SetInventory()
    {
        _itemList = new List<Item>();
        _itemImage = _itemSlotInventory.transform.GetChild(0);
        OnItemListChanged += Inventory_OnItemListChanged;
    }

    virtual public void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        foreach (Transform child in _content)
        {
            if (child == _itemSlotInventory.transform) continue;
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _itemList.Count; i++)
        {
            _itemImage.gameObject.GetComponent<Image>().sprite = _itemList[i].GetItemSprite();
            Transform itemSlot = Instantiate(_itemSlotInventory.transform, _content);
            itemSlotClass = itemSlot.GetComponent<ItemSlot>();
            Transform itemImage = itemSlotClass.transform.Find("ItemImage");
            Transform amountText = itemImage.transform.Find("Amount");

            if (_itemList[i].GetItemType() == Item.ItemTypes.Stackable)
            {
                amountText.gameObject.SetActive(true);
                TMP_Text text = amountText.gameObject.GetComponent<TMP_Text>();
                text.text = _itemList[i].GetItemAmount().ToString();

                if (_itemList[i].GetStackLimit() > 0)
                {
                    float percentage = (float)_itemList[i].GetItemAmount() / (float)_itemList[i].GetStackLimit();
                    if (percentage > 0.5f) itemSlot.GetComponent<Image>().color = new Color(0, 1, 0, 0.5f);
                    else itemSlot.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
                }
            }
            else amountText.gameObject.SetActive(false); 
            itemSlotClass.passItem(_itemList[i]);
            itemSlotClass.passUIinventory(gameObject);
        }
    }

    public void AddItemToInventory(Item item)
    {
        if (item.GetItemType() != Item.ItemTypes.None)
        {
            if (item.GetItemType() == Item.ItemTypes.Stackable && FindItem(item) >= 0)
            {
                // if stack limit is unlimited or not reached limit
                if (item.GetStackLimit() == 0 || _itemList[FindItem(item)].GetItemAmount() < item.GetStackLimit())
                {
                    _itemList[FindItem(item)].SetItemAmount(_itemList[FindItem(item)].GetItemAmount() + 1);
                    OnItemListChanged?.Invoke(this, EventArgs.Empty);
                    isPickedUp = true;
                }
                // if stack limit is reached
                else
                {
                    Debug.Log("Cannot pick up, reached item stack limit");
                    isPickedUp = false;
                }
            }
            else
            {
                _itemList.Add(item);
                isPickedUp = true;
                OnItemListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }

    public void RemoveItemFromInventory(Item item)
    {
        if (item.GetItemType() == Item.ItemTypes.Stackable && item.GetItemAmount() >= 2)
        {
            if (FindItem(item) >= 0) _itemList[FindItem(item)].SetItemAmount(_itemList[FindItem(item)].GetItemAmount() - 1);
        }
        else _itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public int FindItem(Item _item) => _itemList.FindIndex(m => m.GetItemName() == _item.GetItemName() && m.GetStackID() == _item.GetStackID());

    public void OnPointerEnter(PointerEventData eventData) => isPointer = true;

    public void OnPointerExit(PointerEventData eventData) => isPointer = false;

    public void OnPointerClick(PointerEventData eventData) => DropInInventory();
}
