using UnityEngine;
using System.Collections;

public class LevelComplete : Effect 
{
    public LevelLoader loader;

    public override void Do()
    {
        loader.NextLevel();
    }

    private IEnumerator NextLevel()
    {
        while (true)
        {
            Debug.Log(Time.time);
            yield return null;
        }
    }
}
