using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObjects : MonoBehaviour
{
    public Sprite CrystalImage;
    public static Sprite _crystalImage;
    public class InventoryObject
    {
        public InventoryObject(string name, Sprite image)
        {
            this.name = name;
            this.image = image;
        }
        public Sprite image;
        public string name;

    }
    public static InventoryObject NewCrystal()
    {
        return new InventoryObject("Кристалл", _crystalImage);
    }

    private void Start()
    {
        _crystalImage = CrystalImage;
    }

}
