using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public EventHandler<LocationChangedArgs> OnPlayerLocationChanged;

    public void PlayerLocationChanged(object sender, bool onStation)
    {
        OnPlayerLocationChanged?.Invoke(sender, new LocationChangedArgs(onStation));
    }

}

public class LocationChangedArgs : EventArgs
{
    public bool onStation;
    public LocationChangedArgs(bool onStation)
    {
        this.onStation = onStation;
    }
}
