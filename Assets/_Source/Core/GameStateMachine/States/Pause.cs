using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public  void Enter()
    {
        Time.timeScale = 0;

    }
    public  void Exit()
    {
        Time.timeScale = 1;
    }
}
