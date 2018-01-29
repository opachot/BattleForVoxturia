/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
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
    public Text     effectName;
    public TMP_Text effectDescription;

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
    }
}