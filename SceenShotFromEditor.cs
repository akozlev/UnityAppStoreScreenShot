using UnityEngine;
/// <summary>
/// ScreenShotFromEditor is a script which allows you 
/// to take screenshots in editor view with the appropriate 
/// resolution so that it is easier to upload to the iOS App Store
/// 
/// Drag this script on the main camera in the scene and set the 
/// game window to the appropriate height and width. Press the K key
/// to take a screenshot.
/// 
/// Resolution Reference:
/// 
/// 
/// 
/// *iPhone Xs Max -- 1242 x 2688
/// iPhone Xr -- 828 x 1792
/// iPhone X/Xs -- 1125 x 2436
/// iPhone 6/6S/7/8  -- 750 x 1334
/// *iPhone 6/6S/7/8 Plus  -- 1242 x 2208
///	iPhone SE -- 640 x 1136
///	
/// *iPad Pro 12.9" 2nd gen -- 2048 x 2732
/// iPad Pro 10.5" -- 2224 x 1668
/// iPad Pro 9.7" -- 1536 x 2048
/// iPad Air 2 -- 1536 x 2048
/// iPad Mini -- 1536 x 2048
/// 
/// * required by App Store Submission
/// 
/// </summary>
public class ScreenShotFromEditor : MonoBehaviour
{

    public KeyCode keyToPress = KeyCode.K;
    public int resolutionModifier = 1;
    public string prefix = "ss";

    bool takePicture = false;

    void Start()
    {
        if ( !System.IO.Directory.Exists(Application.dataPath + "/../Screenshots") )
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "/../Screenshots");
        }
    }

    void Update()
    {
        if ( Input.GetKeyDown(keyToPress) )
        {
            takePicture = true;
        }
    }

    void OnPostRender()
    {
        if ( takePicture )
        {
            string dateTime = System.DateTime.Now.Month.ToString() + "-" +
                System.DateTime.Now.Day.ToString() + "_" +
                System.DateTime.Now.Hour.ToString() + "-" +
                System.DateTime.Now.Minute.ToString() + "-" +
                System.DateTime.Now.Second.ToString();
            string filename = prefix + "_" + dateTime + ".png";
            ScreenCapture.CaptureScreenshot((Application.dataPath + "/../Screenshots/" + filename), resolutionModifier);
            takePicture = false;
        }
    }

}