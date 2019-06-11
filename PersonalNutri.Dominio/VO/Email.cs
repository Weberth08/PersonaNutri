using System;

namespace PersonalNutri.Dominio.VO
{
    public class Email
    {
        public Email(string email)
        {
            if (!EhValido(email))
                throw new ArgumentException(nameof(email));

            Valor = email;
        }

        public string Valor { get; private set; }

        public static bool EhValido(string email)
        {
            //TODO: criar validacoes de email
            return string.IsNullOrEmpty(email) == false;            
        }       
    }
}
