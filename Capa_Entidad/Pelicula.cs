
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Capa_Entidad
{

using System;
    using System.Collections.Generic;
    
public partial class Pelicula
{

    public int Id { get; set; }

    public string Titulo { get; set; }

    public Nullable<int> Id_Genero { get; set; }

    public string Duracion { get; set; }

    public Nullable<int> Id_Director { get; set; }

    public string Protagonista { get; set; }

    public string Sipnosis { get; set; }

    public string Media { get; set; }

    public string Imagen { get; set; }

    public string Estudio { get; set; }

    public string FechaLanzamiento { get; set; }



    public virtual Genero Genero { get; set; }

    public virtual Director Director { get; set; }

}

}
