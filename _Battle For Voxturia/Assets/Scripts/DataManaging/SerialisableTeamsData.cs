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
    public List<int>    teamsId;
    public List<string> teamsName;
    public int          usedTeamId;
    public List<int>    teamsLevel;
    public List<int>    teamsCurrentXp;
    public List<int>    teamsGoalXp;
    public List<int>    teamsVictory;
    public List<int>    teamsDefeat;
    public List<int>    teamsMatch;
    public List<int>    teamsVDRatio;
    public List<int>    teamsCurrentPower;
    public List<int>    teamsMaxPower;

    #endregion

}