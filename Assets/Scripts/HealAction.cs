using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : CardAction
{
    public override void act()
    {
        target.GetComponentInChildren<Health>().addHealth(5);
    }
}
