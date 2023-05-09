using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;

    //�ٸ���ũ��Ʈ���� ������ ������ ��������
    //�����Ҷ� �޸𸮿� �÷������� static
    //static ������ ��䰪�� �޸𸮿� ��°�� �ø��⶧���� GameObject������ �����ؼ� ����x
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
        //���̳뿡 
        SceneManager.LoadScene("Stage");
        score = 0;
        isLive = true;
    }
}
