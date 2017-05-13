using System;
using UnityEngine;

public class SelectLevel : MonoBehaviour, IBackAble
{
    public GameObject fadeGround;

    protected SelectMenu selectMenu;
    void Start()
    {
        selectMenu = FindObjectOfType<SelectMenu>();
    }

    public void OnSelectPressed()
    {
        fadeGround.SetActive(true);
        selectMenu.Appear(this);
    }

    public void Back()
    {
        fadeGround.SetActive(false);
    }
}
