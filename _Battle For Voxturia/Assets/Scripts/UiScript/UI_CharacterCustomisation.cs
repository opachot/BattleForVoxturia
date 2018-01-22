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

    const int SKILL_1 = 0;
    const int SKILL_2 = 1;
    const int SKILL_3 = 2;
    const int SKILL_4 = 3;
    const int SKILL_5 = 4;

    enum ITEM_INFO {
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

    const int NB_MAX_EFFECT_LINE_PER_SIDE = 10;

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

    private SkillList skillList;

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
    [Space(10)]

    [Header("Selection Section")]
    public Image selectedIcon;
    public Text  selectedCost;
    [Space(5)]
    public Text selectedEffect_left;
    public Text selectedEffect_right;
    
    [Space(5)]
    public Text selectedName;
    public Text selectedLore;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;
    public Button remove_btn;

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

        // The list of all the skills.
        GameObject skillsHolder = GameObject.FindGameObjectWithTag("Skills");
        skillList = skillsHolder.GetComponent<SkillList>();
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
    public void EquipmentButton(int equipmentSlot) { // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;
        int itemId;

        switch (equipmentSlot)
        {
            case HELMET:
                itemId = charactersData.helmetIds[currentCharacterDataKey]; break;
            case ARMOR:
                itemId = charactersData.armorIds[currentCharacterDataKey];  break;
            case GREAVE:
                itemId = charactersData.greaveIds[currentCharacterDataKey]; break;
            case BOOTS:
                itemId = charactersData.bootsIds[currentCharacterDataKey];  break;
            case JEWEL:
                itemId = charactersData.jewelIds[currentCharacterDataKey];  break;
            default:
                itemId = 0;                                                 break;
        }

        if(itemId != 0) {
            List<string> item;
            string itemName;
            Sprite itemSprite;

            switch (equipmentSlot)
            {
                case HELMET:
                    item       = helmets.GetItem(itemId);
                    itemName   = item[(int)ITEM_INFO.NAME];
                    itemSprite = helmets.GetIcon(itemName);
                    break;
                case ARMOR:
                    item       = armors.GetItem(itemId);
                    itemName   = item[(int)ITEM_INFO.NAME];
                    itemSprite = armors.GetIcon(itemName);
                    break;
                case GREAVE:
                    item       = greaves.GetItem(itemId);
                    itemName   = item[(int)ITEM_INFO.NAME];
                    itemSprite = greaves.GetIcon(itemName);
                    break;
                case BOOTS:
                    item       = boots.GetItem(itemId);
                    itemName   = item[(int)ITEM_INFO.NAME];
                    itemSprite = boots.GetIcon(itemName);
                    break;
                case JEWEL:
                    item       = jewels.GetItem(itemId);
                    itemName   = item[(int)ITEM_INFO.NAME];
                    itemSprite = jewels.GetIcon(itemName);
                    break;
                default:
                    item       = null;
                    itemName   = null;
                    itemSprite = null;
                    break;
            }

            // Set visual element.
            selectedIcon.sprite = itemSprite;
            selectedCost.text = "Cost: " + item[(int)ITEM_INFO.COST];

            selectedEffect_left .text = "";
            selectedEffect_right.text = "";

            int nbEffectLine = 0;
            for(int i = (int)ITEM_INFO.AP; i < item.Count; i++) {
                bool isEffectUsed = int.Parse(item[i]) != 0;

                if(isEffectUsed) {
                    string effectDescription = items.GetStatsDescription(i);
                    string effectValue       = item[i];
                    string percentDisplay    = items.GetPercentWhenNeeded(i);

                    string effectLine = effectDescription + effectValue + percentDisplay + "\n";

                    bool isSpaceAvailableLeftSide = nbEffectLine < NB_MAX_EFFECT_LINE_PER_SIDE;
                    if(isSpaceAvailableLeftSide) {
                        selectedEffect_left.text += effectLine;
                    }
                    else {
                        selectedEffect_right.text += effectLine;
                    }

                    nbEffectLine++;
                }
            }

            selectedName.text = itemName;
            selectedLore.text = item[(int)ITEM_INFO.LORE];

            remove_btn.interactable = true;
        }
        else {
            navigation.NavigateTo_EquipmentSelection(currentTeamId, currentCharacterId, equipmentSlot);
        }
        
    }

    public void SkillButton(int skillSlot) { // 0 = Skill1; 1 = Skill2; 2 = Skill3; 3 = Skill4; 4 = Skill5;
        int skillId = FindSkillId(skillSlot);

        if(skillId != 0) {
            string className = charactersData.classNames[currentCharacterDataKey];
            Skill skill = skillList.GetSkill(className, skillId);

            selectedIcon.sprite = skill.GetIcon();
            selectedCost.text = "Cost: " + skill.GetCost();

            selectedName.text = skill.GetName();
            selectedLore.text = skill.GetLore();

            selectedEffect_left .text = skill.GetDescription();
            selectedEffect_right.text = "";
            
            remove_btn.interactable = true;
        }
        else {
            navigation.NavigateTo_SkillSelection(currentTeamId, currentCharacterId);
        }
    }

    public void EffectButton() {
        effect_btn.interactable = false;
        selectedName.gameObject.SetActive(false);
        selectedLore.gameObject.SetActive(false);

        lore_btn.interactable = true;
        selectedEffect_left .gameObject.SetActive(true);
        selectedEffect_right.gameObject.SetActive(true);
    }

    public void LoreButton() {
        lore_btn.interactable = false;
        selectedEffect_left .gameObject.SetActive(false);
        selectedEffect_right.gameObject.SetActive(false);

        effect_btn.interactable = true;
        selectedName.gameObject.SetActive(true);
        selectedLore.gameObject.SetActive(true);
    }

    public void RemoveButton() {
        // TODO: Remove the id from character data (Replaced by 0, not actual delete of index!!!!) and decrement cost in the character data. Reload info section and depending of the case the equipment or skill section.
        // TODO: If removing a skill, need to resort them in the character skills ids data.
        // TODO: Empty the stats/lore area, disable remove btn and empty the icon on the selection area.
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
        int helmetId = charactersData.helmetIds[currentCharacterDataKey];

        if(helmetId != 0) {
            List<string> helmet = helmets.GetItem(helmetId);
            string helmetName = helmet[(int)ITEM_INFO.NAME];

            Sprite helmetSprite = helmets.GetIcon(helmetName);

            equipmentIcons[HELMET].sprite = helmetSprite;
        }
        else {
            equipmentIcons[HELMET].sprite = resourceLoader.emptyIconHelmet;
        }
    }

    private void LoadArmor() {
        int armorId = charactersData.armorIds[currentCharacterDataKey];

        if(armorId != 0) {
            List<string> armor = armors.GetItem(armorId);
            string armorName = armor[(int)ITEM_INFO.NAME];

            Sprite armorSprite = armors.GetIcon(armorName);

            equipmentIcons[ARMOR].sprite = armorSprite;
        }
        else {
            equipmentIcons[ARMOR].sprite = resourceLoader.emptyIconArmor;
        }
    }

    private void LoadGreave() {
        int greaveId = charactersData.greaveIds[currentCharacterDataKey];

        if(greaveId != 0) {
            List<string> greave = greaves.GetItem(greaveId);
            string greaveName = greave[(int)ITEM_INFO.NAME];

            Sprite greaveSprite = greaves.GetIcon(greaveName);

            equipmentIcons[GREAVE].sprite = greaveSprite;
        }
        else {
            equipmentIcons[GREAVE].sprite = resourceLoader.emptyIconGreave;
        }
    }

    private void LoadBoots() {
        int bootId = charactersData.bootsIds[currentCharacterDataKey];

        if(bootId != 0) {
            List<string> boot = boots.GetItem(bootId);
            string bootName = boot[(int)ITEM_INFO.NAME];

            Sprite bootSprite = boots.GetIcon(bootName);

            equipmentIcons[BOOTS].sprite = bootSprite;
        }
        else {
            equipmentIcons[BOOTS].sprite = resourceLoader.emptyIconBoots;
        }
    }

    private void LoadJewels() {
        int jewelId = charactersData.jewelIds[currentCharacterDataKey];

        if(jewelId != 0) {
            List<string> jewel = jewels.GetItem(jewelId);
            string jewelName = jewel[(int)ITEM_INFO.NAME];

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
            int skillId = FindSkillId(i);

            if(skillId != 0) {
                string className = charactersData.classNames[currentCharacterDataKey];

                Sprite skillSprite = skillList.GetSkillSprite(className, skillId);

                skillIcons[i].sprite = skillSprite;
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
            case SKILL_1:
                skillId = charactersData.skillOneIds[currentCharacterDataKey];   break;
            case SKILL_2:
                skillId = charactersData.skillTwoIds[currentCharacterDataKey];   break;
            case SKILL_3:
                skillId = charactersData.skillThreeIds[currentCharacterDataKey]; break;
            case SKILL_4:
                skillId = charactersData.skillFourIds[currentCharacterDataKey];  break;
            case SKILL_5:
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

        int totalCost = charactersData.costs[currentCharacterDataKey];

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