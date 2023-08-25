using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!inGame)
            return;


        if (!Firing.HasBallsLeft()) {
            EndGame();
        }
        else
        {
            if(instance.staticBallGroup.childCount <= 0)
            {
                EndGame();
            }
        }
    }


    int score;
    [SerializeField] Text scoreText;

    bool inGame = false;

    [SerializeField] GameObject difficultyMenu;
    [SerializeField] Text previousScoreText;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject FiringArrow;

    [SerializeField] Transform staticBallGroup;
    [SerializeField] Transform activeBallGroup;

    public static void Init()
    {
        instance.score = 0;
    }

    public static void AddScore(int value)
    {
        instance.score = Mathf.Max(0, instance.score + value);
        instance.scoreText.text = instance.score.ToString();
    }

    public static void EnableDifficultyMenu(bool state)
    {
        instance.inGame = !state;
        instance.difficultyMenu.SetActive(state);
        instance.GUI.SetActive(!state);
        instance.FiringArrow.SetActive(!state);

    }

    public static int GetNumberOfActiveBalls()
    {
        return instance.activeBallGroup.childCount;
    }


    static void EndGame()
    {
        instance.previousScoreText.text = "Previously Scored: " + instance.score;
        // previousScoreText remaining balls
        foreach (Transform ball in instance.staticBallGroup)
            Destroy(ball.gameObject);

        EnableDifficultyMenu(true);
    }

    public static float BallSize;

    public static float LeftEdge;
    public static float RightEdge;

}
