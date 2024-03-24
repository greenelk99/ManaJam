using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWorlds : MonoBehaviour
{

    public static SwitchingWorlds Instance;

    [SerializeField] private List<GameObject> _wordlOneObjects;
    [SerializeField] private List<GameObject> _wordlTwoObjects;

    [SerializeField] private float _hiddenWorldAlpha;

    [SerializeField] private bool _worldOneActive;


    private void Awake()
    {
        Instance = this;
    }

    public void SwitchWorld()
    {
        _worldOneActive = !_worldOneActive;

        Debug.Log("world switch");
        if(_worldOneActive )
        {
            Debug.Log("world one active");
            foreach( GameObject obj in _wordlOneObjects ) { 

               MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                if( renderer != null )
                {
                    Color color = renderer.material.color;
                    color.a = 1;
                    renderer.material.color = color;
                }
            
            }
            foreach (GameObject obj in _wordlTwoObjects)
            {

                MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    Color color = renderer.material.color;
                    color.a = _hiddenWorldAlpha;

                    
                    renderer.material.color = color;
                }

            }
        }
        else
        {
            Debug.Log("world two active");
            foreach (GameObject obj in _wordlOneObjects)
            {

                MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    Debug.Log("has render");
                    Color color = renderer.material.color;
                    color.a = _hiddenWorldAlpha;

                    Debug.Log(color);
                    renderer.material.color = color;
                }

            }
            foreach (GameObject obj in _wordlTwoObjects)
            {

                MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    Color color = renderer.material.color;
                    color.a = 1;
                    renderer.material.color = color;
                }

            }
        }
    }


}
