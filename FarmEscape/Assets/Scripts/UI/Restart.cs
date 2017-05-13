using UnityEngine;

public class Restart : MonoBehaviour {

	public void RestartLevel()
    {
        FindObjectOfType<Pause>().UnPause();
        FindObjectOfType<PauseMenu>().Disappear();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
