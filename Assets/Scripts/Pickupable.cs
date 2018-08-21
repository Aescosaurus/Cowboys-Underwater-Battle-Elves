using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Pickupable
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Cowboy" );
        playerScore = player.GetComponent<CowboyScore>();
        Assert.IsNotNull( player );
        Assert.IsNotNull( playerScore );

        unlockMsg = Instantiate( Utility.GetPrefabHolder().purchaseWeapon );
        unlockMsg.transform.position = new Vector3( 999.9f,999.9f,999.9f );
        Assert.IsNotNull( unlockMsg );

        origY = transform.position.y;
    }
    void Update()
    {
        transform.Rotate( transform.up,rotSpeed * Time.deltaTime );
        var oPos = transform.position;
        var pos = new Vector3( oPos.x,oPos.y,oPos.z );
        pos.y = origY + Mathf.Sin( Time.time ) * 0.67f;
        transform.position = pos;

        var vec = player.transform.position - transform.position;
        var lenSq = vec.sqrMagnitude;

        if( !unlocked && lenSq < rangeSq )
        {
            // Tell player they're allowed to unlock stuff.
            unlockMsg.transform.position = player
                .transform.position + msgOffset;

            if( Input.GetAxis( "Interact" ) > 0.0f &&
                playerScore.GetScore() >= pointsRequired/* &&
                !unlocked*/ )
            {
                unlocked = true;

                // transform.position = new
                //     Vector3( transform.position.x,
                //     origY,
                //     transform.position.z );

                playerScore.RemoveScore( pointsRequired );
                player.GetComponent<CowboyShoot>()
                    .GiveGun( Instantiate( gameObject ) );

                Destroy( unlockMsg );
                // Don't destroy cuz the player uses it.
                Destroy( gameObject );
            }
        }
        else if( !unlocked )
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
    bool unlocked = false;
    const float rotSpeed = 35.2f;
    float origY;
}
