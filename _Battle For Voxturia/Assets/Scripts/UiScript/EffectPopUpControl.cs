/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    29 January 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectPopUpControl : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC
    public TMP_Text effectName;
    public TMP_Text effectDescription;

    public Image    effectIcon;
    public TMP_Text effectMaxLvl;

    #endregion

	#region UNITY METHODE
	void Awake() {
		
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    #region PopUp buttons
    public void ClosePopUp() {
        gameObject.SetActive(false);
    }
    #endregion

    public void LoadPopUp(Effect effect) {
        effectName       .text = "Effect: " + effect.GetName();
        effectDescription.text = effect.GetDescription();

        effectIcon  .sprite = effect.GetIcon();
        effectMaxLvl.text   = "Max levels: " + "<b>"+effect.GetMaxLvl()+"</b>";
    }
}