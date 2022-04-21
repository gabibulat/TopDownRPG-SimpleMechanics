using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Player _player;
    [SerializeField] private UnityEngine.UI.Button _inventory, _equipment, _playerStats;
    [SerializeField] private UnityEngine.UI.Button _closeInventory, _closeEquipment, _closePlayerStats;
    [SerializeField] private Draggable _draggable;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private GameObject _pickUpbutton;
    private float zoomMin = 3;
    private float zoomMax = 8;
    private InputController _inputController;
    bool isClicked = false;
    private Coroutine _zoomCorutine;

    private void Awake()
    {
        if (Touchscreen.current == null) _pickUpbutton.SetActive(false);
        _inputController = new InputController();
        _inputController.Enable();
        _inputController.UI.LongPress.canceled += _ => LongPressCanceled();
        _inputController.UI.SecondaryTouchContact.started += _ => ZoomStart();
        _inputController.UI.SecondaryTouchContact.canceled += _ => ZoomEnd();

    }
    private void ZoomStart() => _zoomCorutine = StartCoroutine(ZoomDetection());

    private void ZoomEnd() => StopCoroutine(_zoomCorutine);
    IEnumerator ZoomDetection()
    {
        Vector2 touchZeroPrevPos, touchOnePrevPos;
        float prevMagnitude, currentMagnitude, difference;
        while (true)
        {
            touchZeroPrevPos = _inputController.UI.PrimaryFingerPosition.ReadValue<Vector2>() - _inputController.UI.PrimaryFingerDeltaPosition.ReadValue<Vector2>();
            touchOnePrevPos = _inputController.UI.SecondaryFingerPosition.ReadValue<Vector2>() - _inputController.UI.SecondaryFingerDeltaPosition.ReadValue<Vector2>();

            prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            currentMagnitude = (_inputController.UI.PrimaryFingerPosition.ReadValue<Vector2>() - _inputController.UI.SecondaryFingerPosition.ReadValue<Vector2>()).magnitude;

            difference = currentMagnitude - prevMagnitude;
            _camera.m_Lens.OrthographicSize = Mathf.Clamp((_camera.m_Lens.OrthographicSize - difference * 0.01f), zoomMin, zoomMax);

            yield return null;
        }
    }

    private void LongPressCanceled()
    {
        if (isClicked) Drop();
    }

    private void Drop()
    {
        if (_draggable.GetDraggableItem().GetItemType() != Item.ItemTypes.None)
        {
            var prefab = Resources.Load(_draggable.GetDraggableItem().GetItemName());
            if (prefab != null)
            {
                GameObject newItem = Instantiate(prefab, new Vector3(_player.transform.position.x + 1, _player.transform.position.y + 1, 0), Quaternion.identity) as GameObject;
                ItemObject newItemScript = newItem.GetComponent<ItemObject>();

                newItemScript.item.SetCurrentDurability(_draggable.GetDraggableItem().GetCurrentDurability());

                if (_draggable.GetItemSlotEquipment() != null)
                {
                    _draggable.GetItemSlotEquipment().RemoveEquiped();
                    _draggable.GetItemSlotEquipment().GetItemSlotImage().enabled = true;
                }
                else _playerInventory.RemoveItemFromInventory(_draggable.GetDraggableItem());

                _draggable.EndDrag();
            }
        }
    }

    public void WindowOpen(GameObject gameObj)
    {
        if (!gameObj.activeInHierarchy)
        {
            gameObj.SetActive(true);

            AnalyticsResult analyticsResult = Analytics.CustomEvent("Window opened", new Dictionary<string, object>{
                         { "WindowType", gameObj.name },
                     });
            Debug.Log("AnalyticsResult of event 'Window opened': " + analyticsResult);
        }
        else gameObj.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) => isClicked = true;

    public void OnPointerExit(PointerEventData eventData) => isClicked = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Touchscreen.current == null) Drop();
    }

}
