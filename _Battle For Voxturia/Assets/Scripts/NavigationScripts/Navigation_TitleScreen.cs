/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    17 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation_TitleScreen : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC

    #endregion
    
    #region UNITY METHODE
    void Awake() {

    }

    void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

    public void NavigateTo_Hub() {
        SceneManager.LoadScene("Hub");
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}