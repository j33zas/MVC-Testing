using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    static TimeController _T;
    public static TimeController controller
    {
        get
        {
            return _T;
        }
        set
        {
            _T = value;
        }
    }

    private void Start()
    {
        controller = this;
    }

    public void HitStop(float timestopped)
    {
        StartCoroutine(HitStopCoroutine(timestopped));
    }
    IEnumerator HitStopCoroutine(float time)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
    }
}
