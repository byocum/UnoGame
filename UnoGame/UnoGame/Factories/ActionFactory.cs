using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.PlayerActions;
using UnoGame.Players;

namespace UnoGame.Factories
{
    public class ActionFactory
    {
        private readonly Deck drawDeck;
        private readonly Deck discardDeck;
        private readonly Turn turn;

        public ActionFactory(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            this.drawDeck = drawDeck;
            this.discardDeck = discardDeck;
            this.turn = turn;
        }

        public PlayerAction ConfrontUno(Player playerPicked)
        {
            PlayerAction penaltyDraw = PenaltyDraw(playerPicked);
            PlayerAction confrontUno = new ConfrontUno(turn, penaltyDraw, playerPicked);

            return confrontUno;
        }

        public PlayerAction PenaltyDraw(Player playerDrawingCard)
        {
            PlayerAction penaltyDraw = new PenaltyDraw(drawDeck, playerDrawingCard);

            return penaltyDraw;
        }

        public PlayerAction Deal()
        {
            PlayerAction deal = new Deal(drawDeck, discardDeck, turn);

            return deal;
        }

        public PlayerAction DeterminePlayers()
        {
            PlayerAction determinePlayers = new DeterminePlayers(turn, discardDeck);

            return determinePlayers;
        }

        public PlayerAction DiscardDeckAddFirstCard()
        {
            PlayerAction discardDeckAddFirstCard = new DiscardDeckAddFirstCard(drawDeck, discardDeck);

            return discardDeckAddFirstCard;
        }

        public PlayerAction Draw()
        {
            PlayerAction draw = new Draw(drawDeck, discardDeck, turn);

            return draw;
        }

        public PlayerAction NoAction()
        {
            PlayerAction noAction = new NoAction();

            return noAction;
        }

        public PlayerAction Pause()
        {
            PlayerAction pause = new Pause();

            return pause;
        }

        public PlayerAction PlayCard(int cardToPlayIndex)
        {
            PlayerAction playCard = new PlayerPlayingCard(cardToPlayIndex, discardDeck, turn);

            return playCard;
        }

        public PlayerAction Rules()
        {
            PlayerAction pause = Pause();
            PlayerAction rules = new Rules(pause);

            return rules;
        }

        public PlayerAction SayUno()
        {
            PlayerAction sayUno = new SayUno(turn);

            return sayUno;
        }      
    }
}
