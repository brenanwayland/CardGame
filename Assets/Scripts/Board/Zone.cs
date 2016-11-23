using UnityEngine;
using System.Collections;

public class Zone {
    
    public enum ZoneType
    {
        BASECAMP,
        WARGROUND
    }

    protected ZoneType zoneType;

    public ZoneType getZoneType()
    {
        return zoneType;
    }
}
