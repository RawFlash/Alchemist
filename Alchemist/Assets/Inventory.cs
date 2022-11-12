using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    //КОД ДЛЯ ВЗАИМОДЕЙСТВИЯ С МЕНЕДЖЕРОМ ИНВЕНТАРЯ

    [Tooltip("Менеджер инвентаря")]
    public GameObject MyInventoryManager;

    public void AddInInventory(InventoryObjects.InventoryObject inventoryObject)
    {
        MyInventoryManager.GetComponent<InventoryManager>().AddInInventory(inventoryObject);
    }

}
