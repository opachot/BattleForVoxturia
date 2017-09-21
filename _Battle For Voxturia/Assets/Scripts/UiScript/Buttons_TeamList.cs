/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_TeamList : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private Navigation navigation;

    // PUBLIC
    public GameObject CreateNewTeam_PopUp;

    #endregion

    #region UNITY METHODE
    void Awake() {
        navigation = gameObject.GetComponent<Navigation>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void CreateNewTeamButton() {
        CreateNewTeam_PopUp.SetActive(true);
    }

    public void ReturnButton() {
        navigation.NavigateTo_Hub();
    }
    #endregion

    #region CreateNewTeam popUp buttons
    public void CreateTeamButton() {
        // TODO: Save the creation of the team.
        CreateNewTeam_PopUp.SetActive(false);
    }

    public void CancelCreationButton() {
        CreateNewTeam_PopUp.SetActive(false);
    }
    #endregion
}