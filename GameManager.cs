using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;

    //다른스크립트에서 귀찮게 선언할 수고가없다
    //시작할때 메모리에 올려버리는 static
    //static 변수에 담긴값을 메모리에 통째로 올리기때문에 GameObject같은건 복잡해서 남용x
    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public GameObject uiOver;
    void Awake()
    {
        isLive = true;

        if (!PlayerPrefs.HasKey("score"))
            PlayerPrefs.SetFloat("score", 0);
    }

    void Update()
    {
        if (isLive)
        {
            score += Time.deltaTime * 2;
            globalSpeed = ORIGIN_SPEED + score * 0.01f;
        }
        //Debug.Log(score);
    }
    public void GameOver()
    {
        uiOver.SetActive(true);
        isLive = false;

        float highScore = PlayerPrefs.GetFloat("score");
        PlayerPrefs.SetFloat("score", Mathf.Max(highScore, score));
    }
    public void Restart()
    {
        //다이노에 
        SceneManager.LoadScene("Stage");
        score = 0;
        isLive = true;
    }
}
