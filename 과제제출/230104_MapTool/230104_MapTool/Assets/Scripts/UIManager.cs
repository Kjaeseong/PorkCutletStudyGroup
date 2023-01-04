using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _placementBlockUI;
    [SerializeField] private GameObject _ExitGameButton;

    public void GameStart()
    {
        GameManager.Instance.GameStart();
        _placementBlockUI.SetActive(false);
        _ExitGameButton.SetActive(true);
    }

    public void GameExit()
    {
        GameManager.Instance.ExitGame();
    }
}