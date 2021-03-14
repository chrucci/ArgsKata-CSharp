namespace CommandLineTools
{
    public interface IRunner
    {
        public void RunApplication(bool logging, string category, int port);
    }
}