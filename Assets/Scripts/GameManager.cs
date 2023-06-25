using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PlayerInputManager playerInputManager;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        playerInputManager.OnAnyKey += DisableWaitForInput;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    private void DisableWaitForInput()
    {
        playerInputManager.ToggleWaitInput(false);
        playerInputManager.ToggleInputs(true);
        UIManager.Instance.ToggleDialogBox(false);
    }
    
    public void WaitForInput()
    {
        playerInputManager.ToggleWaitInput(true);
        playerInputManager.ToggleInputs(false);
    }
}
