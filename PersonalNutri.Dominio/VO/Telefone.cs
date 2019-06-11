using System;

namespace PersonalNutri.Dominio.VO
{
    public class Telefone
    {
        public Telefone(long numero)
        {
            if(EhValido(numero) == false)
                throw new ArgumentException(nameof(numero));

            Numero = numero;
        }

        public long Numero { get; private set; }

        public static bool EhValido(long numero) {

           //TODO: adicionar outras validações de telefone
           return numero > 0 && (numero.ToString().Length == 10 || numero.ToString().Length == 11);
        }

    }
}
