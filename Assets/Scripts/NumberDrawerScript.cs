using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class NumberDrawerScript
    :
    MonoBehaviour
{
    enum Number
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }
    // 
    void Start()
    {
        Assert.IsTrue( zeroToNine.Length == 10 );
    }
    // 
    public void AddNums( List<int> nums,Vector3 pos )
    {
        AddNums( nums );
        MoveNumsTo( pos );
    }
    public void AddNums( List<int> nums )
    {
        Assert.IsTrue( activeNums.Count < 1 );

        foreach( var n in nums )
        {
            var theNum = Instantiate( zeroToNine[n] );
            theNum.transform.Rotate( Vector3.up,90.0f );
            activeNums.Add( theNum );
        }
    }
    public void MoveNumsTo( Vector3 pos )
    {
        for( int i = 0; i < activeNums.Count; ++i )
        {
            // Copy, no ref pls.
            var tempPos = new Vector3( pos.x,pos.y,pos.z );

            tempPos.x += i * moveAddMult;

            activeNums[i].transform.position = tempPos;
        }
    }
    public void DestroyNums()
    {
        foreach( var x in activeNums )
        {
            Destroy( x );
        }
        activeNums.Clear();
    }
    public List<int> SplitToList( int start )
    {
        var returnList = new List<int>();
        string stringified = start.ToString();
        foreach( var c in stringified )
        {
            returnList.Add( int.Parse( c.ToString() ) );
        }
        return( returnList );
    }
    // 
    [SerializeField] GameObject[] zeroToNine;
    List<GameObject> activeNums = new List<GameObject>();
    const float moveAddMult = 0.8f;
}
