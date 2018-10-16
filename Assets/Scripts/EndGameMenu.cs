using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{

    [SerializeField] private Image endGameState;

    [SerializeField] private Sprite winImage;

    [SerializeField] private Sprite loseImage;

    public void Win()
    {
        gameObject.SetActive(true);
        endGameState.sprite = winImage;
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        endGameState.sprite = loseImage;
    }
}
