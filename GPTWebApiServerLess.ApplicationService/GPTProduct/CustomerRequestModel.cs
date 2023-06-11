using Core.Model.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTWebApiServerLess.ApplicationService.GPTProduct
{
    public class CustomerRequestModel
    {
        public string Message { get; set; }

        public ModelParameters ModelParameters { get; set; }
    }
}
