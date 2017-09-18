/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    17 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation_Hub : MonoBehaviour {

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

    public void QuitGame() {
        Application.Quit();
    }

    public void NavigateTo_TeamList() {
        SceneManager.LoadScene("TeamList");
    }

    public void NavigateTo_Shop() {
        SceneManager.LoadScene("Shop");
    }

    public void NavigateTo_Option() {
        SceneManager.LoadScene("Option");
    }

    public void NavigateTo_Map() {
        SceneManager.LoadScene("Map");
    }

    public void NavigateTo_Items() {
        SceneManager.LoadScene("Items");
    }

    public void NavigateTo_Help() {
        SceneManager.LoadScene("Help");
    }
}