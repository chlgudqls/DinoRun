using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool isHighScore;

    float highScore;
    Text uiText;
    void Awake()
    {
        uiText = GetComponent<Text>();

        if(isHighScore)
        {
            highScore = PlayerPrefs.GetFloat("score");
            uiText.text = highScore.ToString("F0");
        }
    }

    void LateUpdate()
    {
        if (!GameManager.isLive)
            return;

        if (isHighScore && GameManager.score < highScore)
            return;

        //이게 뭔지 이해가 안되네 머리가 굳어서 미세한 프레임 차이로 숫자가 업데이트되나
        uiText.text = GameManager.score.ToString("F0");
    }
}
