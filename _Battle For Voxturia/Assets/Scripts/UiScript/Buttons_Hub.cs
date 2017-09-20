/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    19 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Hub : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private Navigation navigation;

    // PUBLIC
    public GameObject shop_PopUp;
    public GameObject items_PopUp;
    public GameObject quitConfirmaton_PopUp;

    //public Button team_btn;
    //public Button shop_btn;
    //public Button items_btn;
    //public Button quit_btn;

    //public Button autoSelectedShopPopUp_btn;
    //public Button autoSelectedItemsPopUp_btn;
    //public Button autoSelectedQuitConfirmationPopUp_btn;

    #endregion

    #region UNITY METHODE
    void Awake() {
        navigation = gameObject.GetComponent<Navigation>();
    }
	
	void Start() {
        //team_btn.Select();
    }
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void TeamButton() {
        navigation.NavigateTo_TeamList();
    }

    public void MapButton() {
        navigation.NavigateTo_WorldMap();
    }

    public void ShopButton() {
        shop_PopUp.SetActive(true);
        //autoSelectedShopPopUp_btn.Select();
    }

    public void ItemsButton() {
        items_PopUp.SetActive(true);
        //autoSelectedItemsPopUp_btn.Select();
    }

    public void OptionButton() {
        navigation.NavigateTo_Option();
    }

    public void HelpButton() {
        navigation.NavigateTo_Help();
    }

    public void QuitButton() {
        quitConfirmaton_PopUp.SetActive(true);
        //autoSelectedQuitConfirmationPopUp_btn.Select();
    }
    #endregion

    #region Shop popUp buttons
    public void BoostPowerLimitButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void HelmetsShopButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void ArmorsShopButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void GreavesShopButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void BootsShopButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void ArtifactsShopButton() {
        // TODO: Change scene whit parameter to load the right shop.
        navigation.NavigateTo_Shop();
    }

    public void CancelShopPopUpButton() {
        shop_PopUp.SetActive(false);
        //shop_btn.Select();
    }
    #endregion

    #region Items popUp buttons
    public void MyHelmetsButton() {
        // TODO: Change scene whit parameter to load the right items list.
        navigation.NavigateTo_DiscoveredItems();
    }

    public void MyArmorsButton() {
        // TODO: Change scene whit parameter to load the right items list.
        navigation.NavigateTo_DiscoveredItems();
    }

    public void MyGreavesButton() {
        // TODO: Change scene whit parameter to load the right items list.
        navigation.NavigateTo_DiscoveredItems();
    }

    public void MyBootsButton() {
        // TODO: Change scene whit parameter to load the right items list.
        navigation.NavigateTo_DiscoveredItems();
    }

    public void MyArtifactsButton() {
        // TODO: Change scene whit parameter to load the right items list.
        navigation.NavigateTo_DiscoveredItems();
    }

    public void CancelItemsPopUpButton() {
        items_PopUp.SetActive(false);
        //items_btn.Select();
    }
    #endregion

    #region Quit confirmation popUp buttons
    public void YesQuitButton() {
        navigation.QuitGame();
    }

    public void NoQuitButton() {
        quitConfirmaton_PopUp.SetActive(false);
        //quit_btn.Select();
    }
    #endregion
}