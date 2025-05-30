using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : Switch
{
    [SerializeField]
    private GameObject[] triggerablesObj;
    List<ITriggerable> triggerables = new List<ITriggerable>();

    private void Start()
    {
        foreach (var triggerable in triggerablesObj)
        {
            triggerables.Add(triggerable.GetComponent<ITriggerable>());
        }
    }

    public void Update()
    {
        if (!IsActive)
        {
            return;
        }
        ActSwitch();
        
    }

    private void ActSwitch()
    {
        foreach (ITriggerable triggerable in triggerables)
        {
            triggerable.TriggerReact();
        }
        Deactivate();
    }

}
