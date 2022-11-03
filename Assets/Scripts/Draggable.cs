using System;
using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

    private Plane dragPlane;
    private Vector3 offset;
    private Camera myMainCamera;
    public static GameObject selectedCard;

    void Start()
    {
        myMainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        
        selectedCard = transform.gameObject;
        selectedCard?.GetComponent<CardScript>().pickUp();
        
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseDrag()
    {
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }

    private void OnMouseUp()
    {
        if (myMainCamera.ScreenToWorldPoint(Input.mousePosition).y > 0)
        {
            selectedCard?.GetComponent<CardScript>().release();
            selectedCard = null;
        }
        else
        {
            if(selectedCard != null)
                GameObject.Find("HandDisplay").GetComponent<HandScript>().fitCard(selectedCard);
        }
        
    }
}