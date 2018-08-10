using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Igloo
    :
    MonoBehaviour
{
    void Start()
    {
        elf = Utility.GetPrefabHolder().elf;
        elfSpawnPos = transform.GetChild( 0 );
    }
    void Update()
    {
        Assert.IsNotNull( elf );
        Assert.IsNotNull( elfSpawnPos );

        respawn.Update( Time.deltaTime * multAmount );

        if( respawn.IsDone() )
        {
            multAmount = Random.Range( minMult,maxMult );
            respawn.Reset();

            var temp = Instantiate( elf );
            temp.transform.position = elfSpawnPos.position;
        }
    }
    // 
    GameObject elf;
    Transform elfSpawnPos;
    Timer respawn = new Timer( 12.0f );
    float multAmount = 1.0f;
    const float minMult = 0.6f;
    const float maxMult = 1.6f;
}
