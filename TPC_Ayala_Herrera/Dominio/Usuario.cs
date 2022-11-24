using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Usuario
    {
        public enum TipoUsuario
        {
              ADMIN = 1,
              NOMAL = 2



        }

        public int Id { get; set; }

        public string User { get; set; }

        public string Pass { get; set; }

        public TipoUsuario tipoUsuario { get; set; }


        public Usuario(string user, string pass, bool admin)
        {

            User = user;
            Pass = pass;
            tipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NOMAL;    



        }


    }

    




}
