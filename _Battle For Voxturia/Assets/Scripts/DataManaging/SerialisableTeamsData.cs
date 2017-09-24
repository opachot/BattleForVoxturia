/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/***************************
 *          -NOTE-
 * Save teams name, levels and other team stats.
 * Save teams character, they skills and they equipment and lvl, etc...
 * Save character reserve list.
 * Save discovered items/budget
 * Save map/quest progression
 * Save option
 * ************************/

[Serializable]
public class SerialisableTeamsData {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC
    public List<int>    teamsId;
    public List<string> teamsNames;

    #endregion

}