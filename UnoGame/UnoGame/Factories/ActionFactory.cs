using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.GameActions;
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

        public GameAction ConfrontUno(Player playerPicked)
        {
            GameAction penaltyDraw = PenaltyDraw(playerPicked);
            GameAction confrontUno = new ConfrontUno(turn, penaltyDraw, playerPicked);

            return confrontUno;
        }

        public GameAction PenaltyDraw(Player playerDrawingCard)
        {
            GameAction penaltyDraw = new PenaltyDraw(drawDeck, playerDrawingCard);

            return penaltyDraw;
        }

        public GameAction Deal()
        {
            GameAction deal = new Deal(drawDeck, discardDeck, turn);

            return deal;
        }

        public GameAction DeterminePlayers()
        {
            GameAction determinePlayers = new DeterminePlayers(turn, discardDeck);

            return determinePlayers;
        }

        public GameAction DiscardDeckAddFirstCard()
        {
            GameAction pause = new Pause();
            GameAction discardDeckAddFirstCard = new DiscardDeckAddFirstCard(drawDeck, discardDeck, turn,  pause);

            return discardDeckAddFirstCard;
        }

        public GameAction Draw()
        {
            GameAction draw = new Draw(drawDeck, discardDeck, turn);

            return draw;
        }

        public GameAction NoAction()
        {
            GameAction noAction = new NoAction();

            return noAction;
        }

        public GameAction Pause()
        {
            GameAction pause = new Pause();

            return pause;
        }

        public GameAction PlayCard(int cardToPlayIndex)
        {
            GameAction playCard = new PlayerPlayingCard(cardToPlayIndex, discardDeck, turn);

            return playCard;
        }

        public GameAction Rules()
        {
            GameAction pause = Pause();
            GameAction rules = new Rules(pause);

            return rules;
        }

        public GameAction SayUno()
        {
            GameAction sayUno = new SayUno(turn);

            return sayUno;
        } 
        
        public GameAction Sort()
        {
            GameAction sortHand = new SortHand(turn);

            return sortHand;
        }

        public GameAction Hands()
        {
            GameAction hands = new NumCardsInHands(turn);

            return hands;
        }
    }
}
