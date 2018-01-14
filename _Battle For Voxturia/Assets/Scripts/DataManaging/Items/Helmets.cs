/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    14 Janvier 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmets : MonoBehaviour {

    /* Items definition in list:

    "id", 
    "name", 
    "description", 
    "lvlRequire", 
    "shopCost",
    "cost", 

    "ap", 
    "mp", 
    "range", 

    "hp", 
    "will",

    "finalDamage", 
    "finalMeleeDamage", 
    "finalRangedDamage", 

    "power", 
    "fireDamage", 
    "waterDamage", 
    "windDamage", 
    "groundDamage", 
    "lightDamage", 
    "darkDamage",

    "damageReflection", 
    "fireResistance", 
    "waterResistance", 
    "windResistance", 
    "groundResistance", 
    "lightResistance", 
    "darkResistance"

    */

    /* Item template
    private List<string> template = new List<string>() 
    {
        "0", // Id

        "ARMOR_NAME_TEST", // Name
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", // Description
        "666",       // Level Requirment
        "1000",      // shopCost
        "999999999", // Cost

        "1", // Ap
        "2", // Mp
        "3", // Range

        "1000", // Hp
        "5000", // Will

        "100", // Final Damage
        "50",  // Final Melee Damage
        "50",  // Final Ranged Damage

        "100", // Power
        "20",  // Fire Damage
        "20",  // Water Damage
        "20",  // Wind Damage
        "20",  // Ground Damage
        "20",  // Light Damage
        "20",  // Dark Damage

        "10", // Damage Reflection
        "25", // Fire Resistance
        "25", // Water Resistance
        "25", // Wind Resistance
        "25", // Ground Resistance
        "25", // Light Resistance
        "25"  // Dark Resistance
    };
    */

    #region DECLARATION
    // CONST

    // PRIVATE
    private List<List<string>> list = new List<List<string>>();

    #region Helmets list
    // TEST
    private List<string> test = new List<string>() 
    {
        "666", // Id

        "HELMET_NAME_TEST", // Name
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", // Description
        "666",       // Level Requirment
        "1000",      // shopCost
        "999999999", // Cost

        "1", // Ap
        "2", // Mp
        "3", // Range

        "1000", // Hp
        "5000", // Will

        "100", // Final Damage
        "50",  // Final Melee Damage
        "50",  // Final Ranged Damage

        "100", // Power
        "20",  // Fire Damage
        "20",  // Water Damage
        "20",  // Wind Damage
        "20",  // Ground Damage
        "20",  // Light Damage
        "20",  // Dark Damage

        "10", // Damage Reflection
        "25", // Fire Resistance
        "25", // Water Resistance
        "25", // Wind Resistance
        "25", // Ground Resistance
        "25", // Light Resistance
        "25"  // Dark Resistance
    };

    // Level 1

    // Level 2

    // Level 3

    // Level 4

    // Level 5

    // Level 6

    // Level 7

    // Level 8

    // Level 9

    // Level 10

    // Level 11

    // Level 12

    // Level 13

    // Level 14

    // Level 15

    // Level 16

    // Level 17

    // Level 18

    // Level 19

    // Level 20

    // Level 21

    // Level 22

    // Level 23

    // Level 24

    // Level 25

    // Level 26

    // Level 27

    // Level 28

    // Level 29

    // Level 30

    // Level 31

    // Level 32

    // Level 33

    // Level 34

    // Level 35

    // Level 36

    // Level 37

    // Level 38

    // Level 39

    // Level 40

    // Level 41

    // Level 42

    // Level 43

    // Level 44

    // Level 45

    // Level 46

    // Level 47

    // Level 48

    // Level 49

    // Level 50

    #endregion

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        list.Add(test);
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

    public List<string> GetItem(int paramId) {
        List<string> wantedItem = null;

        if(paramId != 0) {
            string id = paramId.ToString();

            const int ID_INDEX = 0;
            for(int i = 0; i < list.Count; i++) {
                List<string> item = list[i];
                string       itemId = item[ID_INDEX];

                if(itemId == id) {
                    wantedItem = item; 
                    break;
                }
            }
        }

        return wantedItem;
    }

    /*
    #region Get Main Stats
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

        if(int.TryParse(item[statsIndex], out stats)) { }
        else {
            Debug.Log("Error: GetSpecificIntStats methode was not able to parse string to int.");
        }

        return stats;
    }*/
}