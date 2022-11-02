using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Carda data")]
public class CardData : ScriptableObject
{
    public new string name;
    public string text;
    public Sprite sprite;
    
}
