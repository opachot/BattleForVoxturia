/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterCustomisation : MonoBehaviour {

    #region DECLARATION
    // CONST
    const int HELMET = 0;
    const int ARMOR  = 1;
    const int GREAVE = 2;
    const int BOOTS  = 3;
    const int JEWEL  = 4;

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;

    private Items   items;
    private Helmets helmets;
    private Armors  armors;
    private Greaves greaves;
    private Boots   boots;
    private Jewels  jewels;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;

    // PUBLIC
    [Header("Equipment Section")]
    public Image[] equipmentIcons = new Image[5];
    [Space(10)]

    [Header("Skill Section")]
    public Image[] skillIcons = new Image[5];
    [Space(10)]

    [Header("Character Info Section")]
    public Text       characterName;
    public Image      characterIcon;
    [Space(5)]
    public Text level;
    public Text xp;
    public Text cost;
    [Space(5)]
    public Text ap;
    public Text mp;
    public Text range;
    [Space(5)]
    public Text hp;
    public Text will;
    [Space(5)]
    public Text finalDamage;
    public Text finalMeleeDamage;
    public Text finalRangeDamage;
    [Space(5)]
    public Text power;
    public Text fireDamage;
    public Text waterDamage;
    public Text windDamage;
    public Text groundDamage;
    public Text lightDamage;
    public Text darkDamage;
    [Space(5)]
    public Text damageReflection;
    public Text fireResistance;
    public Text waterResistance;
    public Text windResistance;
    public Text groundResistance;
    public Text lightResistance;
    public Text darkResistance;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();

        // The list of all the items.
        GameObject itemsHolder = GameObject.FindGameObjectWithTag("Items");
        items   = itemsHolder.GetComponent<Items>();
        helmets = itemsHolder.GetComponent<Helmets>();
        armors  = itemsHolder.GetComponent<Armors>();
        greaves = itemsHolder.GetComponent<Greaves>();
        boots   = itemsHolder.GetComponent<Boots>();
        jewels  = itemsHolder.GetComponent<Jewels>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();

        LoadEquipmentsSection();
        LoadSkillsSection();

		LoadCharacterInfo();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void EquipmentButton(int equipmentIndex) { // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;
        
    }

    public void SkillButton() {
        
    }

    public void RemoveButton() {
        
    }

    public void StatsButton() {
        
    }

    public void LoreButton() {
        
    }

    public void ReturnButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }
    #endregion


    private void UseExtraParam() {
        currentTeamId      = charactersData.ExtraParam_TeamId;
        currentCharacterId = charactersData.ExtraParam_CharacterId;

        charactersData.ExtraParam_TeamId      = 0;
        charactersData.ExtraParam_CharacterId = 0;
    }

    private void FindCharacterDataKey() {
        for(int i = 0; i < charactersData.ids.Count; i++) {
            if(charactersData.ids[i] == currentCharacterId) {
                currentCharacterDataKey = i;
                break;
            }
        }
    }

    #region Load Equipment
    private void LoadEquipmentsSection() {
        LoadHelmet();
        LoadArmor();
        LoadGreave();
        LoadBoots();
        LoadJewels();
    }


    private void LoadHelmet() {
        const int NAME_INDEX = 1;

        int helmetId = charactersData.helmetIds[currentCharacterDataKey];

        if(helmetId != 0) {
            List<string> helmet = helmets.GetItem(helmetId);
            string helmetName = helmet[NAME_INDEX];

            Sprite helmetSprite = helmets.GetIcon(helmetName);

            equipmentIcons[HELMET].sprite = helmetSprite;
        }
        else {
            equipmentIcons[HELMET].sprite = resourceLoader.emptyIconHelmet;
        }
    }

    private void LoadArmor() {
        const int NAME_INDEX = 1;

        int armorId = charactersData.armorIds[currentCharacterDataKey];

        if(armorId != 0) {
            List<string> armor = armors.GetItem(armorId);
            string armorName = armor[NAME_INDEX];

            Sprite armorSprite = armors.GetIcon(armorName);

            equipmentIcons[ARMOR].sprite = armorSprite;
        }
        else {
            equipmentIcons[ARMOR].sprite = resourceLoader.emptyIconArmor;
        }
    }

    private void LoadGreave() {
        const int NAME_INDEX = 1;

        int greaveId = charactersData.greaveIds[currentCharacterDataKey];

        if(greaveId != 0) {
            List<string> greave = greaves.GetItem(greaveId);
            string greaveName = greave[NAME_INDEX];

            Sprite greaveSprite = greaves.GetIcon(greaveName);

            equipmentIcons[GREAVE].sprite = greaveSprite;
        }
        else {
            equipmentIcons[GREAVE].sprite = resourceLoader.emptyIconGreave;
        }
    }

    private void LoadBoots() {
        const int NAME_INDEX = 1;

        int bootId = charactersData.bootsIds[currentCharacterDataKey];

        if(bootId != 0) {
            List<string> boot = boots.GetItem(bootId);
            string bootName = boot[NAME_INDEX];

            Sprite bootSprite = boots.GetIcon(bootName);

            equipmentIcons[BOOTS].sprite = bootSprite;
        }
        else {
            equipmentIcons[BOOTS].sprite = resourceLoader.emptyIconBoots;
        }
    }

    private void LoadJewels() {
        const int NAME_INDEX = 1;

        int jewelId = charactersData.jewelIds[currentCharacterDataKey];

        if(jewelId != 0) {
            List<string> jewel = jewels.GetItem(jewelId);
            string jewelName = jewel[NAME_INDEX];

            Sprite jewelSprite = jewels.GetIcon(jewelName);

            equipmentIcons[JEWEL].sprite = jewelSprite;
        }
        else {
            equipmentIcons[JEWEL].sprite = resourceLoader.emptyIconJewel;
        }
    }
    #endregion

    #region Load Skill
    private void LoadSkillsSection() {
        for(int i = 0; i < skillIcons.Length; i++) {
            if(FindSkillId(i) != 0) {
                // TODO: skillIcons[i].sprite = ;
            }
            else {
                skillIcons[i].sprite = resourceLoader.emptyIconSkill;
            }
        }
    }

    private int FindSkillId(int index) {
        int skillId;

        switch (index)
        {
            case 0:
                skillId = charactersData.skillOneIds[currentCharacterDataKey];   break;
            case 1:
                skillId = charactersData.skillTwoIds[currentCharacterDataKey];   break;
            case 2:
                skillId = charactersData.skillThreeIds[currentCharacterDataKey]; break;
            case 3:
                skillId = charactersData.skillFourIds[currentCharacterDataKey];  break;
            case 4:
                skillId = charactersData.skillFiveIds[currentCharacterDataKey];  break;
            default:
                skillId = 0;                                                     break;
        }

        return skillId;
    }
    #endregion

    private void LoadCharacterInfo() {
        string className = charactersData.classNames[currentCharacterDataKey];
        string currentXp = charactersData.currentXps[currentCharacterDataKey].ToString();
        string goalXp    = charactersData.goalXps   [currentCharacterDataKey].ToString();

        characterName.text   = charactersData.names [currentCharacterDataKey];
        characterIcon.sprite = charactersData.GetCharacterIcon(className);

        level.text = charactersData.levels[currentCharacterDataKey].ToString();
        xp   .text = currentXp + "/" + goalXp;

        List<string> helmet = helmets.GetItem(charactersData.helmetIds[currentCharacterDataKey]);
        List<string> armor  = armors .GetItem(charactersData.armorIds [currentCharacterDataKey]);
        List<string> greave = greaves.GetItem(charactersData.greaveIds[currentCharacterDataKey]);
        List<string> boot   = boots  .GetItem(charactersData.bootsIds [currentCharacterDataKey]);
        List<string> jewel  = jewels .GetItem(charactersData.jewelIds [currentCharacterDataKey]);


        int totalCost = charactersData.GetCost() + items.GetTotalCost(helmet, armor, greave, boot, jewel);

        int totalAp    = charactersData.GetAp() + items.GetTotalAp   (helmet, armor, greave, boot, jewel);
        int totalMp    = charactersData.GetMp() + items.GetTotalMp   (helmet, armor, greave, boot, jewel);
        int totalRange =                          items.GetTotalRange(helmet, armor, greave, boot, jewel);

        int totalHp   = charactersData.GetHp  (currentCharacterDataKey) + items.GetTotalHp  (helmet, armor, greave, boot, jewel);
        int totalWill = charactersData.GetWill(currentCharacterDataKey) + items.GetTotalWill(helmet, armor, greave, boot, jewel);

        int totalFinalDamage      = items.GetTotalFinalDamage     (helmet, armor, greave, boot, jewel);
        int totalFinalMeleeDamage = items.GetTotalFinalMeleeDamage(helmet, armor, greave, boot, jewel);
        int totalFinalRangeDamage = items.GetTotalFinalRangeDamage(helmet, armor, greave, boot, jewel);

        int totalPower        = items.GetTotalPower           (helmet, armor, greave, boot, jewel);
        int totalFireDamage   = items.GetTotalFireResistance  (helmet, armor, greave, boot, jewel);
        int totalWaterDamage  = items.GetTotalWaterResistance (helmet, armor, greave, boot, jewel);
        int totalWindDamage   = items.GetTotalWindResistance  (helmet, armor, greave, boot, jewel);
        int totalGroundDamage = items.GetTotalGroundResistance(helmet, armor, greave, boot, jewel);
        int totalLightDamage  = items.GetTotalLightResistance (helmet, armor, greave, boot, jewel);
        int totalDarkDamage   = items.GetTotalDarkResistance  (helmet, armor, greave, boot, jewel);

        int totalDamageReflection =                                                 items.GetTotalDamageReflection(helmet, armor, greave, boot, jewel);
        int totalFireResistance   = charactersData.GetFireResistance  (className) + items.GetTotalFireResistance  (helmet, armor, greave, boot, jewel);
        int totalWaterResistance  = charactersData.GetWaterResistance (className) + items.GetTotalWaterResistance (helmet, armor, greave, boot, jewel);
        int totalWindResistance   = charactersData.GetWindResistance  (className) + items.GetTotalWindResistance  (helmet, armor, greave, boot, jewel);
        int totalGroundResistance = charactersData.GetGroundResistance(className) + items.GetTotalGroundResistance(helmet, armor, greave, boot, jewel);
        int totalLightResistance  = charactersData.GetLightResistance (className) + items.GetTotalLightResistance (helmet, armor, greave, boot, jewel);
        int totalDarkResistance   = charactersData.GetDarkResistance  (className) + items.GetTotalDarkResistance  (helmet, armor, greave, boot, jewel);


        cost.text = totalCost.ToString();

        ap   .text = totalAp   .ToString();
        mp   .text = totalMp   .ToString();
        range.text = totalRange.ToString();

        hp  .text = totalHp  .ToString();
        will.text = totalWill.ToString();
        
        finalDamage     .text = totalFinalDamage      + "%";
        finalMeleeDamage.text = totalFinalMeleeDamage + "%";
        finalRangeDamage.text = totalFinalRangeDamage + "%";
        
        power       .text = totalPower       .ToString();
        fireDamage  .text = totalFireDamage  .ToString();
        waterDamage .text = totalWaterDamage .ToString();
        windDamage  .text = totalWindDamage  .ToString();
        groundDamage.text = totalGroundDamage.ToString();
        lightDamage .text = totalLightDamage .ToString();
        darkDamage  .text = totalDarkDamage  .ToString();
        
        damageReflection.text = totalDamageReflection + "%";
        fireResistance  .text = totalFireResistance   + "%";
        waterResistance .text = totalWaterResistance  + "%";
        windResistance  .text = totalWindResistance   + "%";
        groundResistance.text = totalGroundResistance + "%";
        lightResistance .text = totalLightResistance  + "%";
        darkResistance  .text = totalDarkResistance   + "%";
    }
    
}