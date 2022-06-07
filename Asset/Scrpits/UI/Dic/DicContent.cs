using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DicContent : MonoBehaviour {
    public Image image;
    public Text name_ko;
    public AtomInfo info;
    public Sprite sprite;

    public void setAtomInfo(AtomInfo info) {
        this.info = info;
        var sprite = Resources.Load<Sprite>(info.imagePath);
        this.sprite = sprite;
        if(info.isDiscovered == true) {
            name_ko.text = info.name_ko;
        } else {
            name_ko.text = "???";
        }
    }

    public void grabbed() {

    }

    public void ungrabbed() {

    }
}
