using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject infoPanel;
    private Hotspot[] hotspots;
    public HotspotController HSC;
    private Toggle tog;
    private void Start() {
        tog=GetComponent<Toggle>();
        infoPanel=HSC.infoPanel;
        SwitchA();
    }
    public void SwitchActivation()
    {
        SwitchA();
    }
    private void SwitchA()
    {
        hotspots=HSC.hotspots_O;
        foreach (var item in hotspots)
        {
            if (item)
            {
                // Debug.Log(item.gameObject.transform.parent.gameObject.name);
                item.gameObject.transform.parent.gameObject.SetActive(tog.isOn);
            }
        }
        CloseInfoPanel();
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}
