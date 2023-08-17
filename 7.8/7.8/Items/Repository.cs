namespace _7._8.Items
{
    internal class Repository
    {
        private List<Worker> _workers = new List<Worker>();
        private string _path;

        public Repository(List<Worker> workers, string path)
        {
            _workers = workers;
            _path = path;
        }

        public List<Worker> GetAllWorkers()
            => _workers;

        public Worker GetWorker(int id)
            => _workers.FirstOrDefault(worker => worker.ID == id);

        public Worker GetWorker(string name)
            => _workers.FirstOrDefault(worker => worker.FullName == name);

        public void AddWorker(Worker worker)
            => _workers.Add(worker);

        public void DeleteEmployee(int id)
        {
            var employeeToDelete = _workers.FirstOrDefault(worker => worker.ID == id);
            _workers?.Remove(employeeToDelete);
        }

        public List<Worker> GetWorkersInDateRange(DateOnly startDate, DateOnly endDate)
            => _workers.Where(w => w.DateOfBirth >= startDate && w.DateOfBirth <= endDate).ToList();


    }
}
