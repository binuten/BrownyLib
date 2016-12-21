using UnityEngine;


public class StageInteractivePosition : MonoBehaviour
{


    // public static string TYPEA = "type_4x3";
    // public static string TYPEB = "type_16x10";
    public static string stageType = "none";

    public static void positionChg_TR(Transform target, float tX, float tY)
    {
        //Vector3 worldPosi = Camera.main.WorldToScreenPoint(target.position);
        Vector3 screenPosi = new Vector3(tX / 1024 * Screen.width, tY / 768 * Screen.height);
        //Debug.Log(screenPosi);
        //Debug.Log(tY / 800 * Screen.height);
        //Debug.Log(Screen.height);
        // float __x = tX / 1280 * Screen.width;
        // float __y = tY / 800 * Screen.height;
        Vector3 localPosi = Camera.main.ScreenToWorldPoint(screenPosi);
        // Vector3 localPosi = Camera.main.ScreenToViewportPoint(screenPosi);
        //Debug.Log(localPosi);
        // target.localPosition.x * Screen.width / 1280;
        // camera.current.WorldToScreenPoint(target.position);
        //var screenPos : Vector3 = camera.WorldToScreenPoint (target.position);
        target.localPosition = new Vector3(localPosi.x, localPosi.y, target.localPosition.z);
    }


    public static Vector3 positionChg_TR3(Transform target, float addX = 1f)
    {

        if (stageType == "none")
        {
            setScreenType();
        }

        switch (stageType)
        {

            case "type_4x3":
                break;
            case "type_3x2":
                target.position = new Vector3(target.position.x * 1.071428571428571f * addX,
                    target.position.y, target.position.z);
                break;
            case "type_16x10":
                target.position = new Vector3(target.position.x * 1.21123595505618f * addX,
                    target.position.y, target.position.z);
                break;
            case "type_16x9":
                target.position = new Vector3(target.localPosition.x * 1.357303370786517f * addX,
                    target.position.y, target.position.z);
                break;
        }


        return target.localPosition;
    }

    public static Vector3 positionChg_TR4(Transform target)
    {

        if (stageType == "none")
        {
            setScreenType();
        }

        switch (stageType)
        {

            case "type_4x3":
                break;
            case "type_3x2":
                //target.position = new Vector3(target.position.x * 1.05,
                //    target.position.y, target.position.z);
                break;
            case "type_16x10":
                target.position = new Vector3(target.position.x * 1.1f,
                    target.position.y, target.position.z);
                break;
            case "type_16x9":
                target.position = new Vector3(target.localPosition.x * 1.14f,
                    target.position.y, target.position.z);
                break;
        }


        return target.localPosition;
    }




    public static string TYPEA()
    { return "type_4x3"; }
    public static string TYPEB()
    { return "type_3x2"; }
    public static string TYPEC()
    { return "type_16x10"; }
    public static string TYPED()
    { return "type_16x9"; }

    public static string setScreenType()
    {
        string type = "N";

        float _w = Screen.width;
        float _h = Screen.height;
        float size = _w / _h;

        if (size < 1.4f) { type = TYPEA(); }
        else if (size < 1.52f) { type = TYPEB(); }
        else if (size < 1.7f) { type = TYPEC(); }
        else if (size < 1.8f) { type = TYPED(); }
        stageType = type;
        Debug.Log("-------------" + stageType);
        return type;
    }

}