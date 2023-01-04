using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [field: SerializeField] public float UpdateCycle { get; set; }
    public WaitForSeconds Cycle { get; private set; }

    [field: SerializeField] public PlayerStat Player { get; set; }
    [SerializeField] private GameObject _builder;

    private void Awake() 
    {
        Cycle = new WaitForSeconds(UpdateCycle);
    }

    public void GameStart()
    {
        Player.gameObject.SetActive(true);
        _builder.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}