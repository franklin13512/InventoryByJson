using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public int Id;
    public Sprite ShowedSprite;

    private ItemManager Management;
    private Item AItem;
    private Slotsss TheSlot;

    public GameObject SlotsssMount;
    public GameObject ManagementMount;

    // Start is called before the first frame update
    void Start()
    {
        TheSlot = SlotsssMount.GetComponent<Slotsss>();
        Management = ManagementMount.GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.tag == "Item")
        {

            AItem = collision2D.gameObject.GetComponent<Item>();
            if (AItem != null)
            {
                PickUpItem(AItem);

                Destroy(collision2D.gameObject);
            }
            else
            {
                Debug.Log("Item component not found on the collided object.");
            }

        }

    }

    //用于获取Id与图片的函数
    public void PickUpItem(Item CItem)
    {
        this.Id = CItem.Id;

        for (int i = 0; i < Management.AllConsumable.Consumables.Length; i++)
        {
            if (this.Id == Management.AllConsumable.Consumables[i].Id)
            {
                this.ShowedSprite = Management.AllConsumable.Consumables[i].ItemSprite;
                break;
            }
        }

        for (int i = 0; i < Management.AllEquipment.Equipments.Length; i++)
        {
            if (this.Id == Management.AllEquipment.Equipments[i].Id)
            {
                this.ShowedSprite = Management.AllEquipment.Equipments[i].ItemSprite;
                break;
            }
        }

        PassToSlot();

    }

    //将图片与Id传递至槽位
    public void PassToSlot()
    {
        for (int i = 0; i < TheSlot.Slots.Length; i++)
        {
            if (TheSlot.Slots[i].IsFull == false)
            {
                TheSlot.Slots[i].IsFull = true;
                TheSlot.Slots[i].ItemSprite = this.ShowedSprite;
                TheSlot.Slots[i].Id = this.Id;

                break;
            }
        }
    }
}
