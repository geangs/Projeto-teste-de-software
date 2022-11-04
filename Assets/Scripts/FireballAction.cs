using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireballAction : CardAction
{
    public override void act()
    {
        target.GetComponentInChildren<Health>().addHealth(-6);
    }
}
