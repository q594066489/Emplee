using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emploee.Web.Areas.Mpa.Models.CompanyManage
{
    public class ShowPictureModal
    {
       public  string picSrc { get; set; }

        public ShowPictureModal(string picsrc)
        {
            this.picSrc = picsrc;
        }
    }
}