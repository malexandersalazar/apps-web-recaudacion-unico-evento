# Aplicación de Recaudación de Donaciones Monetarias en un Único Evento

![alt text](/images/cover.png "Aplicación de Recaudación de Donaciones Monetarias en un Único Evento")

Una simple aplicación web basada en .NET 6 para la recaudación de donaciones monetarias y registro de asistencias en un único evento.

## Configuración

### Ajustes

| Llave | Descripción |
| --- | --- |
| MetadataSettings.Author | especifica el autor de la aplicación  |
| MetadataSettings.ApplicationName | especifica el nombre de la aplicación |
| MetadataSettings.Copyright | especifica la atribución copyright de la aplicación |
| ConnectionStrings.DefaultConnection | especifica la cadena de conexión de la base de datos |

### Usuarios y Roles

Los usuarios y roles se definen en la clase `UniqueFundraisingEvent.Web.SeedIdentity`. Para que las contraseñas sean seguras podemos hacer uso del script [Secure Password Generator](https://github.com/malexandersalazar/tools-python-secure-password-generator).

### Invitados

La importación masiva de invitados se hace a través de un archivo .csv sin cabecera con las columnas `Nombre,Apellido,Correo,Empresa,Cargo`. A continuación unos datos de ejemplo:

```csv
Denise,Sims,felis.eget.varius@protonmail.com,Odio Associates,Human Resources
Yoshio,Coleman,sem.mollis@icloud.net,Mollis Dui In Inc.,Tech Support
Destiny,Mckenzie,mi.enim@icloud.edu,Sed Dui Fusce Industries,Asset Management
Angela,Sexton,faucibus.lectus@google.couk,Pharetra Sed Corporation,Accounting
Jasper,Rivera,eu@hotmail.com,Purus Sapien Limited,Media Relations
Dale,Owen,nec.tellus@protonmail.org,Ultrices Sit PC,Media Relations
```

## Requisitos Previos

La **Aplicación de Recaudación de Donaciones Monetarias en un Único Evento** fue desarrollado con:

* .NET: 6.0
* Databases:
    * Microsoft SQL Server Express Edition (64-bit)
    * Microsoft Azure SQL Database
* Packages:
    * MediatR: 12.0.1
    * CsvHelper: 30.0.1
    * Microsoft.EntityFrameworkCore.Tools: 6.0.16
    * Microsoft.EntityFrameworkCore.SqlServer: 6.0.16
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore: 6.0.16 
    * Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation: 6.0.16
    * Microsoft.VisualStudio.Web.CodeGeneration.Design: 6.0.14
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore: 6.0.16
* Template: Hyper v5.2.0 – Admin & Dashboard Template (Dark/Light) - Bootstrap Themes


## Licencia

Este proyecto está autorizado en virtud de la [MIT License][1].

[1]: https://opensource.org/licenses/mit-license.html "The MIT License | Open Source Initiative"