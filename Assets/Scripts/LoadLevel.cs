using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class LoadLevel : MonoBehaviour
{   
   public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
	
}
