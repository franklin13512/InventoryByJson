using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class JsonDemo : MonoBehaviour
{
    [Serializable]
    class PersonInformation
    {
        public string Name;
        public int Age;
        public string Weapon;
    }

    [Serializable]
    class PersonInformationList
    {
        public PersonInformation[] PersonInformations;
    }
    // Start is called before the first frame update
    void Start()
    {
        PersonInformation Person1 = new PersonInformation();
        Person1.Name = "·Ò¶÷";
        Person1.Age = 20;
        Person1.Weapon = "Spear";

        PersonInformation Person2 = new PersonInformation();
        Person2.Name = "¿¨Àû";
        Person2.Age = 18;
        Person2.Weapon = "Iron Sword";


        PersonInformationList PersonList = new PersonInformationList();
        PersonList.PersonInformations = new PersonInformation[] { Person1, Person2 };


        string PersonListStr = JsonUtility.ToJson(PersonList);

        Debug.Log(PersonListStr);

        PersonInformationList personInformationList_Back = JsonUtility.FromJson<PersonInformationList>(PersonListStr);
        foreach (PersonInformation P in personInformationList_Back.PersonInformations)
        {
            Debug.Log(P.Name);
        }
    }


}
