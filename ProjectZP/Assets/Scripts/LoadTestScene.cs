using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadTestScene : MonoBehaviour {

	public void LoadTest()
    {
        SceneManager.LoadScene("TestScene");
    }
}
