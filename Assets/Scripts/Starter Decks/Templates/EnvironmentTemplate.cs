using UnityEngine;
using System.Collections;

public class EnvironmentTemplate : Environment {

    override
    public void effect()
    {

    }

    public EnvironmentTemplate()
    {
        cardName = "";
        envType = EnvType.CITY;
    }

    public EnvironmentTemplate(string name, EnvType et) : base(name, et)
    {

    }
}
