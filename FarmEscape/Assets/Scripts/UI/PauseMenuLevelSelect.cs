using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLevelSelect : MonoBehaviour, IBackAble
{
    PauseMenu pauseMenu;
    SelectMenu levelSelect;
    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        levelSelect = FindObjectOfType<SelectMenu>();
    }

    public void Back()
    {
        pauseMenu.Appear();
    }

    public void OnSelectLevelPressed()
    {
        pauseMenu.Disappear();
        levelSelect.Appear(this);
    }
}
