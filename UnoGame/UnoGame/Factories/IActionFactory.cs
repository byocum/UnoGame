using UnoGame.Decks;

namespace UnoGame.Factories
{
    public interface IActionFactory
    {
        public GameActions.GameAction createPlayCardAction(Deck deckToPlayFrom);
    }

}
