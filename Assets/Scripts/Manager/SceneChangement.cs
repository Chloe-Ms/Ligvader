using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChangement : MonoBehaviour
{
    [SerializeField] FloatSO _score;
    [SerializeField] FloatSO _highScore;
    [SerializeField] GameObject _menuDisplay;
    [SerializeField] GameObject _optionDisplay;
    [SerializeField] GameObject pauseFirstButton, pauseSecondButton;
    [SerializeField] GameObject optionSlider, optionButton;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] AudioSource _audioSource;
    PauseAction action;
    [SerializeField] GameObject _newHSText;

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
        //New highscore
        if (_score != null && _highScore != null && _score.Value > _highScore.Value)
        {
            _highScore.Value = _score.Value;
            if (_newHSText != null)
            {
                _newHSText.SetActive(true);
            }
        }
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
            if(_audioSource != null)
            {
                _audioSource.Pause();
            }
            Time.timeScale = 0;
            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            _playerAttack.SetInMenu(true); 
            _playerMovement.SetInMenu(true);
        } else
        {
            if (_audioSource != null)
            {
                _audioSource.Play();
            }
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
