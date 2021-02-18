using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hint : MonoBehaviour
{
    public GameObject tick;

    public GameObject[] hints;

    bool hint1, hint2, hint3, hint4, hint5, stopHint1, stopHint2, stopHint3, stopHint4, stopHint5;

    void Start()
    {
        StartCoroutine(ShowHint1(3));
    }

    void Update()
    {
        if (hint1 && !stopHint1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                stopHint1 = true;
                StartCoroutine(HideHint(2));
            }
        }

        else if (hint2 && !stopHint2)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                stopHint2 = true;
                StartCoroutine(HideHint(2));
            }
        }

        else if (hint3 && !stopHint3)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 || Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                stopHint3 = true;
                StartCoroutine(HideHint(2));
            }
        }

        else if (hint4 && !stopHint4)
        {
            if (Input.GetMouseButtonDown(1))
            {
                stopHint4 = true;
                StartCoroutine(HideHint(2));
            }
        }

        else if (hint5 && !stopHint5)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                stopHint5 = true;
                StartCoroutine(HideHint(2));
            }
        }
    }

    IEnumerator ShowHint1(int s)
    {
        yield return new WaitForSeconds(s);

        hints[0].gameObject.SetActive(true);

        hint1 = true;

        FindObjectOfType<AudioManager>().Play("new_hint");
    }

    IEnumerator HideHint(int s)
    {
        FindObjectOfType<AudioManager>().Play("done_hint");
        tick.gameObject.SetActive(true);

        yield return new WaitForSeconds(s);

        if (hint5)
        {
            hints[4].gameObject.SetActive(false);

            hint5 = false;
        }

        else if (hint4)
        {
            hints[3].gameObject.SetActive(false);
            hints[4].gameObject.SetActive(true);

            hint4 = false;
            hint5 = true;
        }

        else if (hint3)
        {
            hints[2].gameObject.SetActive(false);
            hints[3].gameObject.SetActive(true);

            hint3 = false;
            hint4 = true;
        }

        else if (hint2)
        {
            hints[1].gameObject.SetActive(false);
            hints[2].gameObject.SetActive(true);

            hint2 = false;
            hint3 = true;
        }

        else if (hint1)
        {
            hints[0].gameObject.SetActive(false);
            hints[1].gameObject.SetActive(true);

            hint1 = false;
            hint2 = true;
        }

        tick.gameObject.SetActive(false);
    }
}