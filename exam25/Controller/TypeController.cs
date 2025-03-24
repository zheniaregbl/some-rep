using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam25
{
    public class TypeController
    {
        private readonly DBHelper _dbHelper;

        public TypeController()
        {
            _dbHelper = new DBHelper();
        }

        public List<ContractorType> GetTypes()
        {
            var types = new List<ContractorType>();

            var query = "select * from contractor_type";

            using (var command = new NpgsqlCommand(query, _dbHelper.GetConnection()))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(
                            new ContractorType(
                                id: reader.GetInt32(0),
                                name: reader.GetString(1)
                            )
                        );
                    }
                }
            }

            return types;
        }
    }
}
