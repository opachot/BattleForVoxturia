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
    List<Skill>       classSkillList;
    List<Skill>       displayedSkillList = new List<Skill>();

    Skill selectedSkill;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;

    private string className;

    // PUBLIC
    public Button selectSkill_btn;
    [Space(10)]

    [Header("Skill Info Section")]
    public Text  skillName;
    public Image skillIcon;
    public Text  skillCost;
    [Space(5)]
    public GameObject skillEffectSection;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;
    [Space(5)]
    public TMP_Text effectText;
    public Text     loreText;
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
                // TODO: set selected color.
                selectSkill_btn.interactable = true;
                

                LoadSkillInfo(selectedSkill);
            }
            else {
                selectedSkill = null;
                selectSkill_btn.interactable = false;
                // TODO: Unselect (remove selection color AND clear info section)
            }
        }
        else {
            Debug.Log("Error 404: Skill index not found!");
        }
    }

    public void SelectButton() {
        // TODO

        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void CancelButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void EffectButton() {
        /*effect_btn.interactable = false;
        loreSection.SetActive(false);

        lore_btn.interactable = true;
        equipmentEffectSection.SetActive(true);
        skillEffectSection    .SetActive(true);*/
    }

    public void LoreButton() {
        /*lore_btn.interactable = false;
        equipmentEffectSection.SetActive(false);
        skillEffectSection    .SetActive(false);

        effect_btn.interactable = true;
        loreSection.SetActive(true);*/
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
        Transform listElement = Instantiate(resourceLoader.skillListingElement, list).transform;

        FixListElementButton(listElement, skill);

        skillButtonList.Add(listElement);
        displayedSkillList.Add(skill);
    }

    private void FixListElementButton(Transform listElement, Skill skill) {
        // Set skillButton onClick event.
        Button skillButton   = listElement.GetComponent<Button>();
        skillButton.onClick.AddListener(()   => SkillButton(listElement));

        // Set skill icon.
        Transform iconTransform = listElement.FindDeepChild("Icon");
        Image     iconImage     = iconTransform.GetComponent<Image>();
        iconImage.sprite = skill.GetIcon();

        // Set skill name.
        Transform nameTransform = listElement.FindDeepChild("Name");
        Text      nameText      = nameTransform.GetComponent<Text>();
        nameText.text = skill.GetName();

        // Set skill cost.
        Transform costTransform = listElement.FindDeepChild("Cost");
        Text      costText      = costTransform.GetComponent<Text>();
        costText.text = "Cost: " + skill.GetCost();
    }
    #endregion


    private void LoadSkillInfo(Skill skill) {
        skillName.text   = skill.GetName();
        skillIcon.sprite = skill.GetIcon();
        skillCost.text   = "Cost: " + skill.GetCost();

        effectText.text = skill.GetDescription();
        loreText  .text = skill.GetLore();

        skillValue_Ap.transform.parent.gameObject.SetActive(true);

        skillValue_Ap   .text = skill.GetApCost().ToString();
        skillValue_Mp   .text = skill.GetMpCost().ToString();
        skillValue_Range.text = skill.GetMinRange() + "-" + skill.GetMaxRange();
        skillValue_UpPo .text = HelpingMethod.ConvertBoolToIndicator(skill.GetFlexibleRange());
        skillValue_Fov  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetLineOfSight());
        skillValue_Cil  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetCastStraightLine());
        skillValue_Cd   .text = skill.GetCooldown()            .ToString();
        skillValue_Cpt  .text = skill.GetCastPerTurn()         .ToString();
        skillValue_Cptpt.text = skill.GetCastPerTurnPerTarget().ToString();
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
}