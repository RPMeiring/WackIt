using Controllers;
using General;
using UnityEngine;

public class IndexController : MonoBehaviour
{
    #region SCENE
    
    /// <summary>
    /// Intended for attachment to button in Scene.
    /// </summary>
    public void BtnPlay()
    {
        startGame();
    }

    /// <summary>
    /// Intended for attachment to button in Scene.
    /// </summary>
    public void BtnHighScore()
    {
        checkScores();
    }

    #endregion

    /// <summary>
    /// Go to score window.
    /// </summary>
    private void checkScores()
    {
        WindowController.Instance.GoToWindow(WindowType.HighScore);
    }

    /// <summary>
    /// Start playing main game.
    /// </summary>
    private void startGame()
    {
        WindowController.Instance.GoToWindow(WindowType.Game);
    }
}
