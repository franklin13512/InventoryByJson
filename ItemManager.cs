using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public Prefabsss ThePrefab;
    public Item TheItem;
    public GameObject ThePrefabMount;
    public SpriteRenderer TheSprite;

    public string ModPathOfConsum;
    public string ModPathOfEquip;

    public enum ItemType
    {
        Consum,
        Equip
    }

    [Serializable]
    public class Consumable
    {
        public string Name;
        public int Id;
        public string Description;
        public string PathOfSprite;
        public Sprite ItemSprite;
        public ItemType ItemType_Consum;
    }

    [Serializable]
    public class Consum
    {
        public Consumable[] Consumables;
    }

    public Consum AllConsumable = new Consum();
    //------------------------------------------
    //------------------------------------------

    [Serializable]
    public class Equipment
    {
        public string Name;
        public int Id;
        public string Description;
        public string PathOfSprite;
        public Sprite ItemSprite;
        public ItemType ItemType_Equip;
    }

    [Serializable]
    public class Equip
    {
        public Equipment[] Equipments;
    }

    public Equip AllEquipment = new Equip();

    //------------------------------------------
    //------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        ModPathOfConsum = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Mod", "JsonOfConsuamble.json");
        ModPathOfEquip = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Mod", "JsonOfEquipment.json");

        ThePrefab = ThePrefabMount.gameObject.GetComponent<Prefabsss>();

        JsonOfConsumable();
        JsonOfEquipment();

    }

    public void JsonOfConsumable()
    {


        Consumable Juice = new Consumable();
        Juice.Name = "Juice";
        Juice.Id = 00;
        Juice.Description = "Juice with good taste";
        Juice.PathOfSprite = "Image/Drink";
        //Juice.ItemSprite = Resources.Load<Sprite>(Juice.PathOfSprite);
        Juice.ItemType_Consum = ItemType.Consum;
        
        Consumable HotDog = new Consumable();
        HotDog.Name = "HotDog";
        HotDog.Id = 01;
        HotDog.Description = "Made with meat";
        HotDog.PathOfSprite = "Image/Hotdog";
        //HotDog.ItemSprite = Resources.Load<Sprite>(HotDog.PathOfSprite);
        HotDog.ItemType_Consum = ItemType.Consum;

        AllConsumable.Consumables = new Consumable[] { Juice, HotDog };

        string StoredConsumable = JsonMapper.ToJson(AllConsumable);

        string PathOfConsumable = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Json", "JsonOfConsuamble.json");
        File.WriteAllText(PathOfConsumable, StoredConsumable);

        //unity无法读取sprite类型，不能写入json文件

        //Juice.ItemSprite = Resources.Load<Sprite>(Juice.PathOfSprite);
        //HotDog.ItemSprite = Resources.Load<Sprite>(HotDog.PathOfSprite);


        string ModJson = File.ReadAllText(ModPathOfConsum);
        Consum ModAllConsumables = JsonMapper.ToObject<Consum>(ModJson);

        List<Consumable> consumables = AllConsumable.Consumables.ToList();
        consumables.AddRange(ModAllConsumables.Consumables);
        AllConsumable.Consumables = consumables.ToArray();

        GetSpriteForConsumables();
    }

    public void JsonOfEquipment()
    {

        Equipment IronHelmet = new Equipment();
        IronHelmet.Name = "Iron Helment";
        IronHelmet.Id = 02;
        IronHelmet.Description = "Hard Helmet made with iron";
        IronHelmet.PathOfSprite = "Image/Helmet";
        //IronHelmet.ItemSprite = Resources.Load<Sprite>(IronHelmet.PathOfSprite);
        IronHelmet.ItemType_Equip = ItemType.Equip;

        Equipment IronArmor = new Equipment();
        IronArmor.Name = "Iron Armor";
        IronArmor.Id = 03;
        IronArmor.Description = "Heavy but defencive";
        IronArmor.PathOfSprite = "Image/Armor";
        //IronArmor.ItemSprite = Resources.Load<Sprite>(IronArmor.PathOfSprite);
        IronArmor.ItemType_Equip = ItemType.Equip;

        AllEquipment.Equipments = new Equipment[] { IronHelmet, IronArmor };

        string StoredEquipment = JsonMapper.ToJson(AllEquipment);

        string PathOfEquipment = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Json", "JsonOfEquipment.json");
        File.WriteAllText(PathOfEquipment, StoredEquipment);

        //unity无法读取sprite类型，不能写入json文件
        //IronHelmet.ItemSprite = Resources.Load<Sprite>(IronHelmet.PathOfSprite);
        //IronArmor.ItemSprite = Resources.Load<Sprite>(IronArmor.PathOfSprite);


        string ModJson = File.ReadAllText(ModPathOfEquip);
        Equip ModAllEquipments = JsonMapper.ToObject<Equip>(ModJson);

        List<Equipment> equipments =AllEquipment.Equipments.ToList();
        equipments.AddRange(ModAllEquipments.Equipments);
        AllEquipment.Equipments = equipments.ToArray();

        GetSpriteForEquipments();
    }

    public void GetSpriteForConsumables()
    {
        for (int i = 0; i < AllConsumable.Consumables.Length; i++)
        {
            for (int j = 0; j < ThePrefab.Prefabs.Length; j++)
            {
                TheItem = ThePrefab.Prefabs[j].gameObject.GetComponent<Item>();
                if (AllConsumable.Consumables[i].Id == TheItem.Id)
                {
                    TheSprite = ThePrefab.Prefabs[j].gameObject.GetComponentInChildren<SpriteRenderer>();
                    AllConsumable.Consumables[i].ItemSprite = TheSprite.sprite;
                }
            }
        }
    }

    public void GetSpriteForEquipments()
    {
        for (int i = 0; i < AllEquipment.Equipments.Length; i++)
        {
            for (int j = 0; j < ThePrefab.Prefabs.Length; j++)
            {
                TheItem = ThePrefab.Prefabs[j].gameObject.GetComponent<Item>();
                if (AllEquipment.Equipments[i].Id == TheItem.Id)
                {
                    TheSprite = ThePrefab.Prefabs[j].gameObject.GetComponentInChildren<SpriteRenderer>();
                    AllEquipment.Equipments[i].ItemSprite = TheSprite.sprite;
                }
            }
        }
    }
}
