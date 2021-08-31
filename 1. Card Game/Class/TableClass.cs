using CardGame.Enum;
using CardGame.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.Class
{
    public partial class TableClass
    {
        private TableModel _table;
        private Game _game;
        private ComputerPlayerClass _computerPlayer;

        #region Constructor
        public TableClass(Game game)
        {
            _table = new TableModel();
            _game = game;
            _computerPlayer = new ComputerPlayerClass(game);

            CreateGame();
        }
        #endregion

        #region Private
        private void CreateGame()
        {
            _table.Deck = CreateNewDeck();
            _table.NewCardCount = 1;

            for (var i = 0; i < 8; i++)
            {
                if (i % 2 == 0) PutCardToPlayerHand();
                else PutCardToComputerHand();
            }

            PutFirstCardToPlayDeck();
        }

        private List<CardModel> CreateNewDeck()
        {
            var deck = new List<CardModel>();

            foreach (CardTypeEnum cardType in System.Enum.GetValues(typeof(CardTypeEnum)))
            {
                foreach (CardValueEnum cardValue in System.Enum.GetValues(typeof(CardValueEnum)))
                {
                    deck.Add(new CardModel { CardType = cardType, CardValue = cardValue, SpecialCardType = null });
                }
            }

            return deck.Shuffle();
        }

        private CardModel GetCardFromDeck()
        {
            if (_table.Deck.Count() == 0)
            {
                var lastCard = _table.GameDeck.Last();

                var newDeck = _table.GameDeck.Select(s => s).ToList();
                newDeck.Remove(lastCard);
                newDeck.Shuffle();

                _table.Deck = newDeck;

                _table.GameDeck.Clear();
                _table.GameDeck.Add(lastCard);
            }

            return _table.Deck.First();
        }

        private void PutFirstCardToPlayDeck()
        {
            var card = GetCardFromDeck();
            var clearCard = GetCardFromDeck();

            _table.GameDeck.Add(card);
            _table.Deck.Remove(clearCard);

            if (card.CardValue == CardValueEnum.Seven)
            {
                _table.NewCardCount = 2;
                _table.State = TableStateEnum.PlayerNeedsToTakeMoreCard;
            }
            else if (card.CardValue == CardValueEnum.Ace)
            {
                _table.State = TableStateEnum.PlayerStays;
                _game.StayButton.Visible = true;
            }
            else if (card.CardValue == CardValueEnum.Queen)
            {
                var cardTypes = System.Enum.GetValues(typeof(CardTypeEnum));
                Random random = new Random();
                CardTypeEnum randomType = (CardTypeEnum)cardTypes.GetValue(random.Next(cardTypes.Length));
                SetSpecialType(randomType, true);
            }
        }

        private void ToggleTypePictures(bool visible)
        {
            _game.TypePicC.Visible = visible;
            _game.TypePicH.Visible = visible;
            _game.TypePicS.Visible = visible;
            _game.TypePicD.Visible = visible;
        }
        #endregion

        public List<CardModel> GetPlayerHand() => _table.PlayerHand;

        public List<CardModel> GetComputerHand() => _table.ComputerHand;

        public List<CardModel> GetDeck() => _table.Deck;
        
        public void PutCardToPlayerHand()
        {
            if (_game.DescriptionTextBox.Text == "Computer: Stays") _game.DescriptionTextBox.Text = "";

            for (var i = 0; i < _table.NewCardCount; i++)
            {
                var card = GetCardFromDeck();

                _table.PlayerHand.Add(card);
                _table.Deck.Remove(card);
            }

            _table.NewCardCount = 1;
            _table.State = TableStateEnum.ComputerInNormalTurn;

            ShowCards(false);
        }

        public void PutCardToComputerHand()
        {
            if (_game.DescriptionTextBox.Text == "Computer: Stays") _game.DescriptionTextBox.Text = "";

            for (var i = 0; i < _table.NewCardCount; i++)
            {
                var card = GetCardFromDeck();

                _table.ComputerHand.Add(card);
                _table.Deck.Remove(card);
            }

            _table.NewCardCount = 1;
            _table.State = TableStateEnum.PlayerInNormalTurn;

            ShowCards(true);
        }

        public void PlayCard(CardModel card, bool isComputer = false)
        {
            _game.DescriptionTextBox.Text = string.Empty;

            if (isComputer)
            {
                _table.GameDeck.Add(card);
                _table.ComputerHand.Remove(card);
                RefreshGameDeckView();
                ShowCards(true);

                if (card.CardValue == CardValueEnum.Seven)
                {
                    _table.NewCardCount = (_table.NewCardCount == 1 ? 2 : _table.NewCardCount + 2);
                    _table.State = TableStateEnum.PlayerNeedsToTakeMoreCard;
                }
                else if (card.CardValue == CardValueEnum.Ace)
                {
                    _table.State = TableStateEnum.PlayerStays;
                    _game.StayButton.Visible = true;
                }
                else if (card.CardValue == CardValueEnum.Queen) _table.State = TableStateEnum.ComputerNeedsPickType;
                else _table.State = TableStateEnum.PlayerInNormalTurn;

                if (_table.ComputerHand.Count() == 0)
                {
                    MessageBox.Show("YOU LOOSE!");
                    Application.Exit();
                }
            }
            else
            {
                _table.GameDeck.Add(card);
                _table.PlayerHand.Remove(card);
                RefreshGameDeckView();
                ShowCards();
                if (card.CardValue == CardValueEnum.Seven)
                {
                    _table.NewCardCount = (_table.NewCardCount == 1 ? 2 : _table.NewCardCount + 2);
                    _table.State = TableStateEnum.ComputerNeedsToTakeMoreCard;
                }
                else if (card.CardValue == CardValueEnum.Ace) _table.State = TableStateEnum.ComputerStays;
                else if (card.CardValue == CardValueEnum.Queen) _table.State = TableStateEnum.PlayerNeedsPickType;
                else _table.State = TableStateEnum.ComputerInNormalTurn;

                if (_table.PlayerHand.Count() == 0)
                {
                    MessageBox.Show("YOU WON!");
                    Application.Exit();
                }

                _game.StayButton.Visible = false;

                if (_table.State == TableStateEnum.PlayerNeedsPickType)
                {
                    ToggleTypePictures(true);
                }
                else
                {
                    _computerPlayer.Play();
                }
            }
        }

        public void ShowCards(bool isComputer = false)
        {       
            var img = new ImageList();
            img.ImageSize = new Size(52, 70);

            if (isComputer)
            {
                _game.ComputerHandView.Items.Clear();
#if DEBUG
                _table.ComputerHand.ForEach(card =>
                {
                    img.Images.Add(Image.FromFile("Img/" + card.CardType.GetFileNamePart() + card.CardValue.GetFileNamePart() + ".png"));
                });

                _game.ComputerHandView.LargeImageList = img;

                for (var i = 0; i < _table.ComputerHand.Count(); i++)
                {
                    _game.ComputerHandView.Items.Add("", i);
                };
#else
                img.Images.Add(Image.FromFile("Img/card.jpg"));

                _game.ComputerHandView.LargeImageList = img;

                _table.ComputerHand.ForEach(card =>
                {
                    _game.ComputerHandView.Items.Add("", 0);
                });
#endif
            }
            else
            {
                _game.PlayerHandView.Items.Clear();
                _table.PlayerHand.ForEach(card =>
                {
                    img.Images.Add(Image.FromFile("Img/" + card.CardType.GetFileNamePart() + card.CardValue.GetFileNamePart() + ".png"));
                });

                _game.PlayerHandView.LargeImageList = img;

                for (var i = 0; i < _table.PlayerHand.Count(); i++)
                {
                    _game.PlayerHandView.Items.Add("", i);
                };
            }
        }

        public void RefreshGameDeckView()
        {
            // clear view first
            _game.GameDeckView.Items.Clear();

            var img = new ImageList();
            img.ImageSize = new Size(52, 70);
            img.Images.Add(Image.FromFile("Img/" + _table.GameDeck.Last().CardType.GetFileNamePart() + _table.GameDeck.Last().CardValue.GetFileNamePart() + ".png"));
            _game.GameDeckView.LargeImageList = img;

            _game.GameDeckView.Items.Add("", 0);

        }

        public bool IsCardPlayable(CardModel newCard)
        {
            var actualCard = _table.GameDeck.Last();
            return IsCardPlayable(newCard, actualCard);
        }

        public bool IsCardPlayable(CardModel newCard, CardModel actualCard)
        {
            var state = _table.State;
            return IsCardPlayable(newCard, actualCard, state);
        }

        public bool IsCardPlayable(CardModel newCard, CardModel actualCard, TableStateEnum state)
        {
            return (
                // Normal turn + queen
                ((actualCard.CardValue == newCard.CardValue || actualCard.CardType == newCard.CardType || newCard.CardValue == CardValueEnum.Queen)
                && (state == TableStateEnum.PlayerInNormalTurn || state == TableStateEnum.ComputerInNormalTurn) && (_table.GameDeck.Last().SpecialCardType == null)) ||
                // Stay turn
                (newCard.CardValue == CardValueEnum.Ace && (state == TableStateEnum.PlayerStays || state == TableStateEnum.ComputerStays)) ||
                // Take more turn
                (newCard.CardValue == CardValueEnum.Seven && (state == TableStateEnum.PlayerNeedsToTakeMoreCard || state == TableStateEnum.ComputerNeedsToTakeMoreCard)) ||
                // Different color
                ((actualCard.SpecialCardType == newCard.CardType || newCard.CardValue == CardValueEnum.Queen) && (state == TableStateEnum.PlayerInNormalTurn || state == TableStateEnum.ComputerInNormalTurn))
            );
        }

        public bool IsPlayerTurn()
        {
            return _table.State == TableStateEnum.PlayerInNormalTurn || _table.State == TableStateEnum.PlayerNeedsPickType || _table.State == TableStateEnum.PlayerNeedsToTakeMoreCard || _table.State == TableStateEnum.PlayerStays;
        }

        public TableStateEnum GetState()
        {
            return _table.State;
        }

        public void ComputerPlay()
        {
            _computerPlayer.Play();
        }

        public void ActionStay(bool isComputer = false)
        {
            if (isComputer)
            {
                _table.State = TableStateEnum.PlayerInNormalTurn;
                _game.DescriptionTextBox.Text = "Computer: Stays";
            }
            else
            {
                _table.State = TableStateEnum.ComputerInNormalTurn;
                _game.StayButton.Visible = false;
                _computerPlayer.Play();
            }
        }

        public CardModel GetGameDeckCard()
        {
            return _table.GameDeck.Last();
        }

        public void SetSpecialType(CardTypeEnum specialType, bool isComputer = false)
        {
            _table.GameDeck.Last().SpecialCardType = specialType;

            if (isComputer)
            {
                _table.State = TableStateEnum.PlayerInNormalTurn;
            }
            else
            {
                _table.State = TableStateEnum.ComputerInNormalTurn;
                ToggleTypePictures(false);
            }

            _game.DescriptionTextBox.Text = "New type: "  + specialType.ToString();

            if (!isComputer) _computerPlayer.Play();
        }
    }
}
