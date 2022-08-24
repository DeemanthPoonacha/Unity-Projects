using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    public AssetReferenceGameObject character;
    GameObject charObj;

    public Transform objParent;

    void Start()
    {
        Addressables.InstantiateAsync(character,objParent).Completed+=Assign;
    }

    private void Assign(AsyncOperationHandle<GameObject> obj)
    {
        charObj = obj.Result;
    }
}
