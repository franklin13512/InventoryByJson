using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour , IPointerClickHandler
{

    public Sprite ItemSprite;
    public int Id;
    public bool IsFull = false;

    public Image TheImage;

    public Prefabsss ThePrefab;
    public Item TheItem;
    public GameObject PlayerModel;
    public GameObject ThePrefabMount;

    // Start is called before the first frame update
    void Start()
    {
        TheImage = gameObject.GetComponent<Image>();
        ThePrefab = ThePrefabMount.gameObject.GetComponent<Prefabsss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFull)
        {
            PassToBag();
        }
    }

    public void PassToBag()
    {
        TheImage.sprite = ItemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnRightClick()
    {
        if (IsFull)
        {
            this.ItemSprite = null;
            this.TheImage.sprite = null;

            for (int i = 0; i < ThePrefab.Prefabs.Length; i++)
            {
                TheItem = ThePrefab.Prefabs[i].GetComponent<Item>();
                if (this.Id == TheItem.Id)
                {
                    Vector3 CurrentPos = PlayerModel.transform.position;
                    Vector3 NewPos = new Vector3(CurrentPos.x + 1, CurrentPos.y + 1, CurrentPos.z);
                    Instantiate(ThePrefab.Prefabs[i], NewPos, PlayerModel.transform.rotation);

                    break;
                }
            }

            IsFull = false;
        }
    }
}
