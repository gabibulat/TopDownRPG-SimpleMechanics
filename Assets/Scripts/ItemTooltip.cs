using TMPro;
using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemTypeText;
    [SerializeField] private TMP_Text itemBuffText;
    [SerializeField] private TMP_Text itemStatsText;
    [SerializeField] private TMP_Text itemDurabilityText;

    private StringBuilder _stats = new StringBuilder();
  

    public void ShowTooltip(Item _item)
    {
        if (_item != null)
        {
            itemNameText.text = _item.GetItemName();
            itemTypeText.text = _item.GetItemType().ToString();
            if (_item.GetItemType() == Item.ItemTypes.Equipable)
            {
                foreach (string name in _item.additions.Keys) AddPlayerStat(_item.additions[name], name);
                _stats.AppendLine();
                itemStatsText.text = _stats.ToString();
                _stats.Clear();

                if (_item.GetMaxDurability() != 0) itemDurabilityText.text = "Durability: " + _item.GetCurrentDurability().ToString() + " / " + _item.GetMaxDurability().ToString();
                else itemDurabilityText.text = "";
            }
          
            if (_item.GetListAffectedValues().Count > 1) itemBuffText.text = GetBuffText(_item);
            else itemBuffText.text = "";

            this.gameObject.SetActive(true);
        }
    }
    public void HideTooltip()
    {
        this.gameObject.SetActive(false);
        itemBuffText.text = itemDurabilityText.text = itemStatsText.text = "";
    }

    private void AddPlayerStat(float _value, string _statName)
    {
        if (_value != 0)
        {
            _stats.AppendLine();
            if (_value > 0) _stats.Append("+");
            if (_value < 1)
            {
                _stats.Append(_value * 100);
                _stats.Append("%");
            }
            else _stats.Append(_value);
            _stats.Append(" ");
            _stats.Append(_statName);
        }
    }

    public string GetBuffText(Item _item) {
        StringBuilder _buff = new StringBuilder();
        List<float> values = _item.GetListAffectedValues();
        switch (values.Count)
        {
            case 2:
                if (_item.GetPersentage()) _buff.Append(values[0] * 100 + "%");
                else if (values[0] > 0) _buff.Append("+" + values[0]);
                _buff.Append(" " + _item.GetStatAffected());
                _buff.Append(" holds for " + values[1] + " seconds");
                break;
            case 3:
                _buff.Append("From 0 to ");
                if (_item.GetPersentage()) _buff.Append(values[0] * 100 + "%");
                else if (values[0] > 0) _buff.Append("+" + values[0]);
                _buff.Append(" " + _item.GetStatAffected());
                _buff.Append(" in " + values[2] + " seconds");
                _buff.Append(" holds for " + values[1] + " seconds");
                break;
            case 4:
                if (_item.GetPersentage()) _buff.Append(values[0] * 100 + "%");
                else if (values[0] > 0) _buff.Append("+" + values[0]);
                _buff.Append(" " + _item.GetStatAffected());
                _buff.Append(" for " + values[2]);
                _buff.Append(" per " + values[3] + " seconds");
                break;
        }
        return _buff.ToString();
    }
}
