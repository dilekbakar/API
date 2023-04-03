using API.Models;
using Bogus;

namespace API.Fake
{
    public class FakeData
    {
        private static List<Data> _datas;
        public static List<Data> GetDatas(int number)
        {
            if (_datas == null)
            {
                _datas = new Faker<Data>()
               .RuleFor(d => d.ID, f => f.IndexFaker + 1)
               .RuleFor(d => d.Title, f => f.Name.FirstName())
               .RuleFor(d => d.Description, f => f.Lorem.Sentence())
               .Generate(number);
            }

            return _datas;
        }
    }
}

