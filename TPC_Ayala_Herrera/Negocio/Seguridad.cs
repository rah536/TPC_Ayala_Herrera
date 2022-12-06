﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user: null;
            if(usuario != null && usuario.Id != 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }

        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false;
        }


    }
}
