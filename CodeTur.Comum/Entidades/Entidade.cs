using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Entidades
{
    public abstract class Entidade : Notifiable
    {                              
        public Guid Id { get; set; }
        public DateTime DataCriacao{ get; set; }
        public DateTime DataAlteracao { get; set; }
    }                               
}
