using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    public void Game_Start_UI_Set(GameController GC)
    {
        GC.Mission_Clear();
    }

    public void Game_Finish_UI_Set(int score)
    {
        Debug.Log("UIManager : GameFinish!");
    }
}
