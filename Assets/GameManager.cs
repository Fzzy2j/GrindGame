using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager I;

    public int SurfaceLayer;
    public int DeathPlaneLayer;
    public int SpeedSurfaceLayer;
    public int GrappleSurfaceLayer;
    
	private void Awake () {
        if (I == null)
        {
            DontDestroyOnLoad(gameObject);
            I = this;
        } else if (I != this)
        {
            Destroy(gameObject);
        }
	}
}
