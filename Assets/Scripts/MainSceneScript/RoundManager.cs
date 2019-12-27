using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject obj_round2, obj_round4, obj_round5, obj_round6, obj_round6_2, obj_round7, obj_Map;

    public void Round_Control(int round, GameController GC)
    {

        Debug.Log("RoundManager: start round! round = " + round); 
        switch (round)
        {
            case 1: StartCoroutine(Round1(GC)); break;
            case 2: StartCoroutine(Round2(GC)); break;
            case 3: StartCoroutine(Round3(GC)); break;
            case 4: StartCoroutine(Round4(GC)); break;
            case 5: StartCoroutine(Round5(GC)); break;
            case 6: StartCoroutine(Round6(GC)); break;
            case 7: StartCoroutine(Round7(GC)); break;
            case 8: StartCoroutine(Round8(GC)); break;
            case 9: StartCoroutine(Round9(GC)); break;
            case 10: StartCoroutine(Round10(GC)); break;
        }
    }

    IEnumerator Round1(GameController GC)
    {
        yield return new WaitForSeconds(5);
        GC.Round_Finish();
    }

    IEnumerator Round2(GameController GC)
    {
        yield return new WaitForSeconds(1);
        obj_round2.SetActive(true);
        yield return new WaitForSeconds(4);
        GC.Round_Finish();
    }

    IEnumerator Round3(GameController GC)
    {
        Transform character = GC.getCharacter().transform;

        Vector3 startPos = character.position;
        Quaternion startRot = character.rotation;

        character.rotation = new Quaternion(0, 90, 0, 0);

        Vector3 go = new Vector3(0, 0.05f, 0);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 40; i++)
        {
            character.position += go;

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        character.rotation = new Quaternion(0, 270, 0, 0);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 80; i++)
        {
            character.position -= go;

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        character.rotation = new Quaternion(0, 90, 0, 0);

        for (int i = 0; i < 40; i++)
        {
            character.position += go;

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        character.position = startPos;
        character.rotation = startRot;

        yield return new WaitForSeconds(1);
        GC.Round_Finish();
    }

    IEnumerator Round4(GameController GC)
    {
        int a = 0, b = 0;

        for (int i = 0; i < 10; i++)
        {
            a = Random.Range(1, 2);
            b = Random.Range(1, 4);
            obj_round4.SetActive(true);
            obj_round4.transform.position = new Vector3( (i % 2 == 0 ? -1 : 1), a, b);
            yield return new WaitForSeconds(0.25f);
            obj_round4.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
        GC.Round_Finish();
    }

    IEnumerator Round5(GameController GC)
    {
        obj_round5.SetActive(true);
        Transform obj5 = obj_round5.transform;

        Vector3 go = new Vector3(0, 0.05f, 0);

        for (int i = 0; i < 40; i++)
        {
            obj5.position += go;

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 40; i++)
        {
            obj5.position -= go;

            yield return new WaitForSeconds(0.1f);
        }
        obj_round5.SetActive(false);

        yield return new WaitForSeconds(1);
        GC.Round_Finish();
    }

    IEnumerator Round6(GameController GC)
    {
        yield return new WaitForSeconds(1);

        obj_round6.SetActive(true);
        Transform obj = obj_round6.transform;

        Vector3 startVec = new Vector3();
        Vector3 desVec = new Vector3(0, 1.6f, 0);
        Vector3 temp = new Vector3();

        int ran = Random.Range(0, 4);

        for (int i = 0; i < 5; i++)
        {
            int a = Random.Range(0, 100);
            if (i % 2 == 0)
            {
                startVec = new Vector3(3, 0.04f * a, 5);
            }
            else
                startVec = new Vector3(-3, 0.04f * a, 5);


            obj.position = startVec;
            yield return new WaitForSeconds(0.2f);

            if (i == ran)
            {
                obj_round6_2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                obj_round6_2.SetActive(false);
            }

            temp = (desVec - startVec) * 0.01f;

            yield return new WaitForSeconds(0.1f);

            for (int j = 0; j < 100; j++)
            {
                obj.position += temp;
                temp *= 1.05f;
                yield return new WaitForSeconds(0.02f);
            }
        }

        GC.Round_Finish();
    }

    IEnumerator Round7(GameController GC)
    {
        Transform character = GC.getCharacter().transform;
        yield return new WaitForSeconds(1);

        Vector3 pos = character.position;

        character.localScale *= 3f;

        yield return new WaitForSeconds(2);

        character.localScale /= 3f;

        yield return new WaitForSeconds(1.5f);

        character.gameObject.SetActive(false);

        obj_round7.SetActive(true);
        Transform obj = obj_round7.transform;
        obj.position = pos;
        yield return new WaitForSeconds(0.5f);

        obj.localScale *= 3f;
        yield return new WaitForSeconds(2);

        obj.localScale /= 3f;
        yield return new WaitForSeconds(1);

        Vector3 temp = 0.02f * (new Vector3(0, 1.6f, -1) - obj.position);


        for (int i = 0; i < 50; i++)
        {
            obj.position += temp;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        character.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        GC.Round_Finish();
    }

    IEnumerator Round8(GameController GC)
    {
        yield return new WaitForSeconds(1);

        Transform map = obj_Map.transform;

        Quaternion map_start_rot = map.rotation;

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0, 0.1f);

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 600; i++)
        {
            map.Rotate(0, 0, -0.1f);

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0, 0.1f);

            yield return new WaitForSeconds(0.01f);
        }

        map.rotation = map_start_rot;

        yield return new WaitForSeconds(0.5f);
        GC.Round_Finish();
    }

    IEnumerator Round9(GameController GC)
    {
        yield return new WaitForSeconds(1);

        Transform map = obj_Map.transform;
        Quaternion map_start_rot = map.rotation;

        Vector3 temp_y = new Vector3(0, 0.01f, 0);

        for (int i = 0; i < 50; i++)
        {
            map.position += temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 100; i++)
        {
            map.position -= temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 50; i++)
        {
            map.position += temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0.02f, 0);

            if (i > 100)
            {
                map.Rotate(0.02f, 0, 0);
            }
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, -0.02f, 0);

            if (i < 200)
            {
                map.Rotate(-0.02f, 0, 0);
            }
            yield return new WaitForSeconds(0.01f);
        }

        map.rotation = map_start_rot;

        yield return new WaitForSeconds(0.5f);

        GC.Round_Finish();
    }

    

    IEnumerator Round10(GameController GC)
    {
        yield return new WaitForSeconds(1);

        Transform map = obj_Map.transform;
        Quaternion map_start_rot = map.rotation;

        Vector3 temp_y = new Vector3(0, 0.01f, 0);

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0, 0.1f);

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0, -0.1f);

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 50; i++)
        {
            map.position += temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 100; i++)
        {
            map.position -= temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 50; i++)
        {
            map.position += temp_y;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, 0.02f, 0);

            if (i > 200)
            {
                map.Rotate(0.02f, 0, 0);
            }
            else if (i > 100)
            {
                map.Rotate(-0.02f, 0, 0);
            }

            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 300; i++)
        {
            map.Rotate(0, -0.02f, 0);

            yield return new WaitForSeconds(0.01f);
        }
        map.rotation = map_start_rot;

        Transform character = GC.getCharacter().transform;

        Vector3 pos = character.position;

        character.gameObject.SetActive(false);

        obj_round7.SetActive(true);
        Transform obj = obj_round7.transform;
        obj.position = pos;
        yield return new WaitForSeconds(0.5f);

        Vector3 temp = 0.02f * (new Vector3(0, 1.6f, -1) - obj.position);


        for (int i = 0; i < 50; i++)
        {
            obj.position += temp;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        character.gameObject.SetActive(true);


        yield return new WaitForSeconds(1f);

        GC.Round_Finish();
    }
}
