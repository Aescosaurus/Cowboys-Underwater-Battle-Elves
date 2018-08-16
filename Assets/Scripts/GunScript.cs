using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GunScript
    :
    MonoBehaviour
{
    public enum GunType
    {
        Pistol,
        Shotgun
    }
    // 
    [SerializeField] public GunType myType;
}
