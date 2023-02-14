using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Api.Entidades
{
    public enum PermissionCatalogue
    {
        NONE,
        IPADDRESS,

        MENSAJES_DELETE,
        MENSAJES_UPDATE,
        MENSAJES_CREATE,
        MENSAJES_READ,
    }

    public static class PermissionCatalogueValues
    {
        public static string
            NONE = "NONE",
            IPADDRESS = "IPADDRESS",

            MENSAJES_DELETE = "MENSAJES_DELETE",
            MENSAJES_UPDATE = "MENSAJES_UPDATE",
            MENSAJES_CREATE = "MENSAJES_CREATE",
            MENSAJES_READ = "MENSAJES_READ";

        public static string GetValue(PermissionCatalogue permission)
        {
            string value;

            switch (permission)
            {
                case PermissionCatalogue.NONE:
                    value = NONE;
                    break;
                case PermissionCatalogue.IPADDRESS:
                    value = IPADDRESS;
                    break;
                case PermissionCatalogue.MENSAJES_DELETE:
                    value = MENSAJES_DELETE;
                    break;
                case PermissionCatalogue.MENSAJES_UPDATE:
                    value = MENSAJES_UPDATE;
                    break;
                case PermissionCatalogue.MENSAJES_CREATE:
                    value = MENSAJES_CREATE;
                    break;
                case PermissionCatalogue.MENSAJES_READ:
                    value = MENSAJES_READ;
                    break;
                default:
                    throw new Exception("No se encontró el valor del permiso");
            }

            return value;

        }

    }
}
