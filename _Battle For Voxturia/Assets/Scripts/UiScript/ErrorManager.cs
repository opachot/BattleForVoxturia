/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    28 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour {

    #region DECLARATION
    // CONST
    const string DEFAULT_MESSAGE = "Unknown Error";

    // PRIVATE
    private Text errorMessage;

    // PUBLIC
    public GameObject error_PopUp;

    #endregion

	#region UNITY METHODE
	void Awake() {                                      
        errorMessage = error_PopUp.transform.Find("Background").Find("ErrorMessage").GetComponent<Text>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
	#endregion
	

    #region Default buttons
    public void ErrorOkButton() {
        error_PopUp.SetActive(false);
        errorMessage.text = DEFAULT_MESSAGE;
    }
    #endregion

    public void TrowError(string error) {
        errorMessage.text = error;
        error_PopUp.SetActive(true);
    }

}