//ID
//Дата и время добавления записи
//Ф.И.О.
//Возраст
//Рост
//Дата рождения
//Место рождения

namespace _7._8.Items
{
    internal struct Worker
    {
        private int _id;
        private string _fullName;
        private DateOnly _dateOfBirth;

        public int ID => _id;
        public string FullName => _fullName;
        public DateOnly DateOfBirth => _dateOfBirth;

        public Worker(int id, string fullName, DateOnly dateOfBirth)
        {
            _id = id;
            _fullName = fullName;
            _dateOfBirth = dateOfBirth;
        }
    }
}
