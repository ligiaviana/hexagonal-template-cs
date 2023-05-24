using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class LogCore : ILogCore
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
