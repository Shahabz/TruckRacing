using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;


public class PlayerPrefsDelete : EditorWindow {

	[MenuItem("Mortal Games/PlayerPrefs/Delete %Q")]
    public static void DeletePrefs() {
        PlayerPrefs.DeleteAll();
        EditorUtility.DisplayDialog("Mortal Games","PlayerPrefs deleted successfully","Ok");

    }

}
