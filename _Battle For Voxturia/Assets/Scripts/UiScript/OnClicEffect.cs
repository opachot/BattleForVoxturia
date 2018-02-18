/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    28 January 2018
*/

/* Instruction
Need to be placed on a gameObject whit a TMP(Text Mesh Pro) component. 
*/

// Usefull exemple: Class: TMP_TextEventHandler

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnClicEffect : MonoBehaviour, IPointerClickHandler {

    #region DECLARATION
    // CONST

    // PRIVATE
    private TMP_Text textBloc;

    private EffectList         effectList;
    private EffectPopUpControl effectPopUpControl;

    // PUBLIC
    public GameObject effectPopUp;

    #endregion

	#region UNITY METHODE
	void Awake() {
		textBloc = gameObject.GetComponent<TMP_Text>();

        effectList         = GameObject.FindGameObjectWithTag("Effects").GetComponent<EffectList>();
        effectPopUpControl = effectPopUp                                .GetComponent<EffectPopUpControl>();
    }
	
	void Start() {
		
	}
	
	void Update() {

	}

    public void OnPointerClick(PointerEventData pointerEventData) {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textBloc, Input.mousePosition, Camera.main);

        if(linkIndex != -1) {
            TMP_LinkInfo linkInfo = textBloc.textInfo.linkInfo[linkIndex];
            string linkId = linkInfo.GetLinkID();

            bool isLoadableEffect = true;
            switch (linkId)
            {
                // ................... General Effect ...................
                // Action

                // Movement

                // Sight

                // Life
                case Effect.VITALITY:
                    effectPopUpControl.LoadPopUp(effectList.vitality_Effect); break;

                case Effect.INCURABLE:
                    effectPopUpControl.LoadPopUp(effectList.incurable_Effect); break;

                // Protection
                case Effect.VULNERABILITY:
                    effectPopUpControl.LoadPopUp(effectList.vulnerability_Effect); break;
                
                // Damage
                case Effect.UNDERPOWER:
                    effectPopUpControl.LoadPopUp(effectList.underPower_Effect); break;

                case Effect.PREPARATION:
                    effectPopUpControl.LoadPopUp(effectList.preparation_Effect); break;

                case Effect.POWER:
                    effectPopUpControl.LoadPopUp(effectList.power_Effect); break;

                case Effect.POWERLESS:
                    effectPopUpControl.LoadPopUp(effectList.powerless_Effect); break;

                // ................... Specific Effect ...................
                // Fighter
                case Effect.FIGHTER_AURA:
                    effectPopUpControl.LoadPopUp(effectList.fighterAura_Effect); break;

                case Effect.FIGHTER_MEDITATION:
                    effectPopUpControl.LoadPopUp(effectList.fighterMeditation_Effect); break;
                
                // Hunter

                // Ninja

                // Elementalist

                // Samurai

                // Vampire

                // Cyborg

                // ................... Error Handling ...................
                default:
                    Debug.Log("Effect in OnClicEffect script not defined...");
                    isLoadableEffect = false;
                    break;
            }

            if(isLoadableEffect) {
                effectPopUp.SetActive(true);
            }
        }
    }
    #endregion

}