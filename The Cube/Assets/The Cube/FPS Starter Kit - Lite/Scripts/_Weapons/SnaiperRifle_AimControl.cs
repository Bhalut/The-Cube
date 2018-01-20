using UnityEngine;
using System.Collections;

public class SnaiperRifle_AimControl : MonoBehaviour {
    public Texture2D CrossFire;// aim texture
    public Texture2D CrossFireBlack;// black texture

    void OnGUI()
    {
            GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.height / 2, 0, Screen.height, Screen.height), CrossFire);    // 
            GUI.DrawTexture(new Rect(0, 0, Screen.width / 2 - Screen.height / 2, Screen.height), CrossFireBlack);           // draw aim
            GUI.DrawTexture(new Rect(Screen.width / 2 + Screen.height / 2, 0, Screen.width, Screen.height), CrossFireBlack);//
    }
}
