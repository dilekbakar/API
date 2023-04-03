using API.Fake;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private List<Data> _datas = FakeData.GetDatas(100);


        [HttpGet]
        public List<Data> Get()
        {
            return _datas;
        }


        [HttpGet("{id}")]
        public object GetById(int id, string token)
        {
            if (token is not null)
            {
                if (token == "dilek")
                {
                    var data = _datas.FirstOrDefault(x => x.ID == id);
                    return Ok(data);
                }
            }

            return BadRequest();
        }

        [HttpGet("GetToken")]
        public IActionResult GetToken(string ad, string soyad)
        {
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                return BadRequest();
            }
            return Ok(new { token = ad + soyad });
        }


        [HttpPost]
        public object Post([FromBody] Data data)
        {
            if (data.ID == 1)
            {
                var token = new { token = "dilek" };

                return Ok(token);
            }
            else
            {
                var token = new { token = "" };
                return token;
            }

        }
        [HttpPut]
        public Data Put([FromBody] Data data)
        {
            var _editedData = _datas.FirstOrDefault(x => x.ID == data.ID);
            _editedData.Title = data.Title;
            _editedData.Description = data.Description;

            return data;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _datas.FirstOrDefault(x => x.ID == id);
            _datas.Remove(deletedUser);
        }


    }

}
