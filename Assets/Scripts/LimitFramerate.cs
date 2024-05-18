using UnityEngine;

public class LimitFramerate {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeInitialized()
    {
        // Limit the framerate to 144 
        Application.targetFrameRate = 144;
    }
}