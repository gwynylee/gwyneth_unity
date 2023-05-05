using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : BasePlayer
{
    public bool ThinkHit()
    {
        var point = CalcPoint();
        return 0 < point && point < 16;
    }

    public bool ThinkStand()
    {
        return !ThinkHit();
    }

    public void CardOpen()
    {
        _drawnCardObjs[0].sprite = Game.Instance.Sprites[_hand[0]];
    }

    public override void ReceiveCard(int card)
    {
        base.ReceiveCard(card);

        var game = Game.Instance;
        var cardObj = Instantiate(game.CardPrefab);
        if (_drawnCardObjs.Count == 0)
        {
            cardObj.GetComponent<SpriteRenderer>().sprite = game.BackSprite;
        }
        else
        {
            cardObj.GetComponent<SpriteRenderer>().sprite = game.Sprites[card];
        }

        cardObj.GetComponent<SpriteRenderer>().sortingOrder = _drawnCardObjs.Count;
        _drawnCardObjs.Add(cardObj);

        var interval = 5f / (_drawnCardObjs.Count + 1);
        var xPos = -2.5f;
        foreach (var drawnCardObj in _drawnCardObjs)
        {
            xPos += interval;
            drawnCardObj.transform.localPosition = new Vector3(xPos, 1.5f, 0);
        }
    }
}
