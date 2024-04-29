using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject info;
    public GameObject menu;
    public GameObject control;
    public GameObject about;
    public GameObject inventorypanel;

    public GameObject end;


    public void playGame()
    {
        Debug.Log("Inshallah");
        menu.SetActive(false);
        about.SetActive(false);
        control.SetActive(false);
        inventorypanel.SetActive(true);

    }
    public void quitGame()
    {
        Debug.Log("Inshallah2");
        Application.Quit();

    }
    public void openControlls()
    {

        menu.SetActive(false);
        about.SetActive(false);
        control.SetActive(true);
    }

    public void openAbout()
    {

        menu.SetActive(false);
        control.SetActive(false);
        about.SetActive(true);
    }


    public void back()
    {
        info.SetActive(false);
        control.SetActive(false);
        about.SetActive(false);
        menu.SetActive(true);
        
    }
    public void back_from_about()
    {
        about.SetActive(false);
        control.SetActive(false);
        menu.SetActive(true);

    }

    public void open_meny()
    {
        about.SetActive(false);
        control.SetActive(false);
        menu.SetActive(true);

    }

    public void end_meny()
    {
        System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
    }
}
