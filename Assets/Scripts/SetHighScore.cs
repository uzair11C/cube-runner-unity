using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI menuHighScore;

    void Start()
    {
        menuHighScore.text =
            "High Score: " + PlayerPrefs.GetInt("CubeRunner_highScore", 0).ToString();
    }

    // Update is called once per frame
    void Update() { }
}
