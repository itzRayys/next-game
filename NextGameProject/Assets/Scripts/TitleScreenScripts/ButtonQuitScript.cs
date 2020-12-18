using UnityEngine;

public class ButtonQuitScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
