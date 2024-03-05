using Aqua.Abstarctions;
using Aqua.Data;
using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class AssestRepo : IAssestRepo
    {
        private AquaJoyDBContext db;
        public string StatuceMessage { get; set; }

        public AssestRepo(AquaJoyDBContext context)
        {
            db = context;
        }

        public IEnumerable<Assests> GetAssestsByFilter(string parameter)
        {
            return db.Assest.Where(c => c.AssestName.Contains(parameter) || c.AssestType.Contains(parameter) || c.SearchDate.Contains(parameter))
                .ToList();
        }

        public bool UpdateAssest(Assests assest)
        {
            try
            {
                db.Assest.Update(assest);
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating Assest Item : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
