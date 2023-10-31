using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
   public static VFXManager Instance;

    public VFX[] vfxs;

    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
            return;
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    public GameObject FindFX(string name)
    {
        VFX vfx = Array.Find(vfxs, vfx => vfx.name == name);
        if (vfx == null) { return null; }
        Debug.Log(vfx.name);
        return vfx.effect;
    }
}
