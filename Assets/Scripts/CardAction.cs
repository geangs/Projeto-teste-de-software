using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{

    public GameObject target;
    
    public void play()
    {
        act();
        transform.parent.gameObject.SetActive(false);
    }

    public virtual void release()
    {
        
    }
    
    public virtual void act()
    {
        
    }
}
