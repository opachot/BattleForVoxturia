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

public class testTMPAutoHight : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC
    public TMP_Text myTxt;

    #endregion

	#region UNITY METHODE
	void Awake() {
		
    }
	
	void Start() {
	}
	
	void Update() {
        if(Input.anyKey) {
            // this work, set hight depending of that value.
            Debug.Log(myTxt.textInfo.lineCount);

            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x,myTxt.textInfo.lineCount*13);
        }
	}
    #endregion

}