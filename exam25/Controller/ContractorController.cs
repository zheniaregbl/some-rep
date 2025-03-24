using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam25
{
    public class ContractorController
    {
        private readonly DBHelper _dbHelper;

        public ContractorController()
        {
            _dbHelper = new DBHelper();
        }

        public List<Contractor> GetAllContractor()
        {
            var contractors = new List<Contractor>();

            var query = "select con.id, con.name, con.address, con.inn, con.contact_person, con.phone, con.email, con.rating, round(avg(sh.quality)::numeric, 1), round((avg(sh.timeliness) / 100)::numeric, 2) from contractor con\n" +
                "inner join service_history sh on sh.contractor = con.id\n" +
                "group by con.id;";

            using (var command = new NpgsqlCommand(query, _dbHelper.GetConnection()))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contractor = new Contractor(
                            id: reader.GetInt32(0),
                            type: null,
                            name: reader.GetString(1),
                            address: reader.GetString(2),
                            inn: reader.GetString(3),
                            person: reader.GetString(4),
                            phone: reader.GetString(5),
                            email: reader.GetString(6),
                            rating: reader.GetInt32(7),
                            safety: CalculateSafety(reader.GetFloat(8), reader.GetFloat(9))
                        );

                        contractors.Add(contractor);
                    }
                }
            }

            return contractors;
        }

        public string CalculateSafety(float quality, float timeliness)
        {
            var safety = (quality * 0.6) + (timeliness * 0.4);

            if (safety >= 4.5) return "Высокая надежность";
            else if (safety >= 3.5 && safety < 4.5) return "Средняя надежность";
            else return "Низкая надежность";
        }
    }
}
