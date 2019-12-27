using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public Transform DSYHTEXT;
    public GameObject ETC;

    void Start()
    {
        StartCoroutine(setUI());
    }

    IEnumerator setUI()
    {
        Vector3 temp = new Vector3(0, -20, 0);

        for (int i = 0; i < 50; i++)
        {
            DSYHTEXT.Translate(temp);
            yield return new WaitForSeconds(0.01f);
        }

        DSYHTEXT.localPosition = new Vector3(0, 250, 0);

        yield return new WaitForSeconds(1);

        ETC.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

}
