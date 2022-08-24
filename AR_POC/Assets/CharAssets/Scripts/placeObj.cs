using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class placeObj : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlacedPrefab;

    [SerializeField]
    GameObject visualObject;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Text message;
    public GameObject selCharDropDown;

    ARRaycastManager raycastManager;

    private GameObject spawnedObject;
    public GameObject interaction;
    public GameObject HS_Toggle;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        message.text = "Tap on the marker to spawn object";
        interaction.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    Spawn();
                }
                // else
                // {
                //     //repositioning of the object 
                //     spawnedObject.transform.position = hitPose.position;
                // }
                // placementUpdate.Invoke();
                // interaction.SetActive(true);
            }
        }
    }

    public void ClickSpawn()
    {
        Spawn();
    }
    void Spawn()
    {   
        interaction.SetActive(true);
        // spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
        // spawnedObject = Instantiate(m_PlacedPrefab, visualObject.transform.position, visualObject.transform.rotation);
        
        // selCharDropDown.SetActive(true);
        spawnedObject = selCharDropDown.GetComponent<DropDownManager>().InstantiateObj(visualObject.transform.position, visualObject.transform.rotation);
        HS_Toggle.SetActive(true);

        message.text = "Object placed";

        visualObject.SetActive(false);
        enabled = false;
    }
}