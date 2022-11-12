using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChangement : MonoBehaviour
{
    [SerializeField] FloatSO _score;
    [SerializeField] GameObject _menuDisplay;
    [SerializeField] GameObject _optionDisplay;
    [SerializeField] GameObject pauseFirstButton, pauseSecondButton;
    [SerializeField] GameObject optionSlider, optionButton;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] PlayerMovement _playerMovement;

    PauseAction action;

    bool _menuDisplayed = false;

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        //Link function to input
        action.Pause.PauseMenu.performed += _ => OnPauseInput();
    }
    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
    public void Restart(string sceneToLoad)
    {
        //Reinitialize the score
        _score.Value = 0;
        ChangeScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayMenu(bool isDisplayed)
    {
        
        _menuDisplay.SetActive(isDisplayed);
        if (isDisplayed)
        {
            Time.timeScale = 0;
            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            _playerAttack.SetInMenu(true); 
            _playerMovement.SetInMenu(true);
        } else
        {
            _playerAttack.SetInMenu(false);
            _playerMovement.SetInMenu(false);
            Time.timeScale = 1;
            DisplayOptions(false);
        }
        _menuDisplayed = !_menuDisplayed;
    }

    public void DisplayOptions(bool isDisplayed)
    {
        _optionDisplay.SetActive(isDisplayed);
        if (isDisplayed)
        {
            EventSystem.current.SetSelectedGameObject(null);
            //Set new selected object
            EventSystem.current.SetSelectedGameObject(optionSlider);
        }
    }

    void OnPauseInput()
    {
        DisplayMenu(!_menuDisplayed);
    }
}
