using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PannelGamePlay PannelGamePlay;
    private void Awake()
    {
        if(Instance == null)
        {
            PannelGamePlay = GetComponentInChildren<PannelGamePlay>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
