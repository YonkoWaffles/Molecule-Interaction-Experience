using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuOpenOnButton : MonoBehaviour
{
    [SerializeField] private InputActionReference menuInputActionReference;

    [SerializeField] private GameObject startMenuGO;

    bool menuEnabled = false;

    private void OnEnable()
    {
        menuInputActionReference.action.started += MenuPressed;
    }

    private void OnDisable()
    {
        menuInputActionReference.action.started -= MenuPressed;
    }

    private void MenuPressed(InputAction.CallbackContext context)
    {
        menuEnabled = !menuEnabled;
        startMenuGO.SetActive(menuEnabled);
    }

    public void DisableMenu ()
    {
        menuEnabled = false;
        startMenuGO.SetActive(menuEnabled);
    }

    public void QuitToMainMenuButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SliderValueChanged(float newValue)
    {
        AudioListener.volume = newValue;
    }
}
