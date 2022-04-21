using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private Slider ManaBar;

    public void SetInitialValues(Dictionary<string, float> playerManaHealth)
    {
        HealthBar.maxValue = playerManaHealth["MaxHealth"];
        HealthBar.value = playerManaHealth["CurrentHealth"];
        ManaBar.maxValue = playerManaHealth["MaxMana"];
        ManaBar.value = playerManaHealth["CurrentMana"];
    }
    public float GetMaxHealth() => HealthBar.maxValue;
    public float GetMaxMana() => ManaBar.maxValue;
    public float GetValueHealth() => HealthBar.value;
    public float GetValueMana() => ManaBar.value;

    public void Set(string name, float value)
    {
        switch (name)
        {
            case "MaxHealth":
                HealthBar.maxValue = value;
                break;
            case "CurrentHealth":
                HealthBar.value = value;
                break;
            case "MaxMana":
                ManaBar.maxValue = value;
                break;
            case "CurrentMana":
                ManaBar.value = value;
                break;
        }
    }
}
