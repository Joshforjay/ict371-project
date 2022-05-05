using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartController : MonoBehaviour
{
    public GameObject[] slides;
    public GameObject[] firstButtonOnSlides;
    [SerializeField]
    private int currentActive = 0;
    private bool hidden = false;

    // Start is called before the first frame update
    void Start()
    {
        if(slides.Length != 0)
        {
            slides[0].SetActive(true);
            set_first_button_active();
            Debug.Log(slides.Length);
            for(int count = 1; count < slides.Length; count++)
            {
                slides[count].SetActive(false);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next_slide()
    {
        if(slides.Length != currentActive + 1)
        {
            slides[currentActive].SetActive(false);
            currentActive++;
            slides[currentActive].SetActive(true);
            set_first_button_active();
        }
        
    }

    public void previous_slide()
    {
        if (currentActive != 0)
        {
            slides[currentActive].SetActive(false);
            currentActive--;
            slides[currentActive].SetActive(true);
            set_first_button_active();
        }
    }

    public void skip_to_end()
    {
        if(slides.Length == 0) { return; }

        slides[currentActive].SetActive(false);
        currentActive = slides.Length - 1;
        slides[currentActive].SetActive(true);
        set_first_button_active();
    }

    public void hide_slides()
    {
        slides[currentActive].SetActive(false);
        hidden = true;
    }

    public void show_slides()
    {
        slides[currentActive].SetActive(true);
        set_first_button_active();
        hidden = false;
    }

    public void set_active_slide(int slideNumber)
    {
        if(slideNumber >= 0 && slideNumber < slides.Length)
        {
            slides[currentActive].SetActive(false);
            currentActive = slideNumber;
            slides[currentActive].SetActive(true);
            set_first_button_active();
        }
    }

    private void set_first_button_active()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButtonOnSlides[currentActive]);
    }

    public bool is_active()
    {
        return hidden;
    }
}
