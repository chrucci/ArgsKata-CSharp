namespace CommandLineTools
{
    public class BooleanArgument
    {
        private readonly char _argFlag;
        private bool _isRegistered;
        public bool Value { get; set; }
        private readonly bool _isMandatory;

        public BooleanArgument(char argFlag, bool isMandatory = false)
        {
            _argFlag = argFlag;
            _isMandatory = isMandatory;
            Value = true;
        }

        public bool IsValid()
        {
            if (_isMandatory && !_isRegistered)
                throw new InvalidArgumentException(_argFlag);
            return true;
        }

        public void Register()
        {
            _isRegistered = true;
        }
    }
}