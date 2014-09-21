using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelLoader : MonoBehaviour
{
    public List<string> levels_ordered;
    private int level_index = 0;

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
        Application.LoadLevel(levels_ordered[level_index]);
    }
}
