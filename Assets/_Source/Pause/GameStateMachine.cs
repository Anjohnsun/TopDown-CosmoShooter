using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    public static GameStates CurrentGameState { get; private set; }
    public delegate void StateChanging(GameStates newGameState);
    public static event StateChanging StateChanged; 

    public static void ChangeGameState()
    {
        CurrentGameState = CurrentGameState == GameStates.Paused ? GameStates.Playing : GameStates.Paused;
        StateChanged.Invoke(CurrentGameState);
    }

    public static void ChangeGameState(GameStates newGameState) //may be useless
    {
        if (CurrentGameState != newGameState)
            ChangeGameState();
    }
}
