/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CharacterCustomisation : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const int HELMET = 0;
    private const int ARMOR  = 1;
    private const int GREAVE = 2;
    private const int BOOTS  = 3;
    private const int JEWEL  = 4;

    private const int SKILL_1 = 0;
    private const int SKILL_2 = 1;
    private const int SKILL_3 = 2;
    private const int SKILL_4 = 3;
    private const int SKILL_5 = 4;

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

    private string selectedEquipmentEffect;
    private string selectedEquipmentLore;
    private string selectedSkillEffect;
    private string selectedSkillLore;

    // Info used by the Remove btn.
    bool isEquipmentSelected = false;
    bool isSkillSelected     = false;
    int? slotIndexSelected   = null;

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
    public GameObject equipmentView;
    public GameObject skillView;
    [Space(5)]
    public TMP_Text selectedName;
    public TMP_Text selectedEquipmentEffectAndLore;
    public TMP_Text selectedSkillEffectAndLore;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;
    public Button remove_btn;
    [Space(5)]
    public Text selectedSkillValue_Ap;
    public Text selectedSkillValue_Mp;
    public Text selectedSkillValue_Range;

    public Text selectedSkillValue_UpPo;
    public Text selectedSkillValue_Fov;
    public Text selectedSkillValue_Cil;

    public Text selectedSkillValue_Cd;
    public Text selectedSkillValue_Cpt;
    public Text selectedSkillValue_Cptpt;
    [Space(5)]
    public ScrollRect equipmentViewScrollRect;
    public ScrollRect skillViewScrollRect;
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

        ClearSelectionSection();

		LoadCharacterInfo();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void EquipmentButton(int equipmentSlot) { // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;
        int itemId = FindEquipmentId(equipmentSlot);

        // Keep in memory the selection for the Remove btn.
        isEquipmentSelected = true;
        isSkillSelected     = false;
        slotIndexSelected   = equipmentSlot;

        ClearSelectionSection();

        if(itemId != 0) {
            List<string> item;
            string itemName;
            Sprite itemSprite;

            switch (equipmentSlot)
            {
                case HELMET:
                    item       = helmets.GetItem(itemId);
                    itemName   = item[(int)Items.ITEM_INFO.NAME];
                    itemSprite = helmets.GetIcon(itemName);
                    break;
                case ARMOR:
                    item       = armors.GetItem(itemId);
                    itemName   = item[(int)Items.ITEM_INFO.NAME];
                    itemSprite = armors.GetIcon(itemName);
                    break;
                case GREAVE:
                    item       = greaves.GetItem(itemId);
                    itemName   = item[(int)Items.ITEM_INFO.NAME];
                    itemSprite = greaves.GetIcon(itemName);
                    break;
                case BOOTS:
                    item       = boots.GetItem(itemId);
                    itemName   = item[(int)Items.ITEM_INFO.NAME];
                    itemSprite = boots.GetIcon(itemName);
                    break;
                case JEWEL:
                    item       = jewels.GetItem(itemId);
                    itemName   = item[(int)Items.ITEM_INFO.NAME];
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
            selectedCost.text = "Cost: " + item[(int)Items.ITEM_INFO.COST];
            selectedName.text = itemName;

            // Define Effect.
            int nbEffectLine = 0;
            for(int i = (int)Items.ITEM_INFO.AP; i < item.Count; i++) {
                bool isEffectUsed = int.Parse(item[i]) != 0;

                if(isEffectUsed) {
                    string effectDescription = items.GetStatsDescription(i);
                    string effectValue       = item[i];
                    string percentDisplay    = items.GetPercentWhenNeeded(i);

                    string effectLine = effectDescription + effectValue + percentDisplay + "\n";
                    selectedEquipmentEffect += effectLine;

                    nbEffectLine++;
                }
            }

            // Define Lore.
            selectedEquipmentLore = item[(int)Items.ITEM_INFO.LORE];

            useEffectOrLore();

            equipmentView.SetActive(true);
            remove_btn.interactable = true;
        }
        else {
            navigation.NavigateTo_EquipmentSelection(currentTeamId, currentCharacterId, equipmentSlot);
        }
        
    }

    public void SkillButton(int skillSlot) { // 0 = Skill1; 1 = Skill2; 2 = Skill3; 3 = Skill4; 4 = Skill5;
        int skillId = FindSkillId(skillSlot);

        // Keep in memory the selection for the Remove btn.
        isEquipmentSelected = false;
        isSkillSelected     = true;
        slotIndexSelected   = skillSlot;

        ClearSelectionSection();

        if(skillId != 0) {
            string className = charactersData.classNames[currentCharacterDataKey];
            Skill skill = skillList.GetSkill(className, skillId);

            selectedIcon.sprite = skill.GetIcon();
            selectedCost.text = "Cost: " + skill.GetCost();

            selectedName.text = skill.GetName();

            // Show Skill main info.
            selectedSkillValue_Ap   .text = skill.GetApCost().ToString();
            selectedSkillValue_Mp   .text = skill.GetMpCost().ToString();
            selectedSkillValue_Range.text = skill.GetRangeDisplay();
            selectedSkillValue_UpPo .text = HelpingMethod.ConvertBoolToIndicator1(skill.GetFlexibleRange());
            selectedSkillValue_Fov  .text = HelpingMethod.ConvertBoolToIndicator1(skill.GetLineOfSight());
            selectedSkillValue_Cil  .text = HelpingMethod.ConvertBoolToIndicator1(skill.GetCastStraightLine());

            string skillCooldown             = "-"; if(skill.GetCooldown()             != 0) { skillCooldown             = skill.GetCooldown()            .ToString(); }
            string skillCastPerTurn          = "-"; if(skill.GetCastPerTurn()          != 0) { skillCastPerTurn          = skill.GetCastPerTurn()         .ToString(); }
            string skillCastPerTurnPerTarget = "-"; if(skill.GetCastPerTurnPerTarget() != 0) { skillCastPerTurnPerTarget = skill.GetCastPerTurnPerTarget().ToString(); }

            selectedSkillValue_Cd   .text = skillCooldown;
            selectedSkillValue_Cpt  .text = skillCastPerTurn;
            selectedSkillValue_Cptpt.text = skillCastPerTurnPerTarget;

            // Define Effect and Lore.
            selectedSkillEffect = skill.GetDescription();
            selectedSkillLore   = skill.GetLore();

            useEffectOrLore();

            skillView.SetActive(true);
            remove_btn.interactable = true;
        }
        else {
            navigation.NavigateTo_SkillSelection(currentTeamId, currentCharacterId);
        }
    }

    public void EffectButton() {
        effect_btn.interactable = false;
        lore_btn  .interactable = true;

        useEffectOrLore();
    }

    public void LoreButton() {
        lore_btn.  interactable = false;
        effect_btn.interactable = true;

        useEffectOrLore();
    }

    public void RemoveButton() {
        if(isEquipmentSelected) {
            RemoveEquipment();
            LoadEquipmentsSection();
        }
        else if(isSkillSelected) {
            RemoveSkill();
            LoadSkillsSection();
        }
        else {
            Debug.Log("Error: Impossible case encountered.");
        }

        // Reset the parameter in memory used by this btn.
        isEquipmentSelected = false;
        isSkillSelected     = false;
        slotIndexSelected   = null;

        // Reload...
        ClearSelectionSection();
        LoadCharacterInfo();
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
            string helmetName = helmet[(int)Items.ITEM_INFO.NAME];

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
            string armorName = armor[(int)Items.ITEM_INFO.NAME];

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
            string greaveName = greave[(int)Items.ITEM_INFO.NAME];

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
            string bootName = boot[(int)Items.ITEM_INFO.NAME];

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
            string jewelName = jewel[(int)Items.ITEM_INFO.NAME];

            Sprite jewelSprite = jewels.GetIcon(jewelName);

            equipmentIcons[JEWEL].sprite = jewelSprite;
        }
        else {
            equipmentIcons[JEWEL].sprite = resourceLoader.emptyIconJewel;
        }
    }

    private int FindEquipmentId(int index) {
        int equipmentId;

        switch (index)
        {
            case HELMET:
                equipmentId = charactersData.helmetIds[currentCharacterDataKey]; break;
            case ARMOR:
                equipmentId = charactersData.armorIds[currentCharacterDataKey];  break;
            case GREAVE:
                equipmentId = charactersData.greaveIds[currentCharacterDataKey]; break;
            case BOOTS:
                equipmentId = charactersData.bootsIds[currentCharacterDataKey];  break;
            case JEWEL:
                equipmentId = charactersData.jewelIds[currentCharacterDataKey];  break;
            default:
                equipmentId = 0;                                                 break;
        }

        return equipmentId;
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

    #region Removing
    private void RemoveEquipment() {
        List<string> item;
        int itemId = FindEquipmentId((int)slotIndexSelected);

        // Get the right item.
        switch (slotIndexSelected)
        {
            case HELMET:
                item = helmets.GetItem(itemId); break;
            case ARMOR:
                item = armors.GetItem(itemId);  break;
            case GREAVE:
                item = greaves.GetItem(itemId); break;
            case BOOTS:
                item = boots.GetItem(itemId);   break;
            case JEWEL:
                item = jewels.GetItem(itemId);  break;
            default:
                item = null;                    break;
        }
        
        // Reduce the character cost.
        int itemCost = int.Parse(item[(int)Items.ITEM_INFO.COST]);
        charactersData.costs[currentCharacterDataKey] -= itemCost;

        // Remove the item from the character data.
        switch (slotIndexSelected)
        {
            case HELMET:
                charactersData.helmetIds[currentCharacterDataKey] = 0;  break;
            case ARMOR:
                charactersData.armorIds[currentCharacterDataKey]  = 0;  break;
            case GREAVE:
                charactersData.greaveIds[currentCharacterDataKey] = 0;  break;
            case BOOTS:
                charactersData.bootsIds[currentCharacterDataKey]  = 0;  break;
            case JEWEL:
                charactersData.jewelIds[currentCharacterDataKey]  = 0;  break;
            default:
                break;
        }
    }

    private void RemoveSkill() {
        int    skillId   = FindSkillId((int)slotIndexSelected);
        string className = charactersData.classNames[currentCharacterDataKey];
        Skill  skill     = skillList.GetSkill(className, skillId);

        // Reduce the character cost.
        int skillCost = skill.GetCost();
        charactersData.costs[currentCharacterDataKey] -= skillCost;
        
        // Remove the skill from the character data.
        switch (slotIndexSelected)
        {
            case SKILL_1:
                charactersData.skillOneIds[currentCharacterDataKey]   = 0;  break;
            case SKILL_2:
                charactersData.skillTwoIds[currentCharacterDataKey]   = 0;  break;
            case SKILL_3:
                charactersData.skillThreeIds[currentCharacterDataKey] = 0;  break;
            case SKILL_4:
                charactersData.skillFourIds[currentCharacterDataKey]  = 0;  break;
            case SKILL_5:
                charactersData.skillFiveIds[currentCharacterDataKey]  = 0;  break;
            default:
                break;
        }

        charactersData.SortSkillId(currentCharacterDataKey);
    }


    private void ClearSelectionSection() {
        selectedIcon.sprite = null;
        selectedCost.text = "Cost: -";
        remove_btn.interactable = false;

        equipmentView.SetActive(false);
        skillView    .SetActive(false);

        selectedEquipmentEffect = "";
        selectedEquipmentLore   = "";
        selectedSkillEffect = "";
        selectedSkillLore   = "";

        selectedName.text = "";
        selectedEquipmentEffectAndLore.text = "";
        selectedSkillEffectAndLore    .text = "";
    }
    #endregion

    private void useEffectOrLore() {
        bool isEffect = !effect_btn.interactable;
        bool isLore   = !lore_btn  .interactable;

        if(isEffect) {
            selectedEquipmentEffectAndLore.text = selectedEquipmentEffect;
            selectedSkillEffectAndLore    .text = selectedSkillEffect;
        }
        else if(isLore) {
            selectedEquipmentEffectAndLore.text = selectedEquipmentLore;
            selectedSkillEffectAndLore    .text = selectedSkillLore;
        }
        else {
            Debug.Log("Error: Effect AND Lore btn aren't interactible!?!");
        }
        
        selectedEquipmentEffectAndLore.AdjustTMPBlockHeight();
        selectedSkillEffectAndLore    .AdjustTMPBlockHeight();

        ResetSelectionScrollBar();
    }

    private void ResetSelectionScrollBar() {
        equipmentViewScrollRect.ScrollToTop();
        skillViewScrollRect    .ScrollToTop();
    }

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