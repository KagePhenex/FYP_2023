using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    public static EquipmentUIManager instance { get; private set; }
    [SerializeField] private GameObject[] equipmentBox;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        equipmentBox[0].GetComponent<Outline>().enabled = true;
        equipmentBox[0].GetComponent<Image>().color = Color.white;
    }
    public void setEquipmentUI(string numkey)
    {
        if (numkey == "1")
        {
            equipmentBox[0].GetComponent<Outline>().enabled = true;
            equipmentBox[0].GetComponent<Image>().color = Color.white;
            equipmentBox[1].GetComponent<Outline>().enabled = false;
            equipmentBox[1].GetComponent<Image>().color = Color.grey;
        }
        else if (numkey == "2")
        {
            equipmentBox[1].GetComponent<Outline>().enabled = true;
            equipmentBox[1].GetComponent<Image>().color = Color.white;
            equipmentBox[0].GetComponent<Outline>().enabled = false;
            equipmentBox[0].GetComponent<Image>().color = Color.grey;
        }
    }
}
