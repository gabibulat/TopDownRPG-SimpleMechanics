using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.Analytics;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private PlayerEquipment _playerEquipment;
    [SerializeField] private Stats _stats;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Bar _bar;
    [SerializeField] private Buff _buff;
    [SerializeField] private Animator _animator;
    [SerializeField] private float range;
    [SerializeField] private GameObject _pickUpCircle;

    private Dictionary<string, float> _playerHealthMana;
    private Dictionary<string, int> _playerStats;
    private Vector2 _movement;
    private bool Cutscene;
    private bool PickUpOption = false;
    private bool PickUp = false;
    private Collider2D[] colliderArray;
    private Collider2D collider;
    private InputController _inputController;
    private Vector2 previousPosition;
    private int analyticsEventCounter = 0;
    private float prevTime;
    private int negative = 1;

    public event EventHandler OnPlayerMove;
    void Awake()
    {
        AnalyticsResult analyticsResult1 = Analytics.CustomEvent("Build Started", new Dictionary<string, object>{
                    { "Platform", Application.platform },
                    { "Local Time" ,System.DateTime.Now}
                });
        Debug.Log("AnalyticsResult of event 'Build Started': " + analyticsResult1);

        Cutscene = false;

        _playerInventory.SetInventory();
        _playerEquipment.OnAddEquip += OnAddedEquip;
        _playerEquipment.OnRemoveEquip += OnRemovedEquip;

        _playerStats = new Dictionary<string, int>();
        _playerStats.Add("Strength", 10);
        _playerStats.Add("Dexterity", 5);
        _playerStats.Add("Agility", 2);
        _playerStats.Add("Intelligence", 4);
        _playerStats.Add("Luck", 5);
        _stats.AddStat(_playerStats);

        _playerHealthMana = new Dictionary<string, float>();
        _playerHealthMana.Add("MaxHealth", 71);
        _playerHealthMana.Add("CurrentHealth", 24);
        _playerHealthMana.Add("MaxMana", 50);
        _playerHealthMana.Add("CurrentMana", 10);

        _bar.SetInitialValues(_playerHealthMana);
        _inputController = new InputController();
        _inputController.Enable();
        _inputController.Player.PickUp.performed += _ => PickUpOnInput();

        _pickUpCircle.transform.localScale = new Vector3(range / 2, range / 2, range / 2);
        previousPosition = gameObject.transform.position;
    }

    public void SetCutscene(bool var) => Cutscene = var;

    public float GetValue(string key)
    {
        if (_playerHealthMana.ContainsKey(key)) return _playerHealthMana[key];
        else return _playerStats[key];
    }

    public void AddBuff(string key, float value)
    {
        if (_playerHealthMana.ContainsKey(key))
        {
            _playerHealthMana[key] += value;
            _bar.Set(key, _playerHealthMana[key]);
        }
        else
        {
            _playerStats[key] += (int)value;
            _stats.UpdateStats(key, _playerStats[key]);
        }
    }

    public void Movement(InputAction.CallbackContext value)
    {
        if (!Cutscene)
        {
            _movement = value.ReadValue<Vector2>();
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }
        else
        {
            _movement = new Vector2(0, 0);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        if (!Cutscene)
        {
            _rb.MovePosition(_rb.position + _movement * MoveSpeed * Time.fixedDeltaTime);
            OnPlayerMove?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnAddedEquip(object sender, EventArgs e)
    {
        var equipmentStats = _playerEquipment.GetStatsAditions();
        foreach (var key in equipmentStats.Keys)
        {
            if (_playerHealthMana.ContainsKey(key))
            {
                if (equipmentStats[key] < 1 && equipmentStats[key] > 0) //if presentage
                {
                    if (key == "CurrentHealth" || key == "MaxHealth")
                    {
                        _playerHealthMana[key] += (int)_playerHealthMana["MaxHealth"] * equipmentStats[key] * negative;
                    }
                    else if (key == "CurrentMana" || key == "MaxMana")
                    {
                        _playerHealthMana[key] += (int)_playerHealthMana["MaxMana"] * equipmentStats[key] * negative;
                    }
                }
                else _playerHealthMana[key] += equipmentStats[key] * negative;
                _bar.Set(key, _playerHealthMana[key]);
            }
            else if (_playerStats.ContainsKey(key))
            {
                _playerStats[key] += (int)equipmentStats[key] * negative;
                _stats.UpdateStats(key, _playerStats[key]);
            }
        }
    }
    private void OnRemovedEquip(object sender, EventArgs e)
    {
        negative = -1;
        OnAddedEquip(sender, e);
        negative = 1;
    }

    private void Update()
    {
        if (!PickUpOption)
        {
            colliderArray = Physics2D.OverlapCircleAll(transform.position, range);
            if (PickUp)
            {
                foreach (Collider2D collision in colliderArray)
                {
                    PickUp = false;
                    PickUpItems(collision);
                }
            }
        }
        else if (PickUpOption)
        {
            if (PickUp)
            {
                PickUp = false;
                PickUpItems(collider);
            }
        }

        //Analytics event on player moving 10 units
        if (analyticsEventCounter < 5)
        {

            if (Mathf.RoundToInt(Vector2.Distance(previousPosition, gameObject.transform.position)) == 10)
            {
                previousPosition = gameObject.transform.position;
                analyticsEventCounter++;
                AnalyticsResult analyticsResult = Analytics.CustomEvent("Player moved 10 units");
                Debug.Log("AnalyticsResult of event 'Player moved 10 units': " + analyticsResult);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var time = Time.time - prevTime;

        //in scene colliders are walls
        if (prevTime == 0f || time > 5)
        {
            prevTime = Time.time;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("Player collided");
            Debug.Log("AnalyticsResult of event 'Player cllided': " + analyticsResult);
        }
        else StartCoroutine(WaitToSend(Time.time - prevTime));
    }

    IEnumerator WaitToSend(float num)
    {
        //wait leftover to 5sec
        yield return new WaitForSeconds(5 - num);
        prevTime = Time.time;
        AnalyticsResult analyticsResult = Analytics.CustomEvent("Player collided");
        Debug.Log("AnalyticsResult of event 'Player cllided': " + analyticsResult);
    }

    public void OnTriggerStay2D(Collider2D collision) => collider = collision;

    void PickUpItems(Collider2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            ItemObject itemObject = collision.gameObject.GetComponent<ItemObject>();

            if (itemObject.item.GetItemType() != Item.ItemTypes.PermanentUsage) _playerInventory.AddItemToInventory(itemObject.item);
            else
            {
                Destroy(collision.gameObject);
                Debug.Log("Item used");
            }
            if (_playerInventory.GetIsPickedUp())
            {
                AnalyticsResult analyticsResult = Analytics.CustomEvent("Item Picked up", new Dictionary<string, object>{
                    { "ItemName", itemObject.item.GetItemName() },
                    { "Item type" ,itemObject.item.GetItemType()}
                });
                Debug.Log("AnalyticsResult of event 'Item Picked up': " + analyticsResult);
                Destroy(collision.gameObject);
            }
        }
    }

    public void ChangePickUpType()
    {
        PickUpOption = !PickUpOption;
        if (PickUpOption) _pickUpCircle.SetActive(false);
        else _pickUpCircle.SetActive(true);
    }

    public void PickUpOnInput() => PickUp = true;
}
