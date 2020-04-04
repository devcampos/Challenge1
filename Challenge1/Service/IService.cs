using Challenge1.Entities;
using System.Collections.Generic;

namespace Challenge1.Service
{
    public interface IService
    {
        List<string> Process(int cores, string task1, string task2);
        List<TaskProcess> GetMatch(string s);
        void PrintCorrectlyMatch();
    }
}
