/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerialisableTeamsData {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC
    public List<int>    ids;
    public List<string> names;
    public List<int>    levels;
    public List<int>    currentXps;
    public List<int>    goalXps;
    public List<int>    victorys;
    public List<int>    defeats;
    public List<int>    currentCosts;
    public List<int>    maxCosts;
    public int          usedTeamId;

    #endregion

}