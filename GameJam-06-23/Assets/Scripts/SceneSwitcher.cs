using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {       
    }

    public void SceneSwitch(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
