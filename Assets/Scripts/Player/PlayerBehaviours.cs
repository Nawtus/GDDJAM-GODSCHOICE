using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{

    public float stormCrono;
    protected bool canSumonerStorm = true;


    public float tornadoCrono;
    protected bool canSumonerTornado = true;


    public float tsunamiCrono;
    protected bool canSumonerTsunami = true;

    protected float CountdownStorm()
    {
        return stormCrono += Time.deltaTime;
    }

    protected float CountdownTornado()
    {
        return tornadoCrono += Time.deltaTime;
    }

    protected float CountdownTsunami()
    {
        return tsunamiCrono += Time.deltaTime;
    }
}

    
