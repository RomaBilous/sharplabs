namespace Pr4;

public delegate void PlayerCreator();
public class GameLogic
{
    private Player _player1;
    private Player _player2;
    private Player _originalValuesP1;
    private Player _originalValuesP2;
    private int _playerTurn;
    private bool _gameContinuation;
    private bool _assignNewValues;


    public static event PlayerCreator OnPlayerInitialization;
    
    public GameLogic()
    {
        _gameContinuation = true;
        _assignNewValues = true;
        _playerTurn = 1;
    }

    public void StartPvPGame()
    {
        _player1 = new Mage();
        _player2 = new Mage();
        do
        {
            
            if (_assignNewValues)
            {
                InitializePlayersCreation();
            }

            SetOriginalValues();
            
            ShowPlayersStats();
            
            do
            {
                bool correctInput;
                int spellID = 0;
                
                Player currentPlayer = GetCurrentPlayer();
                Player nextPlayer = GetNextPlayer();
                
                Console.WriteLine(_playerTurn % 2 == 0 ? "Player2's turn" : "Player1's turn");
                Console.WriteLine("Type 'slist' to see list of your spells");
                
                do
                {
                    Console.WriteLine("Action: ");
                    correctInput = ActionVerifier(currentPlayer, ref spellID);


                } while (!correctInput);
                
                currentPlayer.CastSpell(spellID, ((Mage)currentPlayer).Spells[spellID] 
                    is AttackingSpell ? nextPlayer : currentPlayer);

                

                ++_playerTurn;

               CheckForWinner();
            
            } while (_player1.Hp>0 && _player2.Hp>0);
            
            InitializeEndGameSequence();

        } while (_gameContinuation);
    }

    public void StartPvAIGame(){}


    private void InitializePlayersCreation()
    {
        OnPlayerInitialization();
    }

    private void ShowPlayersStats()
    {
        Console.WriteLine("----------------Player1 stats----------------");
        ((Mage)_player1).ShowInfo();
        Console.WriteLine("Spells list:");
        ((Mage)_player1).PrintSpellsList();
        Console.WriteLine("----------------Player2 stats----------------");
        ((Mage)_player2).ShowInfo();
        Console.WriteLine("Spells list:");
        ((Mage)_player2).PrintSpellsList();
    }

    private void SetOriginalValues()
    {
        _originalValuesP1 = new Mage(_player1.Name, _player1.Surname, _player1.Hp, ((Mage)_player1).Magic,
            ((Mage)_player1).Spells, ((Mage)_player1).MagicLevel);
        _originalValuesP2 = new Mage(_player2.Name, _player1.Surname, _player2.Hp, ((Mage)_player2).Magic,
            ((Mage)_player2).Spells, ((Mage)_player2).MagicLevel);
    }
    
    private Player GetCurrentPlayer()
    {
        return _playerTurn%2 == 0 ? _player2 : _player1;
    }

    private  Player GetNextPlayer()
    {
        return _playerTurn%2 == 0 ? _player1 : _player2;
    }

    private bool ActionVerifier(Player currentPlayer, ref int spellID)
    {
        string playerInput = Console.ReadLine();

        if (int.TryParse(playerInput, out spellID))
        {

            if (spellID <= ((Mage)currentPlayer).Spells.Count -1 && spellID >=0)
            {
                return true;
            }
            Console.WriteLine("SpellID is out of spells range");
        }
        else if (playerInput.ToLower() == "slist")
        {
            Console.WriteLine("Spells list: ");
            ((Mage)currentPlayer).PrintSpellsList();
        }
        else
        {
            Console.WriteLine("Incorrect value!");
        }

        return false;
    }
    

    private void CheckForWinner()
    {
        if (_player1.Hp == 0 )
        {
            Console.WriteLine("\nPlayer2 win!");
        }
        else if (_player2.Hp == 0 )
        {
            Console.WriteLine("\nPlayer1 win!");
        }
    }

    private void InitializeEndGameSequence()
    {
        Console.WriteLine("Would you like to play again?(y/n)");
        string choice = Console.ReadLine();
        if (IntentionToPlayAgain(choice))
        {
            Console.WriteLine("Would you like to keep mages' stats same?(y/n)");
            string inputToChange = Console.ReadLine();
            if (IntentionToChangeStats(inputToChange))
            {
                _player1 = _originalValuesP1;
                _player2 = _originalValuesP2;
                _assignNewValues = false;
            }
        }
        Console.Clear();
    }

    private bool IntentionToPlayAgain(string choice)
    {
        if (choice.ToLower() == "yes" || choice.ToLower() == "y")
        {
            return true;
        }
        _gameContinuation = false;
        return false;
    }

    private bool IntentionToChangeStats(string choice)
    {
        if (choice.ToLower() == "yes" || choice.ToLower() == "y")
        {
            return true;
        }

        _assignNewValues = true;
        return false;
    }
    

}