using Rich.Base.Runtime.Abstract.View;
using TMPro;
using UnityEngine;

public class ScoreTableView : RichView
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private TextMeshPro firedBulletHolderText;

    #endregion

    #region Private Variables

    private int _bulletCount;

    #endregion

    #endregion

    public void BulletFired(int firedBulletCount)
    {
        _bulletCount += firedBulletCount;
        firedBulletHolderText.text = "Fired Bullet Count: " + _bulletCount;
    }
}