using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool pauseToggle;
    private int currentPage;//Gets the current help page

    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject health = null;
    [SerializeField] GameObject momentum = null;
    [SerializeField] GameObject nextButton = null;
    [SerializeField] GameObject prevButton = null;
    [SerializeField] GameObject[] pages = null;

    // Start is called before the first frame update
    void Start()
    {
        pauseToggle = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseToggle)
            {//Unpauses the game
                pauseToggle = false;
                //Reset the paused effect
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                health.SetActive(true);
                momentum.SetActive(true);
            }
            else
            {//Pauses the game
                pauseToggle = true;
            }
        }


        if (pauseToggle)
        {
            //Pauses the physics
            Time.timeScale = 0;
            //Enables the menu
            pauseMenu.SetActive(true);
            health.SetActive(false);
            momentum.SetActive(false);
        }
    }

    public void Prev()
    {
        Debug.Log(currentPage);
        if (currentPage > 0)
        {
            //change pages
            pages[currentPage].SetActive(false);
            currentPage -= 1;
            pages[currentPage].SetActive(true);
            Debug.Log(currentPage);

            //change buttons if needed
            if (currentPage < 1)
            {
                prevButton.SetActive(false);//if you shouldn't be able to press prev
            }
            else if (currentPage == pages.Length - 1)
            {
                nextButton.SetActive(true);//if you should be able to press next
            }
        }
    }
 

    public void Next()
    {
        if (currentPage < pages.Length - 1)
        {
            //change pages
            pages[currentPage].SetActive(false);
            currentPage += 1;
            pages[currentPage].SetActive(true);
            Debug.Log(currentPage);

            //change buttons if needed
            if (currentPage > 0)
            {
                prevButton.SetActive(true);//if you shouldn't be able to press prev
            }
            else if (currentPage == pages.Length - 1)
            {
                nextButton.SetActive(false);//if you should be able to press next
            }
        }
    }
}
