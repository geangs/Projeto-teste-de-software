using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public RoundManager roundManager;
    private int i = 0;
    
    private void Start()
    {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
    }

    private void OnMouseDown()
    {
        roundManager.NextTurn();
    }
}
