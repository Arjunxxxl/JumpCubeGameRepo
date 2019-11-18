using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public bool isInternetAvaialable;
    

    #region SingleTon
    public static NetworkManager Instance;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isInternetAvaialable = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            CheckForInternet();
        }
    }

    public bool CheckForInternet()
    {
        if(Application.internetReachability != NetworkReachability.NotReachable)
        {
            //StartCoroutine(checkInternetConnection());
            isInternetAvaialable = true;
        }
        else
        {
            isInternetAvaialable = false;
        }

        return isInternetAvaialable;
    }

    IEnumerator checkInternetConnection()
    {
        UnityWebRequest unityWebRequest = new UnityWebRequest("http://www.google.com");
        
        yield return null;

        if (unityWebRequest.error != null || unityWebRequest.isNetworkError)
        {
            isInternetAvaialable = false;
        }
        else
        {
            isInternetAvaialable = true;
        }
    }
}
