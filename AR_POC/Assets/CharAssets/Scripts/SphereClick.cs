using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereClick : Hotspot
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, 100f))
            {
                if (hit.transform!=null)
                {
                    Debug.Log("hit");
                    ShowInfo();
                }
            }
        }
        if(Input.touchCount>0)
        {
            
            if(Input.GetTouch(0).phase==TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray,out hit, 100f))
                {
                    if (hit.transform!=null)
                    {
                        Debug.Log("hit");
                        ShowInfo();
                    }
                }
            }
        }
    }
}
