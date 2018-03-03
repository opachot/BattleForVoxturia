/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 February 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SkillSelection : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;

    private Transform list;
    private List<Transform> skillButtonList = new List<Transform>();

    private SkillList skillList;
    private List<Skill> classSkillList;
    private List<Skill> displayedSkillList = new List<Skill>();
            
    private Skill     selectedSkill;
    private Transform highlightedSkillButton;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;

    private string className;

    // PUBLIC
    public Button selectSkill_btn;
    [Space(10)]

    [Header("Skill Info Section")]
    public TMP_Text     skillName;
    public Image    skillIcon;
    public TMP_Text skillCost;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;
    [Space(5)]
    public TMP_Text effectAndLoreText;
    [Space(5)]
    public Text skillValue_Ap;
    public Text skillValue_Mp;
    public Text skillValue_Range;

    public Text skillValue_UpPo;
    public Text skillValue_Fov;
    public Text skillValue_Cil;

    public Text skillValue_Cd;
    public Text skillValue_Cpt;
    public Text skillValue_Cptpt;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();

        list = GameObject.Find("List").GetComponent<Transform>();

        // The list of all the skills.
        GameObject skillsHolder = GameObject.FindGameObjectWithTag("Skills");
        skillList = skillsHolder.GetComponent<SkillList>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();

        LoadSkillsList();
        ClearSkillInfo();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void SkillButton(Transform clickedSkillBtn) {
        int? skillIndex = FindSkillIndex(clickedSkillBtn);

        if(skillIndex != null) {
            if(selectedSkill != displayedSkillList[(int)skillIndex]) {
                selectedSkill = displayedSkillList[(int)skillIndex];
                selectSkill_btn.interactable = true;
                
                LoadSkillInfo(selectedSkill);
            }
            else {
                selectedSkill = null;
                selectSkill_btn.interactable = false;
                ClearSkillInfo();
            }

            ModifieSkillButtonVisual(clickedSkillBtn);
            HelpingMethod.ClearEventSystemButtonHighlighted();
        }
        else {
            Debug.Log("Error 404: Skill index not found!");
        }
    }

    public void SelectButton() {
        charactersData.AddSkill(currentCharacterDataKey, selectedSkill);

        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void CancelButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void EffectButton() {
        effect_btn.interactable = false;
        lore_btn  .interactable = true;

        LoadEffectOrLore();
    }

    public void LoreButton() {
        lore_btn  .interactable = false;
        effect_btn.interactable = true;

        LoadEffectOrLore();
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

        className = charactersData.classNames[currentCharacterDataKey];
    }

    #region Skill list loading
    private void LoadSkillsList() {
        classSkillList = skillList.FindClassSkillList(className);

        foreach(Skill skill in classSkillList) {
            if(!IsSkillAlreadyUsed(skill)) {
                InstantiateSkillInList(skill);
            }
        }
    }

    private bool IsSkillAlreadyUsed(Skill skill) {
        int skillId = skill.GetId();

        int characterSkillOne   = charactersData.skillOneIds  [currentCharacterDataKey];
        int characterSkillTwo   = charactersData.skillTwoIds  [currentCharacterDataKey];
        int characterSkillThree = charactersData.skillThreeIds[currentCharacterDataKey];
        int characterSkillFour  = charactersData.skillFourIds [currentCharacterDataKey];
        int characterSkillFive  = charactersData.skillFiveIds [currentCharacterDataKey];

        bool isSkillAlreadyUsed = skillId == characterSkillOne   ||
                                  skillId == characterSkillTwo   ||
                                  skillId == characterSkillThree ||
                                  skillId == characterSkillFour  ||
                                  skillId == characterSkillFive;

        return isSkillAlreadyUsed;
    }

    private void InstantiateSkillInList(Skill skill) {
        Transform listElement = Instantiate(resourceLoader.skillAndEquipmentListingElement, list).transform;

        FixListElementButton(listElement, skill);

        skillButtonList.Add(listElement);
        displayedSkillList.Add(skill);
    }

    private void FixListElementButton(Transform listElement, Skill skill) {
        // Set skillButton onClick event.
        Button skillButton = listElement.GetComponent<Button>();
        skillButton.onClick.AddListener(() => SkillButton(listElement));

        // Set skill icon.
        Transform iconTransform = listElement.FindDeepChild("Icon");
        Image     iconImage     = iconTransform.GetComponent<Image>();
        iconImage.sprite = skill.GetIcon();

        // Set skill name.
        Transform nameTransform = listElement.FindDeepChild("Name");
        TMP_Text  nameText      = nameTransform.GetComponent<TMP_Text>();
        nameText.text = skill.GetName();

        // Set skill cost.
        Transform costTransform = listElement.FindDeepChild("Cost");
        TMP_Text  costText      = costTransform.GetComponent<TMP_Text>();
        costText.text = "Cost: " + skill.GetCost();
    }
    #endregion


    private void LoadSkillInfo(Skill skill) {
        skillName.text   = skill.GetName();
        skillIcon.sprite = skill.GetIcon();
        skillCost.text   = "Cost: " + skill.GetCost();

        LoadEffectOrLore();

        skillValue_Ap.transform.parent.gameObject.SetActive(true);

        skillValue_Ap   .text = skill.GetApCost().ToString();
        skillValue_Mp   .text = skill.GetMpCost().ToString();
        skillValue_Range.text = skill.GetRangeDisplay();
        skillValue_UpPo .text = HelpingMethod.ConvertBoolToIndicator(skill.GetFlexibleRange());
        skillValue_Fov  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetLineOfSight());
        skillValue_Cil  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetCastStraightLine());

        string skillCooldown             = "-"; if(skill.GetCooldown()             != 0) { skillCooldown             = skill.GetCooldown()            .ToString(); }
        string skillCastPerTurn          = "-"; if(skill.GetCastPerTurn()          != 0) { skillCastPerTurn          = skill.GetCastPerTurn()         .ToString(); }
        string skillCastPerTurnPerTarget = "-"; if(skill.GetCastPerTurnPerTarget() != 0) { skillCastPerTurnPerTarget = skill.GetCastPerTurnPerTarget().ToString(); }

        skillValue_Cd   .text = skillCooldown;
        skillValue_Cpt  .text = skillCastPerTurn;
        skillValue_Cptpt.text = skillCastPerTurnPerTarget;
    }

    private void ClearSkillInfo() {
        skillName.text   = "-";
        skillIcon.sprite = null;
        skillCost.text   = "Cost: -";

        effectAndLoreText.text = "";

        skillValue_Ap.transform.parent.gameObject.SetActive(false);

        skillValue_Ap   .text = "";                      
        skillValue_Mp   .text = "";
        skillValue_Range.text = "";
        skillValue_UpPo .text = "";
        skillValue_Fov  .text = "";
        skillValue_Cil  .text = "";
        skillValue_Cd   .text = "";
        skillValue_Cpt  .text = "";
        skillValue_Cptpt.text = "";
    }


    private int? FindSkillIndex(Transform skillBtn) {
        int? skillIndex = null;

        for(int i = 0; i < skillButtonList.Count; i++) {
            if(skillBtn == skillButtonList[i]) {
                skillIndex = i;
                break;
            }
        }

        return skillIndex;
    }


    #region Load Effect or Lore
    private void LoadEffectOrLore() {
        if(selectedSkill != null) {
            if(effect_btn.interactable) {
                LoadLore();
            }
            else if(lore_btn.interactable) {
                LoadEffect();
            }
            else {
                Debug.Log("Error: Effect and Lore button not interactable!?!?");
            }
        }
    }


    private void LoadEffect() {
        effectAndLoreText.text = selectedSkill.GetDescription();
    }

    private void LoadLore() {
        effectAndLoreText.text = selectedSkill.GetLore();
    }
    #endregion


    #region Button Highlight Methode
    private void ModifieSkillButtonVisual(Transform clickedSkillBtn) {
        bool isSelecting = clickedSkillBtn != highlightedSkillButton;

        UnhighlightSkillButton();
        if(isSelecting) {
            HighlightSkillButton(clickedSkillBtn);
        }
    }

    private void UnhighlightSkillButton() {
        if(highlightedSkillButton != null) {
            Button skillButton = highlightedSkillButton.GetComponent<Button>();
            Color  color = new Color(255, 255, 255, 255); // White

            // Define visual indicator.
            ColorBlock highlightColor  = skillButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            skillButton.colors = highlightColor;

            highlightedSkillButton = null;
        }
    }

    private void HighlightSkillButton(Transform clickedSkillBtn) {
        if(highlightedSkillButton == null) {
            Button skillButton = clickedSkillBtn.gameObject.GetComponent<Button>();
            Color  color = new Color(0, 150, 50, 255); // Green

            // Define visual indicator.
            ColorBlock highlightColor  = skillButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            skillButton.colors   = highlightColor;

            highlightedSkillButton = clickedSkillBtn;
        }
    }
    #endregion
}