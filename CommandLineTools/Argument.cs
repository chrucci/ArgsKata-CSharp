namespace CommandLineTools
{
    public class Argument
    {
        private readonly char _argFlag;
        private bool _isValid;

        public Argument(char argFlag)
        {
            _argFlag = argFlag;
        }

        public bool IsValid()
        {
            return _isValid;
        }

        public void Register()
        {
            _isValid = true;
        }
    }
}