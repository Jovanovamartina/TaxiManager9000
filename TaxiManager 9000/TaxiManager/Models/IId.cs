using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public interface IId
    {
        int Id { get; set; }//Od ovoj interface ke nasleduvaat Car,Driver i User.
    }
}
