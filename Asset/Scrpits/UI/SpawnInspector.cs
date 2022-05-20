using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnInspector : MonoBehaviour {
    public Image image;
    public Text name_ko;

   public void setContent(SpawnContent content) {
        image.sprite = content.sprite;
    }

    public void setInit() {
        image.sprite = null;
    }
}
