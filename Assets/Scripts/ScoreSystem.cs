using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameObject goodTargetPrefab;
    [SerializeField] private int goodTargetCount = 10;

    [SerializeField] private GameObject badTargetPrefab;
    [SerializeField] private int badTargetCount = 5;

    [SerializeField] private Transform orbitObject;

    [SerializeField]
    private Text scoreText;

    [SerializeField] private EndGameMenu endGameMenu;

    [SerializeField] private int winCondition = 10;

    [SerializeField] private int looseCondition = 0;

    [SerializeField] private int goodScore = 1;

    [SerializeField] private int badScore = -2;

    private int currentScore;

    public void Start()
    {
        for (int i = 0; i < goodTargetCount; i++)
        {
            SpawnGoodTarget();
        }

        for (int i = 0; i < badTargetCount; i++)
        {
            SpawnBadTarget();
        }
    }


    public void ScoreGoodTarget()
    {
        currentScore += goodScore;
        UpdateScore();
        SpawnGoodTarget();
    }


    public void ScoreBadTarget()
    {
        currentScore += badScore;
        UpdateScore();
        SpawnBadTarget();
    }


    private void SpawnGoodTarget()
    {
        var obj = Instantiate(goodTargetPrefab);
        obj.GetComponent<Target>().Init(orbitObject);
    }

    private void SpawnBadTarget()
    {
        var obj = Instantiate(badTargetPrefab);
        obj.GetComponent<Target>().Init(orbitObject);
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();

        if (currentScore < looseCondition)
        {
            TriggerLoose();
        }

        if (currentScore >= winCondition)
        {
            TriggerWin();
        }
    }



    private void TriggerWin()
    {
        endGameMenu.Win();
        
    }

    private void TriggerLoose()
    {
        endGameMenu.Lose();
    }
}
