using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Split : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TMP_InputField _splitAmountText;

    [SerializeField] private Button _plus;
    [SerializeField] private Button _minus;

    private int _min;
    private int _max;
    private int _stackID;   //not random but unique
    private Item _item;
    
    private void Awake()
    {   
        _plus.onClick.AddListener(PlusOnclick);
        _minus.onClick.AddListener(MinusOnclick);
        _max = 5;
        _min = 1;
        _splitAmountText.text = _max.ToString();
    }

    public void PassItem(Item item)
    {
        _item = item;
        _max = _item.GetItemAmount();
        _splitAmountText.text = _max.ToString();
        gameObject.SetActive(true);
    }

    public void PlusOnclick()
    {
        if (int.Parse(_splitAmountText.text) < _max) _splitAmountText.text = (int.Parse(_splitAmountText.text) + 1).ToString();
    }
    public void MinusOnclick()
    {
        if (int.Parse(_splitAmountText.text) > _min) _splitAmountText.text = (int.Parse(_splitAmountText.text) - 1).ToString();
    }

    public void OkOnClick()
    {
        int splitAmount = int.Parse(_splitAmountText.text);
        Item newItem = new Item();
        newItem = (Item)_item.Clone();
        _stackID++;
        for (int i = 0; i < splitAmount; i++) _playerInventory.RemoveItemFromInventory(_item);
      
        newItem.SetStackID(_stackID);
        newItem.SetItemAmount(1);
       
        for (int i = 0; i < splitAmount; i++) _playerInventory.AddItemToInventory(newItem);
    }
}
