using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Yle/YleSettings")]
public class YleSettings : ScriptableObject
{
    [SerializeField]
    private string appKey;
    [SerializeField]
    private string appId;

    public string AppKey
    {
        get { return appKey; }
    }

    public string AppId
    {
        get { return appId; }
    }
}
