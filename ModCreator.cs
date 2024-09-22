using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModCreator : MonoBehaviour
{
    public Prefabsss ThePrefab;
    public Item TheItem;
    public GameObject ThePrefabMount;
    public SpriteRenderer TheSprite;

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
        ThePrefab = ThePrefabMount.gameObject.GetComponent<Prefabsss>();

        JsonOfConsumable();
        JsonOfEquipment();

    }

    public void JsonOfConsumable()
    {


        Consumable Water = new Consumable();
        Water.Name = "Water";
        Water.Id = 04;
        Water.Description = "Water with good taste";
        Water.PathOfSprite = "Image/Water";
        //Juice.ItemSprite = Resources.Load<Sprite>(Juice.PathOfSprite);
        Water.ItemType_Consum = ItemType.Consum;

        Consumable Bandage = new Consumable();
        Bandage.Name = "Bandage";
        Bandage.Id = 05;
        Bandage.Description = "Heal yourself";
        Bandage.PathOfSprite = "Image/Bandage";
        //HotDog.ItemSprite = Resources.Load<Sprite>(HotDog.PathOfSprite);
        Bandage.ItemType_Consum = ItemType.Consum;

        AllConsumable.Consumables = new Consumable[] { Water, Bandage };

        string StoredConsumable = JsonMapper.ToJson(AllConsumable);

        string PathOfConsumable = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Mod", "JsonOfConsuamble.json");
        File.WriteAllText(PathOfConsumable, StoredConsumable);

        //unity无法读取sprite类型，不能写入json文件

        //Juice.ItemSprite = Resources.Load<Sprite>(Juice.PathOfSprite);
        //HotDog.ItemSprite = Resources.Load<Sprite>(HotDog.PathOfSprite);

    }

    public void JsonOfEquipment()
    {

        Equipment IronSword = new Equipment();
        IronSword.Name = "Iron Sword";
        IronSword.Id = 06;
        IronSword.Description = "Hard Sword made with iron";
        IronSword.PathOfSprite = "Image/Sword";
        //IronHelmet.ItemSprite = Resources.Load<Sprite>(IronHelmet.PathOfSprite);
        IronSword.ItemType_Equip = ItemType.Equip;

        Equipment IronBoots = new Equipment();
        IronBoots.Name = "Iron Boots";
        IronBoots.Id = 07;
        IronBoots.Description = "Heavy but defencive";
        IronBoots.PathOfSprite = "Image/Boots";
        //IronArmor.ItemSprite = Resources.Load<Sprite>(IronArmor.PathOfSprite);
        IronBoots.ItemType_Equip = ItemType.Equip;

        AllEquipment.Equipments = new Equipment[] { IronSword, IronBoots };

        string StoredEquipment = JsonMapper.ToJson(AllEquipment);

        string PathOfEquipment = Path.Combine(@"D:\u3dpro", "JsonProject", "Assets", "Resources", "Mod", "JsonOfEquipment.json");
        File.WriteAllText(PathOfEquipment, StoredEquipment);

        //unity无法读取sprite类型，不能写入json文件
        //IronHelmet.ItemSprite = Resources.Load<Sprite>(IronHelmet.PathOfSprite);
        //IronArmor.ItemSprite = Resources.Load<Sprite>(IronArmor.PathOfSprite);
    }

}
