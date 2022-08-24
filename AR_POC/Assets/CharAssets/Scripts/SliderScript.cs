using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Transform objParent;
    Slider slider;
    public Shader[] sh1;
    public Text message;
    public Material mat;
    public GameObject colorChanger;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ScaleUpdate()
    {
        // obj = GameObject.FindWithTag("Player");
        GameObject obj = objParent.GetChild(0).gameObject;
        Vector3 temp = obj.transform.localScale;
        temp = Vector3.one*slider.value;
        obj.transform.localScale = temp;
        // message.text = obj.name;
    }

    public void ShaderUpdate()
    {
        // obj = GameObject.FindWithTag("Player");
        GameObject obj = objParent.GetChild(0).gameObject;

        // obj.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white * slider.value;
        // obj.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].shader = sh1[(int)slider.value];
        var renderer = obj.GetComponentsInChildren<SkinnedMeshRenderer>();

        for (int i = 0; i < renderer.Length; i++)
        {
            foreach (var items in renderer[i].materials)
            {
                if (items.shader != mat.shader)
                {
                    items.shader = sh1[(int)slider.value];
                }
            }
        }
        colorChanger.SetActive(slider.value == 3);
    }


}
