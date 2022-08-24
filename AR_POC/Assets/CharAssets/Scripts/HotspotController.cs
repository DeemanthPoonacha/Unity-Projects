using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotController : MonoBehaviour
{
    public GameObject infoPanel;
    public Hotspot[] hotspots_O;

    public Hotspot[] GetHS()
    {
        Hotspot[] hotspots = FindObjectsOfType<Hotspot>();
        hotspots_O=hotspots;
        return hotspots;
    }
}
