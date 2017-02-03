using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject lvlbtnPrefab;
    public GameObject lvlbtnContainer;
    public GameObject colorbtnPrefab;
    public GameObject colorbtnContainer;

    public Material playerMaterial;

    private Transform camTransform;
    private Transform camDesiredLookAt;
    
    
    private void Start()
    {
        Time.timeScale = 1;

        //starts to use the main camera at its position
        camTransform = Camera.main.transform;
        
        //Searches level thumbnail images and makes them buttons
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(lvlbtnPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(lvlbtnContainer.transform, false);

            string sceneName = thumbnail.name;
            
            container.GetComponent<Button> ().onClick.AddListener(() => LoadLevel(sceneName));
        }
        //Searches player color thumbnail images and makes them buttons
        int textureIndex = 0;
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(colorbtnPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(colorbtnContainer.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerColor(index));
            textureIndex++ ;
        }




    }
    
    private void Update()
    {
        if(camDesiredLookAt != null)
        {
            camTransform.rotation = Quaternion.Slerp(camTransform.rotation, camDesiredLookAt.rotation,
                                                                                   3 * Time.deltaTime);
        }
    }
    
    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LookAtMenu(Transform menuTransform)
    {
        camDesiredLookAt = menuTransform;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangePlayerColor(int index)
    {
        float x = (index % 4) * 0.25f;
        float y = ((int)index / 4) * 0.25f;
        if (y == 0.0f)
            y = 0.75f;
        else if (y == 0.25f)
            y = 0.5f;
        else if (y == 0.50f)
            y = 0.25f;
        else if (y == 0.75f)
            y = 0f;

        playerMaterial.SetTextureOffset("_MainTex", new Vector2(x,y));
        PlayerPrefs.SetInt("playerMaterial", index);

    }
}
