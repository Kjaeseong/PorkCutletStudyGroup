using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public List<Player> Player { get; set; }
    [field: SerializeField] public float UpdateCycle { get; set; }

    public WaitForSeconds Cycle { get; private set; }




    private void Awake() 
    {
        Cycle = new WaitForSeconds(UpdateCycle);
    }

    private void CreatePlayer()
    {
        
    }


}
