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
    internal class CrediteOrDetebtor : ICrediteOrDetebtor
    {
        private AquaJoyDBContext db;
        public string StatuceMessage { get; set; }

        public CrediteOrDetebtor(AquaJoyDBContext context)
        {
            db = context;
        }

        public IEnumerable<CreditorOrDetebtor> GetCreditorOrDetebtorByFilter(string parameter)
        {
            return db.CreditorOrDetebtor.Where(c => c.Name.Contains(parameter) || c.SerachDate.Contains(parameter) || c.Type.Contains(parameter)).ToList();
        }

        public bool UpdatedDB(CreditorOrDetebtor creditorOrDetebtor)
        {
            try
            {
                db.CreditorOrDetebtor.Update(creditorOrDetebtor);
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating CreditorOrDetebtor Item : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
