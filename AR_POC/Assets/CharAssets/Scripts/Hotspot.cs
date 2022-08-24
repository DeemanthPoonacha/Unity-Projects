using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.Events;

public class Hotspot : MonoBehaviour
{
    public GameObject infoPanel;
    // private GameObject mainCanvas;
    // public GameObject infoPref;
    public string Name;
    public string Type;
    public string Rating="4/5";
    public string Description;
    private LR_Controller lineR;
    private Hotspot[] hotspots;
    public Canvas HS_Canvas;
    // public bool close;
    
    // public Transform target;
    // public RectTransform rect;
    void OnEnable()
    {
        infoPanel= FindObjectOfType<HotspotController>().infoPanel;
        // if(!close)
        // {
            HS_Canvas.worldCamera=Camera.main;
            // mainCanvas=GameObject.FindGameObjectWithTag("MainCanvas");
            // infoPanel=GameObject.FindGameObjectWithTag("InfoPanel");
            // infoPanel=GameObject.Instantiate(infoPref);
            // infoPanel.transform.parent=mainCanvas.transform;
            ShowInfo();
        // }
    }
    void Start()
    {
        HideInfo();
        // rect=GetComponent<RectTransform>();
    }

    // void Update()
    // {
    //     // var screenPoint = Camera.main.WorldToScreenPoint(target.position);
    //     // rect.position= screenPoint;
    // }

    // private void OnMouseDown() {
    //     ShowInfo();
    // }

    public void ShowInfo()
    {
        // HideAllHotspotsInfo();
        // infoPanel=GameObject.Find("InfoPanel");
        infoPanel.SetActive(true);
        infoPanel.transform.GetComponentInChildren<TextMeshProUGUI>().text="Type: "+Type+"\nName: "+Name+"\nRating: "+Rating+"\nDescription: "+Description;
        lineR=infoPanel.GetComponentInChildren<LR_Controller>();
        lineR.pos1=transform;
        // Debug.Log(infoPanel);
    }
    
    public void HideInfo()
    {
        // if (close)
        // {
        //     infoPanel=transform.parent.gameObject;
        //     // infopanel=transform.parent;            
        // }
        infoPanel.SetActive(false);
    }

    void HideAllHotspotsInfo()
    {
        // hotspots=FindObjectsOfType<Hotspot>();
        // foreach (var item in hotspots)
        // {
        //     Debug.Log(item.gameObject.name);
        //     item.HideInfo();
        // }
    }
}
