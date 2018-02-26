/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    25 February 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentFilter : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private Helmets helmets;
    private Armors  armors;
    private Greaves greaves;
    private Boots   boots;
    private Jewels  jewels;

    // PUBLIC
    [Header("Equipment Type")]
    public Toggle helmet_Checkbox;
    public Toggle armor_Checkbox;
    public Toggle greave_Checkbox;
    public Toggle boots_Checkbox;
    public Toggle jewel_Checkbox;
    [Space(5)]
    [Header("InputField")]
    public TMP_InputField minLvl_Input;
    public TMP_InputField maxLvl_Input;
    public TMP_InputField maxCost_Input;
    [Space(5)]
    [Header("Main Stats")]
    public Toggle ap_Checkbox;
    public Toggle mp_Checkbox;
    public Toggle range_Checkbox;
    public Toggle hp_Checkbox;
    public Toggle will_Checkbox;
    [Space(5)]
    [Header("Final Damage Stats")]
    public Toggle finalDamage_Checkbox;
    public Toggle finalMeleeDamage_Checkbox;
    public Toggle finalRangedDamage_Checkbox;
    [Space(5)]
    [Header("Power Stats")]
    public Toggle power_Checkbox;
    public Toggle fireDamage_Checkbox;
    public Toggle waterDamage_Checkbox;
    public Toggle windDamage_Checkbox;
    public Toggle groundDamage_Checkbox;
    public Toggle lightDamage_Checkbox;
    public Toggle darkDamage_Checkbox;
    [Space(5)]
    [Header("Resistance Stats")]
    public Toggle damageReflection_Checkbox;
    public Toggle fireResistance_Checkbox;
    public Toggle waterResistance_Checkbox;
    public Toggle windResistance_Checkbox;
    public Toggle groundResistance_Checkbox;
    public Toggle lightResistance_Checkbox;
    public Toggle darkResistance_Checkbox;

    #endregion

    #region UNITY METHODE
    void Awake() {
        GameObject itemsHolder = GameObject.FindGameObjectWithTag("Items");
        helmets = itemsHolder.GetComponent<Helmets>();
        armors  = itemsHolder.GetComponent<Armors>();
        greaves = itemsHolder.GetComponent<Greaves>();
        boots   = itemsHolder.GetComponent<Boots>();
        jewels  = itemsHolder.GetComponent<Jewels>();

        gameObject.SetActive(false);
    }

    void Start() {

    }

    void Update() {

    }
    #endregion

    public void Cancel_btn() {
        gameObject.SetActive(false);
    }


    public void DesactivateEquipmentTypeFilter(int defaultEquipmentTypeFiltered) {
        const int HELMET = 0;
        const int ARMOR  = 1;
        const int GREAVE = 2;
        const int BOOTS  = 3;
        const int JEWEL  = 4;

        helmet_Checkbox.isOn = false;
        armor_Checkbox .isOn = false;
        greave_Checkbox.isOn = false;
        boots_Checkbox .isOn = false;
        jewel_Checkbox .isOn = false;

        helmet_Checkbox.interactable = false;
        armor_Checkbox .interactable = false;
        greave_Checkbox.interactable = false;
        boots_Checkbox .interactable = false;
        jewel_Checkbox .interactable = false;

        switch (defaultEquipmentTypeFiltered)
        {
            case HELMET:
                helmet_Checkbox.isOn = true; break;
            case ARMOR:
                armor_Checkbox .isOn = true; break;
            case GREAVE:
                greave_Checkbox.isOn = true; break;
            case BOOTS:
                boots_Checkbox .isOn = true; break;
            case JEWEL:
                jewel_Checkbox .isOn = true; break;
            default:
                Debug.Log("Error 404: Equipment type not found"); break;
        }
    }

    public void SetMaxLvl(int maxLvl) {
        maxLvl_Input.text = maxLvl.ToString();
    }


    public List<List<string>> Filter() {
        List<List<string>> listOfEquipmentType = new List<List<string>>();

        if(helmet_Checkbox.isOn) {
            listOfEquipmentType = AddToListEquipmentTypeList(listOfEquipmentType, helmets.GetAllItems());
        }
        if(armor_Checkbox.isOn) {
            listOfEquipmentType = AddToListEquipmentTypeList(listOfEquipmentType, armors.GetAllItems());
        }
        if(greave_Checkbox.isOn) {
            listOfEquipmentType = AddToListEquipmentTypeList(listOfEquipmentType, greaves.GetAllItems());
        }
        if(boots_Checkbox.isOn) {
            listOfEquipmentType = AddToListEquipmentTypeList(listOfEquipmentType, boots.GetAllItems());
        }
        if(jewel_Checkbox.isOn) {
            listOfEquipmentType = AddToListEquipmentTypeList(listOfEquipmentType, jewels.GetAllItems());
        }

        return listOfEquipmentType;
    }

    private List<List<string>> AddToListEquipmentTypeList(List<List<string>> baseList, List<List<string>> addingList) {

        foreach(List<string> equipment in addingList) {
            bool isEquipmentValidateFilter = IsValideEquipmentLvl  (equipment) &&
                                             IsValideEquipmentCost (equipment) &&
                                             IsValideEquipmentStats(equipment);

            if(isEquipmentValidateFilter) {
                baseList.Add(equipment);
            }
        }

        return baseList;
    }

    private bool IsValideEquipmentLvl(List<string> equipment) {
        int equipmentLevel = int.Parse(equipment[(int)Items.ITEM_INFO.LVL_R]);

        int minLvl = int.Parse(minLvl_Input.text);
        int maxLvl = int.Parse(maxLvl_Input.text);

        bool isValideEquipmentLvl = equipmentLevel >= minLvl &&
                                    equipmentLevel <= maxLvl;

        return isValideEquipmentLvl;
    }

    private bool IsValideEquipmentCost(List<string> equipment) {
        bool isValideEquipmentCost = true;

        bool isCostInputUsed = maxCost_Input.text != "";
        if(isCostInputUsed) {
            int equipmentCost = int.Parse(equipment[(int)Items.ITEM_INFO.COST]);
            int maxCost       = int.Parse(maxCost_Input.text);

            isValideEquipmentCost = equipmentCost <= maxCost;
        }

        return isValideEquipmentCost;
    }

    private bool IsValideEquipmentStats(List<string> equipment) {
        // Main Stats
        if(ap_Checkbox.isOn) {
            int ap = int.Parse(equipment[(int)Items.ITEM_INFO.AP]);

            if(ap == 0) {
                return false;
            }
        }
        if(mp_Checkbox.isOn) {
            int mp = int.Parse(equipment[(int)Items.ITEM_INFO.MP]);

            if(mp == 0) {
                return false;
            }
        }
        if(range_Checkbox.isOn) {
            int range = int.Parse(equipment[(int)Items.ITEM_INFO.RANGE]);

            if(range == 0) {
                return false;
            }
        }
        if(hp_Checkbox.isOn) {
            int hp = int.Parse(equipment[(int)Items.ITEM_INFO.HP]);

            if(hp == 0) {
                return false;
            }
        }
        if(will_Checkbox.isOn) {
            int will = int.Parse(equipment[(int)Items.ITEM_INFO.WILL]);

            if(will == 0) {
                return false;
            }
        }

        // Final Damage Stats
        if(finalDamage_Checkbox.isOn) {
            int finalDamage = int.Parse(equipment[(int)Items.ITEM_INFO.F_DMG]);

            if(finalDamage == 0) {
                return false;
            }
        }
        if(finalMeleeDamage_Checkbox.isOn) {
            int finalMeleeDamage = int.Parse(equipment[(int)Items.ITEM_INFO.F_M_DMG]);

            if(finalMeleeDamage == 0) {
                return false;
            }
        }
        if(finalRangedDamage_Checkbox.isOn) {
            int finalRangedDamage = int.Parse(equipment[(int)Items.ITEM_INFO.F_R_DMG]);

            if(finalRangedDamage == 0) {
                return false;
            }
        }

        // Power Stats
        if(power_Checkbox.isOn) {
            int power = int.Parse(equipment[(int)Items.ITEM_INFO.POWER]);

            if(power == 0) {
                return false;
            }
        }
        if(fireDamage_Checkbox.isOn) {
            int fireDamage = int.Parse(equipment[(int)Items.ITEM_INFO.FIRE_DMG]);

            if(fireDamage == 0) {
                return false;
            }
        }
        if(waterDamage_Checkbox.isOn) {
            int waterDamage = int.Parse(equipment[(int)Items.ITEM_INFO.WATER_DMG]);

            if(waterDamage == 0) {
                return false;
            }
        }
        if(windDamage_Checkbox.isOn) {
            int windDamage = int.Parse(equipment[(int)Items.ITEM_INFO.WIND_DMG]);

            if(windDamage == 0) {
                return false;
            }
        }
        if(groundDamage_Checkbox.isOn) {
            int groundDamage = int.Parse(equipment[(int)Items.ITEM_INFO.GROUND_DMG]);

            if(groundDamage == 0) {
                return false;
            }
        }
        if(lightDamage_Checkbox.isOn) {
            int lightDamage = int.Parse(equipment[(int)Items.ITEM_INFO.LIGHT_DMG]);

            if(lightDamage == 0) {
                return false;
            }
        }
        if(darkDamage_Checkbox.isOn) {
            int darkDamage = int.Parse(equipment[(int)Items.ITEM_INFO.DARK_DMG]);

            if(darkDamage == 0) {
                return false;
            }
        }

        // Resistance Stats
        if(damageReflection_Checkbox.isOn) {
            int damageReflection = int.Parse(equipment[(int)Items.ITEM_INFO.DMG_REFLECT]);

            if(damageReflection == 0) {
                return false;
            }
        }
        if(fireResistance_Checkbox.isOn) {
            int fireResistance = int.Parse(equipment[(int)Items.ITEM_INFO.FIRE_RES]);

            if(fireResistance == 0) {
                return false;
            }
        }
        if(waterResistance_Checkbox.isOn) {
            int waterResistance = int.Parse(equipment[(int)Items.ITEM_INFO.WATER_RES]);

            if(waterResistance == 0) {
                return false;
            }
        }
        if(windResistance_Checkbox.isOn) {
            int windResistance = int.Parse(equipment[(int)Items.ITEM_INFO.WIND_RES]);

            if(windResistance == 0) {
                return false;
            }
        }
        if(groundResistance_Checkbox.isOn) {
            int groundResistance = int.Parse(equipment[(int)Items.ITEM_INFO.GROUND_RES]);

            if(groundResistance == 0) {
                return false;
            }
        }
        if(lightResistance_Checkbox.isOn) {
            int lightResistance = int.Parse(equipment[(int)Items.ITEM_INFO.LIGHT_RES]);

            if(lightResistance == 0) {
                return false;
            }
        }
        if(darkResistance_Checkbox.isOn) {
            int darkResistance = int.Parse(equipment[(int)Items.ITEM_INFO.DARK_RES]);

            if(darkResistance == 0) {
                return false;
            }
        }

        return true;
    }
}