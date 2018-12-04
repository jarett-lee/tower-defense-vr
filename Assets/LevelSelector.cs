using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	public void Select (string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
