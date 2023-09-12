using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    public static EquipmentUIManager instance { get; private set; }
    [SerializeField] private GameObject[] equipmentBox; //Equipment UI Array

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Activate 1st Equipment's UI box
        equipmentBox[0].GetComponent<Outline>().enabled = true;
        equipmentBox[0].GetComponent<Image>().color = Color.white;
    }
    public void setEquipmentUI(string numkey)
    {
        //If 1 is pressed, display 1st equipment's UI, hide 2nd equipment's UI
        if (numkey == "1")
        {
            equipmentBox[0].GetComponent<Outline>().enabled = true;
            equipmentBox[0].GetComponent<Image>().color = Color.white;
            equipmentBox[1].GetComponent<Outline>().enabled = false;
            equipmentBox[1].GetComponent<Image>().color = Color.grey;
        }
        //If 2 is pressed, display 2nd equipment's UI, hide 1st equipment's UI
        else if (numkey == "2") 
        {
            equipmentBox[1].GetComponent<Outline>().enabled = true;
            equipmentBox[1].GetComponent<Image>().color = Color.white;
            equipmentBox[0].GetComponent<Outline>().enabled = false;
            equipmentBox[0].GetComponent<Image>().color = Color.grey;
        }
    }
}
