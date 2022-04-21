using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class ItemSlot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] protected Image _itemSlotImage;
    [SerializeField] protected PlayerInventory _playerInventory;
    protected ItemTooltip _itemToolTip;
    protected Draggable _draggable;
    protected ItemSlotEquipment[] _itemSlotsEquipment;
    protected bool isHovering;
    private Buff _buff;
    private TMP_Text _itemAmount;
    private bool isClicked = false;
    private Split _splitWindow;
    private InputController _inputController;
    public Item Item;

    private void Awake()
    {
        isHovering = false;
        _itemToolTip = Resources.FindObjectsOfTypeAll<ItemTooltip>()[0];
        _splitWindow = Resources.FindObjectsOfTypeAll<Split>()[0];
        _itemSlotsEquipment = Resources.FindObjectsOfTypeAll<ItemSlotEquipment>();
        _draggable = Resources.FindObjectsOfTypeAll<Draggable>()[0];
        _buff = Resources.FindObjectsOfTypeAll<Buff>()[0];
        _itemSlotImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        if (_itemSlotImage.transform.childCount > 0) _itemAmount = _itemSlotImage.transform.GetChild(0).GetComponent<TMP_Text>();
       
        _inputController = new InputController();
        _inputController.Enable();
        _inputController.UI.LongPress.performed += _ => LongPressPerformed();
        _inputController.UI.DoubleTap.performed += _ => DoubleTapPerformed();
        _inputController.UI.SplitStackable.performed += _ => SplitStackablePerformed();
    }


    private void SplitStackablePerformed()
    {
        if (isHovering)
        {
            _splitWindow.gameObject.SetActive(true);
            _splitWindow.PassItem(Item);
        }
    }

    private void DoubleTapPerformed()
    {
        if (isClicked && _draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None)
        {
            OnRightClick();
            OnMiddleClick();
        }
        isClicked = false;
    }

    private void LongPressPerformed()
    {
        if (isClicked && _draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None) OnLeftClick();
        isClicked = false;
    }

    public void passUIinventory(GameObject playerInventory) { _playerInventory = playerInventory.GetComponent<PlayerInventory>(); }

    public void passItem(Item item) { this.Item = item; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item.GetItemType() == Item.ItemTypes.Stackable) isHovering = true;
        if (Item.GetItemType() != Item.ItemTypes.None) _itemToolTip.ShowTooltip(Item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Item.GetItemType() != Item.ItemTypes.None) _itemToolTip.HideTooltip();
        isHovering = false;
    }

    public void RemoveItemFromInventory(Item item) => _playerInventory.RemoveItemFromInventory(item);

    virtual public void OnLeftClick()
    {
        if (_draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None)
        {
            _draggable.BeginDrag(Item);
            _itemSlotImage.enabled = false;
            _itemAmount.enabled = false;
            _draggable.SetItemSlot(this);
        }
        else if (_draggable.GetItemSlot() == this) _draggable.EndDrag();
    }

    private void OnMiddleClick()
    {
        if (Item.GetIsConsumable() && _draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None)
        {
            Instantiate(_buff).gameObject.transform.parent = _draggable.gameObject.transform.parent;
            _buff.AddBuff(Item);
            _playerInventory.RemoveItemFromInventory(Item);

            AnalyticsResult analyticsResult = Analytics.CustomEvent("Item consumed", new Dictionary<string, object>{
                    { "ItemName", Item.GetItemName() },
                    { "Item type:" , Item.GetItemType()}
                });
            Debug.Log("AnalyticsResult of event 'Item consumed': " + analyticsResult);
        }
    }

    virtual public void OnRightClick()
    {
        if (Item.GetEquipItemType() != Item.EquipItemTypes.None && _draggable.GetDraggableItem().GetItemType() == Item.ItemTypes.None)
        {
            for (int i = 0; i < _itemSlotsEquipment.Length; i++) if (_itemSlotsEquipment[i].GetEquipmentType() == Item.GetEquipItemType()) _itemSlotsEquipment[i].Equip(Item);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Mouse only
        if (eventData.button == PointerEventData.InputButton.Left && Touchscreen.current == null) OnLeftClick();
        else if (eventData.button == PointerEventData.InputButton.Right) OnRightClick();
        else if (eventData.button == PointerEventData.InputButton.Middle) OnMiddleClick();
    }

    public void OnPointerDown(PointerEventData eventData) => isClicked = true;

    public Image GetItemSlotImage() => _itemSlotImage;

    public TMP_Text GetItemAmount() => _itemAmount;

}
