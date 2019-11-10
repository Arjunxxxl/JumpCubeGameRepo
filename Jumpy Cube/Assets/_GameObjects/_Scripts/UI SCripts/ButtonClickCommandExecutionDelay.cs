using UnityEngine;

public class ButtonClickCommandExecutionDelay : MonoBehaviour
{
    public float mainmenuCommandExecutionDelay = 0.2f;
    public float pauseMenuCommndExecutionDelay = 0.25f;
    public float ingameMenuCommandExecutionDelay = 0.1f;
    public float revivalMenuCommandExecutionDelay = 0.25f;
    public float gameoverMenuCommandExecutionDelay = 0.25f;
    public float levelMenuCommandExecutionDelay = 0.25f;            //used in level menu
    public float levelOverMenuCommandExecutionDelay = 0.25f;        //used in level menu

    public float storeMenuCommandExecutionDelay = 0.25f;
    

    #region SingleTon
    public static ButtonClickCommandExecutionDelay Instance;
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
}
