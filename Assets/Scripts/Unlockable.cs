using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Unlockable
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Cowboy" );
        playerScore = player.GetComponent<CowboyScore>();
        Assert.IsNotNull( player );
        Assert.IsNotNull( playerScore );

        unlockMsg = Instantiate( Utility.GetPrefabHolder().openFence );
        unlockMsg.transform.position = new Vector3( 999.9f,999.9f,999.9f );
        Assert.IsNotNull( unlockMsg );
    }
    void Update()
    {
        var vec = player.transform.position - transform.position;
        var lenSq = vec.sqrMagnitude;

        if( lenSq < rangeSq )
        {
            // Tell player they're allowed to unlock stuff.
            unlockMsg.transform.position = player
                .transform.position + msgOffset;

            if( Input.GetAxis( "Interact" ) > 0.0f &&
                playerScore.GetScore() > pointsRequired )
            {
                playerScore.RemoveScore( pointsRequired );
                Destroy( unlockMsg );
                Destroy( gameObject );
            }
        }
        else
        {
            unlockMsg.transform.position = new Vector3( 999.9f,999.9f,999.9f );
        }
    }
    // 
    [SerializeField] int pointsRequired;
    GameObject player;
    CowboyScore playerScore;
    GameObject unlockMsg;
    Vector3 msgOffset = new Vector3( 0.0f,0.72f,0.0f );
    const float unlockRange = 8.1f;
    const float rangeSq = unlockRange * unlockRange;
}
