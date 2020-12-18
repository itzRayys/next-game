using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGithubScript : MonoBehaviour
{
    public void OpenGithub()
    {
        System.Diagnostics.Process.Start("https://github.com/itzRayys");
    }
}
