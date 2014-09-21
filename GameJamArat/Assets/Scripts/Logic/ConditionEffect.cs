using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConditionEffect : MonoBehaviour 
{
    public List<Condition> conditions;
    public List<Effect> effects;

    public void Update()
    {
        // check if conditions are complete
        foreach (Condition c in conditions)
        {
            if (!c.Met()) return;
        }

        // all conditions met... do actions
        foreach (Effect e in effects)
        {
            e.Do();
        }
    }
}
