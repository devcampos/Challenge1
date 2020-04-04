using Challenge1.Service;
using System;

namespace Challenge1
{
    public class DI
    {
        private IService _service;
        public DI(IService service)
        {
            _service = service;
        }

        public string Run(int cores, string task1, string task2)
        {
            var result = _service.Process(cores, task1, task2);
            return String.Join(",", result);
        }

    }
}
