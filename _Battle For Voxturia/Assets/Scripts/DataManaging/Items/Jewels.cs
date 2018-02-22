/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    14 Janvier 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewels : MonoBehaviour {

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
    const int NAME_INDEX = 1;

    // PRIVATE
    private List      <List<string>>   list             = new List<List<string>>();
    private Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    #region Jewels list
    // TEST
    public Sprite JEWEL_TEST_1_icon;
    private List<string> JEWEL_TEST_1 = new List<string>() 
    {
        "1000001", // Id

        "JEWEL_TEST_1", // Name
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", // Description
        "1",       // Level Requirment
        "1000",      // shopCost
        "5000",       // Cost

        "2", // Ap
        "1", // Mp
        "1", // Range

        "0", // Hp
        "200", // Will

        "20", // Final Damage
        "0",  // Final Melee Damage
        "0",  // Final Ranged Damage

        "20", // Power
        "0",  // Fire Damage
        "0",  // Water Damage
        "0",  // Wind Damage
        "0",  // Ground Damage
        "0",  // Light Damage
        "0",  // Dark Damage

        "5", // Damage Reflection
        "0", // Fire Resistance
        "0", // Water Resistance
        "0", // Wind Resistance
        "0", // Ground Resistance
        "0", // Light Resistance
        "0"  // Dark Resistance
    };

    public Sprite JEWEL_TEST_2_icon;
    private List<string> JEWEL_TEST_2 = new List<string>() 
    {
        "1000002", // Id

        "JEWEL_TEST_2", // Name
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", // Description
        "1",       // Level Requirment
        "1000",      // shopCost
        "5000",       // Cost

        "2", // Ap
        "1", // Mp
        "1", // Range

        "0", // Hp
        "200", // Will

        "20", // Final Damage
        "0",  // Final Melee Damage
        "0",  // Final Ranged Damage

        "20", // Power
        "0",  // Fire Damage
        "0",  // Water Damage
        "0",  // Wind Damage
        "0",  // Ground Damage
        "0",  // Light Damage
        "0",  // Dark Damage

        "5", // Damage Reflection
        "0", // Fire Resistance
        "0", // Water Resistance
        "0", // Wind Resistance
        "0", // Ground Resistance
        "0", // Light Resistance
        "0"  // Dark Resistance
    };

    public Sprite JEWEL_TEST_3_icon;
    private List<string> JEWEL_TEST_3 = new List<string>() 
    {
        "1000003", // Id

        "JEWEL_TEST_3", // Name
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", // Description
        "2",       // Level Requirment
        "1000",      // shopCost
        "5000",       // Cost

        "2", // Ap
        "1", // Mp
        "1", // Range

        "0", // Hp
        "200", // Will

        "20", // Final Damage
        "0",  // Final Melee Damage
        "0",  // Final Ranged Damage

        "20", // Power
        "0",  // Fire Damage
        "0",  // Water Damage
        "0",  // Wind Damage
        "0",  // Ground Damage
        "0",  // Light Damage
        "0",  // Dark Damage

        "5", // Damage Reflection
        "0", // Fire Resistance
        "0", // Water Resistance
        "0", // Wind Resistance
        "0", // Ground Resistance
        "0", // Light Resistance
        "0"  // Dark Resistance
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
        // TEST
        list.Add(JEWEL_TEST_1);
        spriteDictionary.Add(JEWEL_TEST_1[NAME_INDEX], JEWEL_TEST_1_icon);

        list.Add(JEWEL_TEST_2);
        spriteDictionary.Add(JEWEL_TEST_2[NAME_INDEX], JEWEL_TEST_2_icon);

        list.Add(JEWEL_TEST_3);
        spriteDictionary.Add(JEWEL_TEST_3[NAME_INDEX], JEWEL_TEST_3_icon);

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

    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

    public List<List<string>> GetAllItems() {
        return list;
    }

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

    public Sprite GetIcon(string name) {
        Sprite icon;

        spriteDictionary.TryGetValue(name, out icon);

        return icon;
    }

}