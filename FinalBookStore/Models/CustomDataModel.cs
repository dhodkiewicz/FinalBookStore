using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalBookStore.Models.EntityFramework;

namespace FinalBookStore.Models
{
    public class CustomDataModel
    {
        public AUTHOR AUTHOR { get; set; }

        public BOOK BOOK { get; set; }
        public List<INVENTORY>INVENTORIES { get; set; }

        public List<BRANCH> BRANCHES { get; set; }

    }
}