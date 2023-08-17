using Newtonsoft.Json;

namespace _7._8.Items
{
    internal class Repository
    {
        private List<Worker> _workers;
        private string _path;

        public Repository(string path)
        {
            _path = path;

            var json = File.ReadAllText(_path);
            _workers = JsonConvert.DeserializeObject<List<Worker>>(json);                   
        }

        public List<Worker> GetAllWorkers()
            => _workers;

        public Worker GetWorkerByID(int id)
            => _workers.FirstOrDefault(worker => worker.ID == id);

        public Worker GetWorkerByName(string name)
            => _workers.FirstOrDefault(worker => worker.FullName == name);

        public void AddWorker()
        {
            Console.Write("Enter id: ");
            var id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter full name: ");
            var fullName = Console.ReadLine();          

            Console.Write("Enter date of birth: ");
            var input = Console.ReadLine();

            if (DateOnly.TryParse(input, out DateOnly parsedDate))
            {
                _workers.Add(new Worker(id, fullName, parsedDate));
                ParseWorkersToFile();
            }
            else
            {
                Console.WriteLine("Incorrect format");
            }       
        }

        public void DeleteWorker()
        {
            Console.Write("Enter worker id to delete: ");
            var id = int.Parse(Console.ReadLine());

            var employeeToDelete = _workers.FirstOrDefault(worker => worker.ID == id);
            _workers?.Remove(employeeToDelete);
            ParseWorkersToFile();
        }

        public List<Worker> GetWorkersInDateRange()
        {
            Console.Write("Enter start date: ");
            var startDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter end date: ");
            var endDate = DateOnly.Parse(Console.ReadLine());

            return _workers.Where(w => w.DateOfBirth >= startDate && w.DateOfBirth <= endDate).ToList();
        }        

        public void WriteWorkers(List<Worker> workers)
        {
            foreach(var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }

        private void ParseWorkersToFile()
        {
            var data = JsonConvert.SerializeObject(_workers);
            File.WriteAllText(_path, data);
        }
    }
}
