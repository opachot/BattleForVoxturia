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

            switch (linkId)
            {
                case Effect.FIGHTER_AURA:
                    //effectPopUp.SetActive(true);
                    print("TODO: Fighter Aura"); // TODO: Fighter Aura 
                    break;
                case Effect.FIGHTER_MEDITATION:
                    effectPopUp.SetActive(true);
                    effectPopUpControl.LoadPopUp(effectList.GetFighterMeditation());
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

}