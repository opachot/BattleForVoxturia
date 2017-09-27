/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    19 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleScreen : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private Navigation navigation;

    public GameObject quitConfirmaton_PopUp;

    // PUBLIC
    //public Button autoSelected_btn;

    #endregion

    #region UNITY METHODE
    void Awake() {
        navigation = gameObject.GetComponent<Navigation>();
    }
	
	void Start() {
        //autoSelected_btn.Select();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void PlayButton() {
        navigation.NavigateTo_Hub();
    }

    public void QuitButton() {
        quitConfirmaton_PopUp.SetActive(true);
    }
    #endregion

    #region QuitConfirmation popUp buttons
    public void YesQuitButton() {
        navigation.QuitGame();
    }

    public void NoQuitButton() {
        quitConfirmaton_PopUp.SetActive(false);
    }
    #endregion
}