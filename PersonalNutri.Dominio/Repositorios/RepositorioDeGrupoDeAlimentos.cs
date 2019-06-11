using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;

namespace PersonalNutri.Dominio.Repositorios
{
   public class RepositorioDeGrupoDeAlimentos : IRepositorioDeGrupoDeAlimentos
    {
        public IEnumerable<GrupoDeAlimento> RetornarGruposDeAlimentos()
        {
           //Poderia conectar em uma base, arquivo, etc:

            var grupos = new List<GrupoDeAlimento>();

            var grupo1 = new GrupoDeAlimento("Carboidratos");
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Arroz", 130));
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Batata", 86));
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Macarrão", 371));
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Batata Doce", 98));
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Mandioca", 159));
            grupo1.AdicionarAlimento(new Alimento(grupo1, "Pão Francês", 310));

            var grupo2 = new GrupoDeAlimento("Verduras e Legumes");
            grupo2.AdicionarAlimento(new Alimento(grupo2, "Brócolis", 54));
            grupo2.AdicionarAlimento(new Alimento(grupo2, "Couve", 23));
            grupo2.AdicionarAlimento(new Alimento(grupo2, "Repolho", 25));
            grupo2.AdicionarAlimento(new Alimento(grupo2, "Alface", 15));
            grupo2.AdicionarAlimento(new Alimento(grupo2, "Brócolis", 130));


            var grupo3 = new GrupoDeAlimento("Frutas");
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Laranja", 37));
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Manga", 60));
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Maçã", 52));
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Pêra", 57));
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Uva", 67));
            grupo3.AdicionarAlimento(new Alimento(grupo3, "Banana", 122));


            grupos.Add(grupo1);
            grupos.Add(grupo2);
            grupos.Add(grupo3);

            return grupos;

        }
    }
}
