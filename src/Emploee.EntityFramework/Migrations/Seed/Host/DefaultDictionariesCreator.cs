using System.Collections.Generic;
using System.Linq;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using Emploee.Emploee.Dictionaries;
using Emploee.EntityFramework;

namespace Emploee.Migrations.Seed.Host
{
    public class DefaultDictionariesCreator
    {
        private readonly EmploeeDbContext _context;

        public DefaultDictionariesCreator(EmploeeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            AddDictionaryIfNotExists("", "001", "行业类别","", 1);
            AddDictionaryIfNotExists("", "002", "数据类型","", 1);
            AddDictionaryIfNotExists("001", "00101", "玻璃行业","", 1);
            AddDictionaryIfNotExists("", "002", "数据类型", "", 0);
            AddDictionaryIfNotExists("002", "00201", "点源表模板", "", 1);
            AddDictionaryIfNotExists("002", "00202", "面源表模板", "", 2);
        }

        private void AddDictionaryIfNotExists(string ParentCode, string code, string Name, string Value, int orderindex)
        {
            if (_context.Dictionarys.Any(l => l.Code == code))
            {
                return;
            }
            Dictionary NewDictionary = new Dictionary();
            NewDictionary.Code = code;
            NewDictionary.Name = Name;
            NewDictionary.value = Value;
            NewDictionary.OrderIndex = orderindex;
            NewDictionary.ParentCode = ParentCode;
            //_context.Mould_Dictionarys.Add(MouldMes_Dictionary);
            _context.Dictionarys.Add(NewDictionary);

            _context.SaveChanges();
        }





    }
}