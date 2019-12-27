using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MissionManager missionManager;
    public RoundManager roundManager;
    public UIManager uiManager;
    public Character character;

    public Transform camera;
    public int score, round;
    public float score_ = 0;
    Vector3 temp_angle;
    float temp_time = 0f;

    bool inGame = false;


    private void Awake()
    {
        temp_angle = new Vector3(camera.rotation.x, camera.rotation.y, camera.rotation.z);
        temp_time = Time.time;
        inGame = false;
    }

    private void Start()
    {
        score = 0;
        round = 1;

        //roundManager.Round_Control(round, this);

        StartCoroutine(Start_Round1());
        //StartCoroutine(tt());

    }

    public void Round_Finish()
    {
        round++;

        inGame = false;

        if (round > 10)//Game Finish
        {
            uiManager.Game_Finish_UI_Set(score);

            return;
        }

        Debug.Log("GameController : finish! round = " + (round - 1));

        character.Speak("Good Job", 1);
        missionManager.StartMission(this);  
    }

    public void Mission_Clear()
    {
        Debug.Log("GameController : mission clear!");
        roundManager.Round_Control(round, this);
    }

    public GameObject getCharacter()
    {
        return character.gameObject;
    }

    float Score(Vector3 a, Vector3 b, float delta_time)
    {
        Vector3 temp = a - b;
        float temp_value = temp.magnitude;
        temp_value *= temp_value;

        float Time_ = Time.time - delta_time;

        if (Time_ == 0)
            return 0;

        return temp_value / (Time_);
    }

    IEnumerator tt()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Debug.Log(score_);
        }
    }

    private void Update()
    {
        if (inGame)
        {
            score_ += 100 * Score(temp_angle, new Vector3(camera.rotation.x, camera.rotation.y, camera.rotation.z), temp_time);

            temp_angle = new Vector3(camera.rotation.x, camera.rotation.y, camera.rotation.z);
            temp_time = Time.time;
        }
    }


    // 시나리오

    IEnumerator Start_Round1()
    {
        character.Speak("hello", 3);

        yield return new WaitForSeconds(4);

        character.Speak("Round1", 2);

        yield return new WaitForSeconds(3);

        character.Speak("Don't shake your head!", 5);
        inGame = true;

        roundManager.Round_Control(1, this);
    }
}
