using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour
{

    bool menuOpen = false;
    public GameObject mainMenuPanel;
    public GameObject objectivesMenuPanel;
    public GameObject settingsPanel;
    public GameObject playerCapsule;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerCapsule = GameObject.Find("PlayerCapsule");
        HideAllMenus();
    }

    // Update is called once per frame
    void Update()
    {
        //Listen for Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen)
            {
                Time.timeScale = 0;
                ShowMainMenu();
                SetFirstPersonMouseLook(false);
                gameManager.SetGamePause(true);
            }
            else
            {
                Time.timeScale = 1;
                HideAllMenus();
                SetFirstPersonMouseLook(true);
                gameManager.SetGamePause(false);
            }
            menuOpen = !menuOpen;
        }
    }

    private void SetFirstPersonMouseLook(bool b)
    {
        if (!b)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        playerCapsule.SetActive(b);
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        //emulate quit game in editor context
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void HideAllMenus()
    {
        mainMenuPanel.SetActive(false);
        objectivesMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        HideAllMenus();
        mainMenuPanel.SetActive(true);
    }

    public void ShowObjectivesPanel()
    {
        Debug.Log("show objectives");
        HideAllMenus();
        objectivesMenuPanel.SetActive(true);
    }

    public void ShowSettingsPanel()
    {
        HideAllMenus();
        settingsPanel.SetActive(true);
    }
}
