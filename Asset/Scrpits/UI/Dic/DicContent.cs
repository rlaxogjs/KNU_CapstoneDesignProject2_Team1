using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DicContent : MonoBehaviour {
    public Image image;
    public Text name_ko;
    public AtomInfo info;
    public int id;
    public Sprite sprite;

    public void setAtomInfo(AtomInfo info) {
        this.info = info;
        var sprite = Resources.Load<Sprite>(info.imagePath);
        this.sprite = sprite;
        name_ko.text = info.name_ko;
    }

    public void grabbed() {

    }

    public void ungrabbed() {

    }
}
