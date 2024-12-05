using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptQuebraGanhoNoMenu : MonoBehaviour
{

    public void quebraGanhoReturnOqueQuero(int num)
    {
        SceneManager.LoadScene(num);
    }
}
