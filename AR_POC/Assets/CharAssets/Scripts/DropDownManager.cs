using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DropDownManager : MonoBehaviour
{
    Dropdown dropDown;
    public Transform objParent;
    public bool isAddressable=false;
    public bool editorMode=false;
    public Toggle tog;
    public AssetReferenceGameObject[] character;
    public GameObject[] charPrefs;
    GameObject charObj;
    Vector3 charPos;
    Quaternion charRot;
    public Slider ScaleSlider;
    public Slider textureSlider;
    public Text message;
    public HotspotController HSC;
    // public ParticleSystem spawnFx;

    void OnEnable()
    {
        dropDown = GetComponent<Dropdown>();
        ClearChildren(objParent,0);
        // #if UNITY_EDITOR
        if(editorMode)
        {
            Destroy(charObj);
            InstantiateObj(charPos,charRot);
        }
        // #endif
    }
    public void enAddressable()
    {
        isAddressable=tog.isOn;
    }

    public GameObject InstantiateObj(Vector3 pos, Quaternion rot)
    {
        charPos = pos;
        charRot = rot;
        ClearChildren(objParent,0);
        if (isAddressable)
        {
            Addressables.InstantiateAsync(character[dropDown.value], objParent).Completed += Assign;
        }
        else
        {
            charObj = GameObject.Instantiate(charPrefs[dropDown.value], charPos, charRot, objParent);
            AssignAttributes();
        }
        return charObj;
    }
    public void Ref()
    {
        ClearChildren(objParent,1);
    }

    private void ClearChildren(Transform obj,int fromIndex)
    {
        if (obj.childCount > 0)
        {
            for (int i = fromIndex; i < obj.childCount; i++)
            {
                Destroy(obj.GetChild(i).gameObject);
            }
        }
    }

    public void ChangeChar()
    {
        charPos = charObj.transform.position;
        charRot = charObj.transform.rotation;
        // Debug.Log(charPos);
        Destroy(charObj);
        InstantiateObj(charPos, charRot);
        // Addressables.InstantiateAsync(character[dropDown.value], objParent).Completed += Assign;
        FindObjectOfType<Switch>().SwitchActivation();
    }

    private void Assign(AsyncOperationHandle<GameObject> obj)
    {
        charObj = obj.Result;
        charObj.transform.SetPositionAndRotation(charPos, charRot);
        AssignAttributes();
    }
    void AssignAttributes()
    {
        // spawnFx.Play();
        charObj.name = charObj.name.TrimEnd("(Clone)".ToCharArray());

        ScaleSlider.minValue = charObj.transform.localScale.x;
        ScaleSlider.value = ScaleSlider.minValue;

        textureSlider.value = textureSlider.minValue;
        message.text = charObj.name;

        HSC.GetHS();

    }
}
