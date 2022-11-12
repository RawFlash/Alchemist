using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Tooltip("Сам объект инвентаря, канвас")]
    public GameObject UIInventory;

    [Tooltip("Список вещей в инвентаре")]
    public List<InventoryObjects.InventoryObject> inventoryObjects = new List<InventoryObjects.InventoryObject>();
    
    [Tooltip("Максимум вещей в инвентаре, но простое увеличение не работает")]
    public int maxInv;

    private void Start()
    {
        inventoryObjects = new List<InventoryObjects.InventoryObject>();
    }
    private void Update()
    {
        // Lock cursor when clicking outside of menu
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetInventoryActivation(!UIInventory.activeSelf);
        }

        if (UIInventory.activeSelf && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void CloseInventory()
    {
        SetInventoryActivation(false);
    }

    void SetInventoryActivation(bool active)
    {
        UIInventory.SetActive(active);

        if (UIInventory.activeSelf)
        {
            ReloadInventory();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

    }

    public void ReloadInventory()
    {
        //i + 1 потому что там еще background есть как элемент
        for (int i = 0; i < inventoryObjects.Count; i++)
        {
            UIInventory.transform.GetChild(i+1).Find("Text").GetComponent<Text>().text = inventoryObjects[i].name;
            UIInventory.transform.GetChild(i+1).Find("Image").GetComponent<Image>().sprite = inventoryObjects[i].image;
        }
    }

    public void AddInInventory(InventoryObjects.InventoryObject inventoryObject)
    {
        if (inventoryObjects.Count < maxInv)
            inventoryObjects.Add(inventoryObject);
    }
}
