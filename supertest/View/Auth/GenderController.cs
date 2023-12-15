using supertest.modelx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supertest
{
    public class GenderController
    {
        Connection connection = new Connection();

        public List<Genders> GetGenders()
        {
            try
            {
                var genders = connection.auth.Genders.ToList();
                return genders;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }



        }
    }
}
