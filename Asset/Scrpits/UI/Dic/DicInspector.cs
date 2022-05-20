using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DicInspector : MonoBehaviour {
    public Image image;
    public Text nameKo;

    public void setContent(DicContent content) {
        image.sprite = content.sprite;
        nameKo.text = content.info.name_ko;
    }

    public void setInit() {
        image.sprite = null;
        nameKo.text = "";
    }
}
