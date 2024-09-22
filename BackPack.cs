using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackPack : MonoBehaviour
{
    public GameObject Background;
    public bool BagIsOpened;
    public

    // Start is called before the first frame update
    void Start()
    {
        BagIsOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Bag"))
        {
            Debug.Log(3);
            OpenBag();
        }
    }

    private void OpenBag()
    {
        if(!Background.activeSelf)
        {
                Background.SetActive(true);
                BagIsOpened = true;
                Debug.Log(1);
        }else if (Background.activeSelf)
        {
                Background.SetActive(false);
                BagIsOpened= false;
                Debug.Log(2);
        }

    }


}
