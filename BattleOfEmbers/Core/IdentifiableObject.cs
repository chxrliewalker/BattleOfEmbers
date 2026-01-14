namespace BattleOfEmbers.Core
{

    public class IdentifiableObject
    {
        private List<string> _identifiers = new();

        public IdentifiableObject(string[] idents)
        {
            foreach (string id in idents)
            {
                string stringId = id.ToString().ToLower().Trim();
                _identifiers.Add(stringId); // adding all identifiers when they are in lowercase
            }
        }

        public bool AreYou(string inputId)
        {
            return _identifiers.Contains(inputId.ToLower().Trim()); // system method (.Contains) to find if _identifiers contains the inputId
        }

        public string FirstId
        {
            get { return _identifiers.Count > 0 ? _identifiers[0] : ""; } // if/else statement:: condition ? return this if true : return this if else else// ternary operator
        }

        public string AddIdentifier(string id)
        {
            string stringId = id.ToString().Trim().ToLower();
            _identifiers.Add(stringId);
            return $"Correctly added {stringId} to your identifiers";
        }

        public string RemoveIdentifier(string inputId)
        {
            try
            {
                string stringId = inputId.ToString().ToLower();
                foreach (string id in _identifiers)
                {
                    if (id == stringId)
                    {
                        _identifiers.Remove(id);
                        return "Successful Removal!";
                    }
                }
                return $"No ID ({inputId}) in _identifiers. \nPlease check spelling and try again";
            }
            catch (Exception ex)
            {
                return $"Internal Error. \n Error Message: {ex}";
            }
        }
    }
}