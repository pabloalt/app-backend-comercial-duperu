using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class RegisterResponse
    {

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHast { get; set; }
    }
}
