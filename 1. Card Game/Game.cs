using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGame.Enum;
using CardGame.Class;
using CardGame.Model;
using System.Runtime.InteropServices;

namespace CardGame
{
    public partial class Game : Form
    {
        public TableClass Table;
        const uint LVM_SETICONSPACING = 0x1035;

        [DllImport("user32")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public Game()
        {
            InitializeComponent();

            Table = new TableClass(this);

            PlayerHandView.View = View.LargeIcon;
            ComputerHandView.View = View.LargeIcon;

            #region Card spacing
            SendMessage(PlayerHandView.Handle, LVM_SETICONSPACING, IntPtr.Zero, new IntPtr((62 << 20) | 60));
            SendMessage(ComputerHandView.Handle, LVM_SETICONSPACING, IntPtr.Zero, new IntPtr((62 << 20) | 60));
            #endregion

            Table.ShowCards();
            Table.ShowCards(true);
            Table.RefreshGameDeckView();
            
        }

        private void PlayerHandView_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Table.IsPlayerTurn()) return;

            var hand = Table.GetPlayerHand();
            var card = hand[PlayerHandView.SelectedItems[0].Index];
            if (Table.IsCardPlayable(card))
            {
                Table.PlayCard(card);
                Table.RefreshGameDeckView();
                Table.ShowCards();
            }
            else
            {
                MessageBox.Show("Invalid card for this turn.", "Wrong turn");
            }

        }

        private void DeckImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Table.IsPlayerTurn() || Table.GetState() == TableStateEnum.PlayerStays) return;

            Table.PutCardToPlayerHand();
            Table.ComputerPlay();
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            Table.ActionStay();
        }

        private void TypePicH_Click(object sender, EventArgs e)
        {
            Table.SetSpecialType(CardTypeEnum.Hearts);
        }

        private void TypePicD_Click(object sender, EventArgs e)
        {
            Table.SetSpecialType(CardTypeEnum.Diamonds);
        }

        private void TypePicS_Click(object sender, EventArgs e)
        {
            Table.SetSpecialType(CardTypeEnum.Spades);
        }

        private void TypePicC_Click(object sender, EventArgs e)
        {
            Table.SetSpecialType(CardTypeEnum.Clubs);
        }
    }
}
