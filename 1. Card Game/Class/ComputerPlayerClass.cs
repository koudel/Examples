using CardGame.Enum;
using CardGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Class
{
    public class ComputerPlayerClass
    {
        private Game _game;
        public ComputerPlayerClass(Game game)
        {
            _game = game;
        }

        public void Play()
        {
            var card = FindPlayableCard();
            
            if (card == null)
            {
                if (_game.Table.GetState() == TableStateEnum.ComputerInNormalTurn || _game.Table.GetState() == TableStateEnum.ComputerNeedsToTakeMoreCard)
                {
                    _game.Table.PutCardToComputerHand();
                    return;
                }
                else if (_game.Table.GetState() == TableStateEnum.ComputerStays)
                {
                    _game.Table.ActionStay(true);
                    return;
                }
            }

            _game.Table.PlayCard(card, true);
            _game.Table.RefreshGameDeckView();
            _game.Table.ShowCards(true);

            if (_game.Table.GetState() == TableStateEnum.ComputerNeedsPickType)
            {
                var preferableCards = new List<CardModel>();
                foreach (CardTypeEnum cardType in System.Enum.GetValues(typeof(CardTypeEnum)))
                {
                    var copyCard = FindPlayableCard(_game.Table.GetComputerHand(), new CardModel { CardValue = CardValueEnum.Queen, CardType = cardType }, TableStateEnum.ComputerInNormalTurn);

                    if (copyCard == null) continue;

                    if (copyCard.CardValue == CardValueEnum.Ace || copyCard.CardValue == CardValueEnum.Seven)
                    {
                        preferableCards.Add(copyCard);
                    }
                }

                if (preferableCards.Count > 0)
                {
                    var random = new Random();
                    _game.Table.SetSpecialType(preferableCards[random.Next(preferableCards.Count)].CardType, true);
                }
                else if (_game.Table.GetComputerHand().Count > 0)
                {
                    var random = new Random();
                    _game.Table.SetSpecialType(_game.Table.GetComputerHand()[random.Next(_game.Table.GetComputerHand().Count)].CardType, true);
                }
            }
        }

        private CardModel FindPlayableCard(List<CardModel> pHand = null, CardModel pCard = null, TableStateEnum? pState = null)
        {
            var hand = pHand == null ? _game.Table.GetComputerHand() : pHand;
            var gameCard = pCard == null ? _game.Table.GetGameDeckCard() : pCard;
            var tableState = pState == null ? _game.Table.GetState() : pState.Value;

            var playableCards = new List<CardModel>();
            var playablePreferedCards = new List<CardModel>();

            int indexOfBestComb = new int();
            int indexOfBestPrefComb = new int();
            int numberOfBestComb = 0;
            int numberOfBestPrefComb = 0;

            hand.ForEach(card => {
                if (_game.Table.IsCardPlayable(card, gameCard, tableState)) playableCards.Add(card);
                if (_game.Table.IsCardPlayable(card, gameCard, tableState) && (card.CardValue == CardValueEnum.Ace || card.CardValue == CardValueEnum.Seven)) playablePreferedCards.Add(card);
            });

            if (playableCards.Count == 0) return null;
            if (playablePreferedCards.Count == 0)
            {
                playableCards.ForEach(card => {
                    var updatedPlayableCards = playableCards.Select(s => s).ToList();
                    updatedPlayableCards.Remove(card);

                    var updatedCard = card;
                    var updatedState = tableState;

                    var counter = 0;
                    while (updatedPlayableCards.Count > 0)
                    {
                        var newPlayableCard = FindPlayableCard(updatedPlayableCards, updatedCard, updatedState);

                        if (newPlayableCard == null) break;

                        counter++;

                        updatedPlayableCards.Remove(newPlayableCard);
                        updatedCard = newPlayableCard;

                        if (updatedCard.CardValue == CardValueEnum.Ace || updatedCard.CardValue == CardValueEnum.Seven)
                            updatedState = TableStateEnum.ComputerInNormalTurn;
                    }

                    if (counter > numberOfBestComb)
                    {
                        numberOfBestComb = counter;
                        indexOfBestComb = playableCards.IndexOf(card);
                    }
                });

                return playableCards[indexOfBestComb];
            }
            else
            {
                playablePreferedCards.ForEach(card => {
                    var updatedPlayableCards = playablePreferedCards.Select(s => s).ToList();
                    updatedPlayableCards.Remove(card);

                    var updatedCard = card;
                    var updatedState = tableState;

                    var counter = 0;
                    while (updatedPlayableCards.Count > 0)
                    {
                        var newPlayableCard = FindPlayableCard(updatedPlayableCards, updatedCard, updatedState);

                        if (newPlayableCard == null) break;

                        counter++;

                        updatedPlayableCards.Remove(newPlayableCard);
                        updatedCard = newPlayableCard;

                        if (updatedCard.CardValue == CardValueEnum.Ace || updatedCard.CardValue == CardValueEnum.Seven)
                            updatedState = TableStateEnum.ComputerInNormalTurn;
                    }

                    if (counter > numberOfBestPrefComb)
                    {
                        numberOfBestPrefComb = counter;
                        indexOfBestPrefComb = playablePreferedCards.IndexOf(card);
                    }
                });

                return playablePreferedCards[indexOfBestPrefComb];
            }
        }
    }
}
