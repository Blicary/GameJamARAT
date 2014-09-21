using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelLoader : MonoBehaviour
{
    public List<string> levels_ordered;
    private int level_index = 0;


    public void Start()
    {
        DontDestroyOnLoad(transform);
    }

    public void FirstLevel()
    {
        level_index = 0;
        LoadLevel();
    }

    public void NextLevel()
    {
        level_index++;
        LoadLevel();
    }

    private void LoadLevel()
    {
        if (level_index >= levels_ordered.Count)
        {
            Debug.Log("No more levels");
            return;
        }
        Application.LoadLevel(levels_ordered[level_index]);
    }
}
