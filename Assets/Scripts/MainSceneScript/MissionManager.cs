using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public void StartMission(GameController GC)
    {
        int mission = Random.Range(1, 3);

        Debug.Log("Start Mission! mission : " + mission);
        //StartCoroutine(get_gauge());

        GC.Mission_Clear();
        /*switch (mission)
        {
            case 1: StartCoroutine(Shake_Left_Right(GC)); break;
            case 2: StartCoroutine(Shake_Top_Down(GC)); break;
            case 3: StartCoroutine(Shake_Randomly(GC)); break;
        }*/
    }

    float gauge_ = 0f;

    IEnumerator Shake_Left_Right(GameController GC)
    {
        Transform camera = GC.camera;
        float rotY_before = camera.rotation.y;
        float gauge = 0f;

        while (true)
        {
            float temp = camera.rotation.y;
            gauge += Mathf.Abs(temp - rotY_before);

            rotY_before = temp;
            if (gauge > 10)
                break;
            gauge_ = gauge;
            yield return new WaitForSeconds(0.0f);
        }
        StopCoroutine(get_gauge());
        yield return new WaitForSeconds(1);
        GC.Mission_Clear();
    }

    IEnumerator Shake_Top_Down(GameController GC)
    {
        Transform camera = GC.camera;
        float rotX_before = camera.rotation.x;
        float gauge = 0f;

        while (true)
        {
            float temp = camera.rotation.x;
            gauge += Mathf.Abs(temp - rotX_before);

            rotX_before = temp;

            if (gauge > 10)
                break;
            gauge_ = gauge;
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(get_gauge());
        yield return new WaitForSeconds(1);
        GC.Mission_Clear();
    }

    IEnumerator Shake_Randomly(GameController GC)
    {
        Transform camera = GC.camera;
        Vector3 rot_before = new Vector3(camera.rotation.x, camera.rotation.y, camera.rotation.z);
        float gauge = 0f;

        while (true)
        {
            Vector3 temp = new Vector3(camera.rotation.x, camera.rotation.y, camera.rotation.z);
            gauge += (temp - rot_before).magnitude;

            rot_before = temp;

            if (gauge > 20)
                break;
            gauge_ = gauge;
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(get_gauge());

        yield return new WaitForSeconds(1);
        GC.Mission_Clear();
    }

    IEnumerator get_gauge()
    {
        while (true)
        {
            Debug.Log("gauge: " + gauge_);
            yield return new WaitForSeconds(2);
        }
    }
}
