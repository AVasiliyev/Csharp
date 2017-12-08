using System;
using System.Linq;
using EfCore.Extensions;
using EfCore.Nc_Pay;

namespace EfCore
{
    internal class Program
    {
        private static void Main()
        {
            //using (var db = new NcPayContext())
            //{
            //    foreach (var charge in db.Charges)
            //    {
            //        charge.PrintProperties();
            //        // Console.WriteLine(Environment.NewLine);
            //    }
            //}

            using (var db = new NcPayContext())
            {
                // Console.WriteLine(db.Charges.First(x=>x.ChargeMetadata.Count > 0)./*.ChargeMetadata.Count*/);
                var charge = db.Charges.Join(db.ChargeLogs, 
                    c => c.Id,
                    l => l.ChargeId, 
                    (c, l) => new
                    {
                       cId = c.Id,
                       clId = l.Id
                    });

                var res = charge.Where(x => x.cId == Guid.Parse("CEF5C552-FDA8-E711-8DBE-0026833543A0"));
                foreach (var re in res)
                    re.PrintProperties();

                // var chargeLogs = db.ChargeLogs.Where(x => x.ChargeId == Guid.Parse("CEF5C552-FDA8-E711-8DBE-0026833543A0")).ToArray();

                //charge.PrintProperties();

                //foreach (var val in chargeLogs)
                //    val.PrintProperties();

                //foreach (var val in charge.ChargeLogs)
                //    val.PrintProperties();

                // var count = charge.ChargeLogs;

                // Console.WriteLine(charge.ChargeMetadata.Count);
            }

            Console.ReadKey();
        }
    }
}
