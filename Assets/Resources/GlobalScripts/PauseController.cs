using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPaused = false;

    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject PauseFirstSelected;
    [SerializeField]
    private GameObject PauseButton;

    [SerializeField]
    private GameObject[] infoMenus;
    [SerializeField]
    private GameObject[] infoFirstSelected;
    private int currentActive = 0;

    void Start()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        for(int count = 0; count < infoMenus.Length; count++)
        {
            infoMenus[count].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            show_pause_menu();
        }



    }

    public void show_pause_menu()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        isPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(PauseFirstSelected);
    }

    public void hide_pause_menu()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        isPaused = false;
    }

    public void show_info_menu()
    {
        PauseMenu.SetActive(false);
        info_menu(0);
    }

    public void hide_info_menu()
    {
        show_pause_menu();
        infoMenus[currentActive].SetActive(false);
    }

    public void next_info_menu()
    {
        infoMenus[currentActive].SetActive(false);
        currentActive += 1;
        currentActive = Mathf.Clamp(currentActive, 0, infoMenus.Length - 1);
        infoMenus[currentActive].SetActive(true);
        set_first_selected();
    }

    public void previous_info_menu()
    {
        infoMenus[currentActive].SetActive(false);
        currentActive -= 1;
        currentActive = Mathf.Clamp(currentActive, 0, infoMenus.Length - 1);
        infoMenus[currentActive].SetActive(true);
        set_first_selected();
    }

    public void info_menu(int index)
    {
        index = Mathf.Clamp(index, 0, infoMenus.Length - 1);
        infoMenus[currentActive].SetActive(false);
        currentActive = index;
        infoMenus[currentActive].SetActive(true);
        set_first_selected();

    }
    private void set_first_selected()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(infoFirstSelected[currentActive]);
    }

}
