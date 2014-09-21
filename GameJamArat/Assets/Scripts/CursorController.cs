﻿using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour 
{
    public Texture2D normal_texture;
    //public Texture2D hover_texture;
    //public Texture2D click_texture;

    public void Start()
    {
        Cursor.SetCursor(normal_texture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
