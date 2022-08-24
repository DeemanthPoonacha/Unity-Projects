using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Transform objParent;
    public GameObject panel;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Slider opacity;
    public Material mat;
    private Toggle toggle;
    private void Awake() 
    {
        toggle = GetComponent<Toggle>();
        ActivatePanel();
    }
    public void ActivatePanel()
    {
        panel.SetActive(!toggle.isOn);
    }
    public void ColourUpdate()
    {
        // obj = GameObject.FindWithTag("Player");
        GameObject obj = objParent.GetChild(0).gameObject;
        Color newColor = new Color(red.value, green.value, blue.value, opacity.value);
        // obj.GetComponentInChildren<SkinnedMeshRenderer>().materials[1] = mat;
        var mats = obj.GetComponentInChildren<SkinnedMeshRenderer>().materials;
        foreach (var i in mats)
        {
            // if (i.shader == mat.shader)
            // {
                i.color = newColor;
            // }
        }
        // mats[mats.Length-1].color = newColor;
        toggle.GetComponentInChildren<Image>().color = newColor;
        newColor.a = 1;

        toggle.graphic.color = newColor;
    }
}
