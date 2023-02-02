using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPausable
{
    public void OnGameStateChanged(GameStates newGameState);

}

