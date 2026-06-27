using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    private void Start()
    {
        container.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeButton() {
        container.SetActive(false);
        Time.timeScale = 1;
    }
    public void mainmenubutton() { }

}
