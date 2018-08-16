using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GunTypeHolder
    :
    MonoBehaviour
{
    [System.Serializable]
    public struct GunStats
    {
        public float damage;
        public float lifetime;
        public float speed;
        // Half of possible spread in degrees. :(
        public float spread;
        public float nBullets;
        public float reloadTime;
    }
    // 
    public GunStats GetStats( GunScript.GunType type )
    {
        GunStats returnGun = pistol;
        switch( type )
        {
            case GunScript.GunType.Pistol: returnGun = pistol; break;
            case GunScript.GunType.Shotgun: returnGun = shotgun; break;
            default:
                Assert.IsTrue( false );
                break;
        }
        return( returnGun );
    }
    // 
    [SerializeField] public GunStats pistol;
    [SerializeField] public GunStats shotgun;
}
