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

            var query = "select con.id, ct.id, ct.name, con.name, con.address, con.inn, con.contact_person, con.phone, con.email, con.rating, COALESCE(round(avg(sh.quality)::numeric, 1), 0), COALESCE(round((avg(sh.timeliness) / 100)::numeric, 2), 0) from contractor con\n" +
                "left join service_history sh on sh.contractor = con.id\n" +
                "left join contractor_type ct on ct.id = con.type\n" +
                "group by con.id, ct.id, ct.name, con.name, con.address, con.inn, con.contact_person, con.phone, con.email, con.rating;";

            using (var command = new NpgsqlCommand(query, _dbHelper.GetConnection()))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contractor = new Contractor(
                            id: reader.GetInt32(0),
                            type: new ContractorType(
                                id: reader.GetInt32(1),
                                name: reader.GetString(2)
                            ),
                            name: reader.GetString(3),
                            address: reader.GetString(4),
                            inn: reader.GetString(5),
                            person: reader.GetString(6),
                            phone: reader.GetString(7),
                            email: reader.GetString(8),
                            rating: reader.GetInt32(9),
                            safety: CalculateSafety(reader.GetFloat(10), reader.GetFloat(11))
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
