﻿/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    14 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    #region DECLARATION
    // CONST
    public enum ITEM_INFO {
        ID,
        NAME,
        LORE,
        LVL_R,
        SHOP_COST,
        COST,
        AP,
        MP,
        RANGE,
        HP,
        WILL,
        F_DMG,
        F_M_DMG,
        F_R_DMG,
        POWER,
        FIRE_DMG,
        WATER_DMG,
        WIND_DMG,
        GROUND_DMG,
        LIGHT_DMG,
        DARK_DMG,
        DMG_REFLECT,
        FIRE_RES,
        WATER_RES,
        WIND_RES,
        GROUND_RES,
        LIGHT_RES,
        DARK_RES
     };

    private const int HELMET = 0;
    private const int ARMOR  = 1;
    private const int GREAVE = 2;
    private const int BOOTS  = 3;
    private const int JEWEL  = 4;

    private string[] ITEMS_STATS_DESCRIPTIONS = {
        "Id: ",
        "Name: ",
        "Description: ",
        "Level Requirment: ",
        "Shop cost: ",
        "Cost: ",

        "Ap: ",
        "Mp: ",
        "Range: ",

        "Hp: ",
        "Will: ",

        "Final Damage: ",
        "Final Melee Damage: ",
        "Final Ranged Damage: ",

        "Power: ",
        "Fire Damage: ",
        "Water Damage: ",
        "Wind Damage: ",
        "Ground Damage: ",
        "Light Damage: ",
        "Dark Damage: ",

        "Damage Reflection: ",
        "Fire Resistance: ",
        "Water Resistance: ",
        "Wind Resistance: ",
        "Ground Resistance: ",
        "Light Resistance: ",
        "Dark Resistance: ",

    };

    private int[] PERCENTAGE_STATS_INDEX = {
            (int)ITEM_INFO.F_DMG,
            (int)ITEM_INFO.F_M_DMG,
            (int)ITEM_INFO.F_R_DMG,
            (int)ITEM_INFO.DMG_REFLECT,
            (int)ITEM_INFO.FIRE_RES,
            (int)ITEM_INFO.WATER_RES,
            (int)ITEM_INFO.WIND_RES,
            (int)ITEM_INFO.GROUND_RES,
            (int)ITEM_INFO.LIGHT_RES,
            (int)ITEM_INFO.DARK_RES,
        };

    // PRIVATE
    private int extraParam_ItemType; /* Inter screen param */  // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;

    private Helmets helmets;
    private Armors  armors;
    private Greaves greaves;
    private Boots   boots;
    private Jewels  jewels;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake() {
        DontDestroyOnLoad(gameObject);

        // The list of all the items.
        helmets = gameObject.GetComponent<Helmets>();
        armors  = gameObject.GetComponent<Armors>();
        greaves = gameObject.GetComponent<Greaves>();
        boots   = gameObject.GetComponent<Boots>();
        jewels  = gameObject.GetComponent<Jewels>();
    }
	
	void Start() {

	}
	
	void Update() {
		
	}
    #endregion


    #region Get Main Stats
    public int GetCost(List<string> item) {
        const int COST_INDEX = 5;
        int cost = GetSpecificIntStats(item, COST_INDEX);

        return cost;
    }


    public int GetAp(List<string> item) {
        const int AP_INDEX = 6;
        int ap = GetSpecificIntStats(item, AP_INDEX);

        return ap;
    }

    public int GetMp(List<string> item) {
        const int MP_INDEX = 7;
        int mp = GetSpecificIntStats(item, MP_INDEX);

        return mp;
    }

    public int GetRange(List<string> item) {
        const int RANGE_INDEX = 8;
        int range = GetSpecificIntStats(item, RANGE_INDEX);

        return range;
    }


    public int GetHp(List<string> item) {
        const int HP_INDEX = 9;
        int hp = GetSpecificIntStats(item, HP_INDEX);

        return hp;
    }

    public int GetWill(List<string> item) {
        const int WILL_INDEX = 10;
        int will = GetSpecificIntStats(item, WILL_INDEX);

        return will;
    }
    #endregion

    #region Get Final Damage Stats
    public int GetFinalDamage(List<string> item) {
        const int FINAL_DAMAGE_INDEX = 11;
        int finalDamage = GetSpecificIntStats(item, FINAL_DAMAGE_INDEX);

        return finalDamage;
    }

    public int GetFinalMeleeDamage(List<string> item) {
        const int FINAL_MELEE_DAMAGE_INDEX = 12;
        int finalMeleeDamage = GetSpecificIntStats(item, FINAL_MELEE_DAMAGE_INDEX);

        return finalMeleeDamage;
    }

    public int GetFinalRangeDamage(List<string> item) {
        const int FINAL_RANGE_DAMAGE_INDEX = 13;
        int finalRangeDamage = GetSpecificIntStats(item, FINAL_RANGE_DAMAGE_INDEX);

        return finalRangeDamage;
    }
    #endregion

    #region Get Damage Stats
    public int GetPower(List<string> item) {
        const int POWER_INDEX = 14;
        int power = GetSpecificIntStats(item, POWER_INDEX);

        return power;
    }


    public int GetFireDamage(List<string> item) {
        const int FIRE_DAMAGE_INDEX = 15;
        int fireDamage = GetSpecificIntStats(item, FIRE_DAMAGE_INDEX);

        return fireDamage;
    }

    public int GetWaterDamage(List<string> item) {
        const int WATER_DAMAGE_INDEX = 16;
        int waterDamage = GetSpecificIntStats(item, WATER_DAMAGE_INDEX);

        return waterDamage;
    }

    public int GetWindDamage(List<string> item) {
        const int WIND_DAMAGE_INDEX = 17;
        int windDamage = GetSpecificIntStats(item, WIND_DAMAGE_INDEX);

        return windDamage;
    }

    public int GetGroundDamage(List<string> item) {
        const int GROUND_DAMAGE_INDEX = 18;
        int groundDamage = GetSpecificIntStats(item, GROUND_DAMAGE_INDEX);

        return groundDamage;
    }

    public int GetLightDamage(List<string> item) {
        const int LIGHT_DAMAGE_INDEX = 19;
        int lightDamage = GetSpecificIntStats(item, LIGHT_DAMAGE_INDEX);

        return lightDamage;
    }

    public int GetDarkDamage(List<string> item) {
        const int DARK_DAMAGE_INDEX = 20;
        int darkDamage = GetSpecificIntStats(item, DARK_DAMAGE_INDEX);

        return darkDamage;
    }
    #endregion

    #region Get Resistance Stats
    public int GetDamageReflection(List<string> item) {
        const int DAMAGE_REFLECTION_INDEX = 21;
        int damageReflection = GetSpecificIntStats(item, DAMAGE_REFLECTION_INDEX);

        return damageReflection;
    }


    public int GetFireResistance(List<string> item) {
        const int FIRE_RESISTANCE_INDEX = 22;
        int fireResistance = GetSpecificIntStats(item, FIRE_RESISTANCE_INDEX);

        return fireResistance;
    }

    public int GetWaterResistance(List<string> item) {
        const int WATER_RESISTANCE_INDEX = 23;
        int waterResistance = GetSpecificIntStats(item, WATER_RESISTANCE_INDEX);

        return waterResistance;
    }

    public int GetWindResistance(List<string> item) {
        const int WIND_RESISTANCE_INDEX = 24;
        int windResistance = GetSpecificIntStats(item, WIND_RESISTANCE_INDEX);

        return windResistance;
    }

    public int GetGroundResistance(List<string> item) {
        const int GROUND_RESISTANCE_INDEX = 25;
        int groundResistance = GetSpecificIntStats(item, GROUND_RESISTANCE_INDEX);

        return groundResistance;
    }

    public int GetLightResistance(List<string> item) {
        const int LIGHT_RESISTANCE_INDEX = 26;
        int lightResistance = GetSpecificIntStats(item, LIGHT_RESISTANCE_INDEX);

        return lightResistance;
    }

    public int GetDarkResistance(List<string> item) {
        const int DARK_RESISTANCE_INDEX = 27;
        int darkResistance = GetSpecificIntStats(item, DARK_RESISTANCE_INDEX);

        return darkResistance;
    }
    #endregion

    private int GetSpecificIntStats(List<string> item, int statsIndex) {
        int stats = 0;

        if(item != null) {
            if(int.TryParse(item[statsIndex], out stats)) { }
            else {
                Debug.Log("Error: GetSpecificIntStats methode was not able to parse string to int.");
            }
        }

        return stats;
    }

    #region Get Main Stats
    public int GetTotalCost(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalCost = GetCost(helmet) + GetCost(armor) + GetCost(greave) + GetCost(boot) + GetCost(jewel);

        return totalCost;
    }

    public int GetTotalCost(int helmetId, int armorId, int greaveId, int bootsId, int jewelId) {
        int totalCost = 0;

        List<string> helmet = helmets.GetItem(helmetId);
        List<string> armor  = armors .GetItem(armorId);
        List<string> greave = greaves.GetItem(greaveId);
        List<string> boot   = boots  .GetItem(bootsId);
        List<string> jewel  = jewels .GetItem(jewelId);

        totalCost += GetCost(helmet);
        totalCost += GetCost(armor);
        totalCost += GetCost(greave);
        totalCost += GetCost(boot);
        totalCost += GetCost(jewel);

        return totalCost;
    }


    public int GetTotalAp(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalAp = GetAp(helmet) + GetAp(armor) + GetAp(greave) + GetAp(boot) + GetAp(jewel);

        return totalAp;
    }

    public int GetTotalMp(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalMp = GetMp(helmet) + GetMp(armor) + GetMp(greave) + GetMp(boot) + GetMp(jewel);

        return totalMp;
    }

    public int GetTotalRange(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalRange = GetRange(helmet) + GetRange(armor) + GetRange(greave) + GetRange(boot) + GetRange(jewel);

        return totalRange;
    }

    
    public int GetTotalHp(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalHp = GetHp(helmet) + GetHp(armor) + GetHp(greave) + GetHp(boot) + GetHp(jewel);

        return totalHp;
    }

    public int GetTotalWill(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalWill = GetWill(helmet) + GetWill(armor) + GetWill(greave) + GetWill(boot) + GetWill(jewel);

        return totalWill;
    }
    #endregion

    #region Get Final Damage Stats
    public int GetTotalFinalDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalFinalDamage = GetFinalDamage(helmet) + GetFinalDamage(armor) + GetFinalDamage(greave) + GetFinalDamage(boot) + GetFinalDamage(jewel);

        return totalFinalDamage;
    }

    public int GetTotalFinalMeleeDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalFinalMeleeDamage = GetFinalMeleeDamage(helmet) + GetFinalMeleeDamage(armor) + GetFinalMeleeDamage(greave) + GetFinalMeleeDamage(boot) + GetFinalMeleeDamage(jewel);

        return totalFinalMeleeDamage;
    }

    public int GetTotalFinalRangeDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalFinalRangeDamage = GetFinalRangeDamage(helmet) + GetFinalRangeDamage(armor) + GetFinalRangeDamage(greave) + GetFinalRangeDamage(boot) + GetFinalRangeDamage(jewel);

        return totalFinalRangeDamage;
    }
    #endregion

    #region Get Damage Stats
    public int GetTotalPower(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalPower = GetPower(helmet) + GetPower(armor) + GetPower(greave) + GetPower(boot) + GetPower(jewel);

        return totalPower;
    }


    public int GetTotalFireDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalFireDamage = GetFireDamage(helmet) + GetFireDamage(armor) + GetFireDamage(greave) + GetFireDamage(boot) + GetFireDamage(jewel);

        return totalFireDamage;
    }

    public int GetTotalWaterDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalWaterDamage = GetWaterDamage(helmet) + GetWaterDamage(armor) + GetWaterDamage(greave) + GetWaterDamage(boot) + GetWaterDamage(jewel);

        return totalWaterDamage;
    }

    public int GetTotalWindDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalWindDamage = GetWindDamage(helmet) + GetWindDamage(armor) + GetWindDamage(greave) + GetWindDamage(boot) + GetWindDamage(jewel);

        return totalWindDamage;
    }

    public int GetTotalGroundDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalGroundDamage = GetGroundDamage(helmet) + GetGroundDamage(armor) + GetGroundDamage(greave) + GetGroundDamage(boot) + GetGroundDamage(jewel);

        return totalGroundDamage;
    }

    public int GetTotalLightDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalLightDamage = GetLightDamage(helmet) + GetLightDamage(armor) + GetLightDamage(greave) + GetLightDamage(boot) + GetLightDamage(jewel);

        return totalLightDamage;
    }

    public int GetTotalDarkDamage(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalDarkDamage = GetDarkDamage(helmet) + GetDarkDamage(armor) + GetDarkDamage(greave) + GetDarkDamage(boot) + GetDarkDamage(jewel);

        return totalDarkDamage;
    }
    #endregion

    #region Get Resistance Stats
    public int GetTotalDamageReflection(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalDamageReflection = GetDamageReflection(helmet) + GetDamageReflection(armor) + GetDamageReflection(greave) + GetDamageReflection(boot) + GetDamageReflection(jewel);

        return totalDamageReflection;
    }


    public int GetTotalFireResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalFireResistance = GetFireResistance(helmet) + GetFireResistance(armor) + GetFireResistance(greave) + GetFireResistance(boot) + GetFireResistance(jewel);

        return totalFireResistance;
    }

    public int GetTotalWaterResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalWaterResistance = GetWaterResistance(helmet) + GetWaterResistance(armor) + GetWaterResistance(greave) + GetWaterResistance(boot) + GetWaterResistance(jewel);

        return totalWaterResistance;
    }

    public int GetTotalWindResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalWindResistance = GetWindResistance(helmet) + GetWindResistance(armor) + GetWindResistance(greave) + GetWindResistance(boot) + GetWindResistance(jewel);

        return totalWindResistance;
    }

    public int GetTotalGroundResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalGroundResistance = GetGroundResistance(helmet) + GetGroundResistance(armor) + GetGroundResistance(greave) + GetGroundResistance(boot) + GetGroundResistance(jewel);

        return totalGroundResistance;
    }

    public int GetTotalLightResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalLightResistance = GetLightResistance(helmet) + GetLightResistance(armor) + GetLightResistance(greave) + GetLightResistance(boot) + GetLightResistance(jewel);

        return totalLightResistance;
    }

    public int GetTotalDarkResistance(List<string> helmet, List<string> armor, List<string> greave, List<string> boot, List<string> jewel) {
        int totalDarkResistance = GetDarkResistance(helmet) + GetDarkResistance(armor) + GetDarkResistance(greave) + GetDarkResistance(boot) + GetDarkResistance(jewel);

        return totalDarkResistance;
    }
    #endregion

    public string GetStatsDescription(int itemStatIndex) {
        string description = "ERROR 404: Stat description not found.";

        if(itemStatIndex < ITEMS_STATS_DESCRIPTIONS.Length) {
            description = ITEMS_STATS_DESCRIPTIONS[itemStatIndex];
        }

        return description;
    }

    public string GetPercentWhenNeeded(int itemStatIndex) {
        string percentage = "";

        for(int i = 0; i < PERCENTAGE_STATS_INDEX.Length; i++) {
            if(itemStatIndex == PERCENTAGE_STATS_INDEX[i]) {
                percentage = "%";
                break;
            }
        }

        return percentage;
    }

    public Sprite GetIcon(int itemType, string name) {
        Sprite icon;

        switch (itemType)
        {
            case HELMET:
                icon = helmets.GetIcon(name); break;
            case ARMOR:
                icon = armors.GetIcon(name);  break;
            case GREAVE:
                icon = greaves.GetIcon(name); break;
            case BOOTS:
                icon = boots.GetIcon(name);   break;
            case JEWEL:
                icon = jewels.GetIcon(name);  break;
            default:
                icon = new Sprite(); break;
        }

        return icon;
    }


    #region INTER SCREEN PARAM
    public int ExtraParam_ItemType {
        get { return extraParam_ItemType;  }
        set { extraParam_ItemType = value; }
    }
    #endregion
}