using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Utility
{
    public static GameObject FindInScene( string name )
    {
        GameObject[] matches = GameObject
            .FindGameObjectsWithTag( name );

        Assert.IsTrue( matches.Length == 1 );

        return( matches[0] );
    }
    public static PrefabHolderScript GetPrefabHolder()
    {
        return( FindInScene( "PrefabHolder" )
            .GetComponent<PrefabHolderScript>() );
    }
}
