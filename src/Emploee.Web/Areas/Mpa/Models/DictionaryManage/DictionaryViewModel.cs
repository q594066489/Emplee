
using Emploee.Emploee.Dictionaries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emploee.Web.Areas.Mpa.Models.DictionaryManage
{
    public class DictionaryViewModel
    {
        public string ParentCode { get; set; }

        public List<DictionaryListDto> ParentList { get; set; }

    }
}