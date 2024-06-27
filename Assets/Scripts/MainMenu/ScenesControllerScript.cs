using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesControllerScript : MonoBehaviour
{
    public void LoadCuadroPiezasT()
    {
        SceneManager.LoadScene("CuadroPiezasT");
    }
    public void LoadTrianguloHexa()
    {
        SceneManager.LoadScene("Triangulo-Hexagono");
    }
    public void LoadDisksGame()
    {
        SceneManager.LoadScene("DisksScene_QR");
    }

    public void LoadFourEquations()
    {
        SceneManager.LoadScene("FourEquationsScene_QR");
    }

    public void LoadRLHM()
    {
        SceneManager.LoadScene("Hanoi_QR");
    }
    public void LoadCubos()
    {
        SceneManager.LoadScene("RL&HM");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadHerradura()
    {
        SceneManager.LoadScene("Herradura_QR");
    }

    public void LoadColorSquares()
    {
        SceneManager.LoadScene("ColorSquaresScene");
    }

    public void LoadMagicSquare()
    {
        SceneManager.LoadScene("MagicSquare_QR");
    }

    public void LoadTPuzzle()
    {
        SceneManager.LoadScene("TPuzzle");
    }
    public void LoadSolitaireChess()
    {
        SceneManager.LoadScene("SolitaireChess_QR");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
