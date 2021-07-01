using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time = 0f;

    public Text timeText;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update ()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("f2");
	}
}
