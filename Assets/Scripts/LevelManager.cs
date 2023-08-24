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
        EventManager.OnBallActive += AddActiveBall;
        EventManager.OnBallDeleted += DeleteActiveBall;
    }


    int score;
    [SerializeField] Text scoreText;

    [SerializeField] GameObject difficultyMenu;
    [SerializeField] Text previousScoreText;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject FiringArrow;

    [SerializeField] Transform ballGroup;

    public static void Init()
    {
        instance.score = 0;
    }

    public static void AddScore(int value)
    {
        instance.score = Mathf.Max(0, instance.score + value);
        instance.scoreText.text = "Score: " + instance.score;
    }

    public static void EnableDifficultyMenu(bool state)
    {
        instance.difficultyMenu.SetActive(state);
        instance.GUI.SetActive(!state);
        instance.FiringArrow.SetActive(!state);

    }

    int numberOfActiveBalls;

    public static int GetNumberOfActiveBalls()
    {
        return instance.numberOfActiveBalls;
    }

    public static void ClearNumberOfActiveBalls()
    {
        instance.numberOfActiveBalls = 0;
    }

    public static void AddActiveBall()
    {
        instance.numberOfActiveBalls++;
    }

    void DeleteActiveBall()
    {
        
        instance.numberOfActiveBalls = Mathf.Max(numberOfActiveBalls - 1, 0);
        Debug.Log(instance.numberOfActiveBalls);


        if (instance.numberOfActiveBalls > 0)
            return;

        // No active balls lefts

        if (!Firing.HasBallsLeft())
        {
            EndGame();
        }
        else
        {
            bool ballsLeft = false;
            foreach(Transform ball in ballGroup)
            {
                ballsLeft = true;
                break;
            }

            if (!ballsLeft)
                EndGame();
        }
    }

    void EndGame()
    {
        previousScoreText.text = "Previously Scored: " + instance.score;
        // previousScoreText remaining balls
        foreach (Transform ball in ballGroup)
            Destroy(ball.gameObject);

        EnableDifficultyMenu(true);
    }

    private void OnDestroy()
    {
        EventManager.OnBallActive -= AddActiveBall;
        EventManager.OnBallDeleted -= DeleteActiveBall;
    }

}
